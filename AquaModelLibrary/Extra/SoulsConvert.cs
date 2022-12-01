﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using SoulsFormats;
using static AquaModelLibrary.AquaNode;

namespace AquaModelLibrary.Extra
{
    public static class SoulsConvert
    {
        public enum SoulsGame
        {
            DemonsSouls,
            DarkSouls1,
            DarkSouls2,
            Bloodborne,
            DarkSouls3,
            Sekiro
        }

        public static Matrix4x4 mirrorMat = new Matrix4x4(-1, 0, 0, 0,
                                    0, 1, 0, 0,
                                    0, 0, 1, 0,
                                    0, 0, 0, 1);

        public static AquaObject ReadFlver(string filePath, out AquaNode aqn)
        {
            SoulsFormats.IFlver flver = null;
            var raw = File.ReadAllBytes(filePath);

            if (SoulsFormats.SoulsFile<SoulsFormats.FLVER0>.Is(raw))
            {
                flver = SoulsFormats.SoulsFile<SoulsFormats.FLVER0>.Read(raw);
            }
            else if (SoulsFormats.SoulsFile<SoulsFormats.FLVER2>.Is(raw))
            {
                flver = SoulsFormats.SoulsFile<SoulsFormats.FLVER2>.Read(raw);
            }
            aqn = null;
            return FlverToAqua(flver, out aqn);
        }
        
        public static AquaObject FlverToAqua(IFlver flver, out AquaNode aqn)
        {
            AquaObject aqp = new NGSAquaObject();

            if(flver is FLVER2 flver2)
            {
                if(flver2.Header.Version > 0x20010)
                {
                    for(int i = 0; i < flver2.Bones.Count; i++)
                    {
                        aqp.bonePalette.Add((uint)i);
                    }
                }
            }
            aqn = new AquaNode();
            for (int i = 0; i < flver.Bones.Count; i++)
            {
                var flverBone = flver.Bones[i];
                var parentId = flverBone.ParentIndex;

                FLVER.Bone.RotationOrder order = FLVER.Bone.RotationOrder.XZY;
                var tfmMat = Matrix4x4.Identity;

                Matrix4x4 mat = flverBone.ComputeLocalTransform(order);

                mat *= tfmMat;

                Matrix4x4.Decompose(mat, out var scale, out var quatRot, out var translation);

                //If there's a parent, multiply by it
                if (parentId != -1)
                {
                    var pn = aqn.nodeList[parentId];
                    var parentInvTfm = new Matrix4x4(pn.m1.X, pn.m1.Y, pn.m1.Z, pn.m1.W,
                                                  pn.m2.X, pn.m2.Y, pn.m2.Z, pn.m2.W,
                                                  pn.m3.X, pn.m3.Y, pn.m3.Z, pn.m3.W,
                                                  pn.m4.X, pn.m4.Y, pn.m4.Z, pn.m4.W);
                    
                    Matrix4x4.Invert(parentInvTfm, out var invParentInvTfm);
                    mat = mat * invParentInvTfm;
                }
                if(parentId == -1 && i != 0)
                {
                    parentId = 0;
                }

                //Create AQN node
                NODE aqNode = new NODE();
                aqNode.boneShort1 = 0x1C0;
                aqNode.animatedFlag = 1;
                aqNode.parentId = parentId;
                aqNode.unkNode = -1;

                aqNode.scale = new Vector3(1, 1, 1);

                Matrix4x4.Invert(mat, out var invMat);
                aqNode.m1 = new Vector4(invMat.M11, invMat.M12, invMat.M13, invMat.M14);
                aqNode.m2 = new Vector4(invMat.M21, invMat.M22, invMat.M23, invMat.M24);
                aqNode.m3 = new Vector4(invMat.M31, invMat.M32, invMat.M33, invMat.M34);
                aqNode.m4 = new Vector4(invMat.M41, invMat.M42, invMat.M43, invMat.M44);
                aqNode.boneName.SetString(flverBone.Name);
                //Debug.WriteLine($"{i} " + aqNode.boneName.GetString());
                aqn.nodeList.Add(aqNode);
            }

            //I 100% believe there's a better way to do this when constructing the matrix, but for now we do this.
            for(int i = 0; i < aqn.nodeList.Count; i++)
            {
                var bone = aqn.nodeList[i];
                Matrix4x4.Invert(bone.GetInverseBindPoseMatrix(), out var mat);
                mat *= mirrorMat;
                Matrix4x4.Decompose(mat, out var scale, out var rot, out var translation);
                bone.pos = translation;
                bone.eulRot = MathExtras.QuaternionToEuler(rot);

                Matrix4x4.Invert(mat, out var invMat);
                bone.SetInverseBindPoseMatrix(invMat);
                aqn.nodeList[i] = bone;
            }

            for (int i = 0; i < flver.Meshes.Count; i++)
            {
                var mesh = flver.Meshes[i];

                var nodeMatrix = Matrix4x4.Identity;

                //Vert data
                var vertCount = mesh.Vertices.Count;
                AquaObject.VTXL vtxl = new AquaObject.VTXL();

                if (mesh.Dynamic > 0)
                {
                    if(mesh is FLVER0.Mesh flv)
                    {

                        for (int b = 0; b < flv.BoneIndices.Length; b++)
                        {
                            if (flv.BoneIndices[b] == -1)
                            {
                                break;
                            }
                            vtxl.bonePalette.Add((ushort)flv.BoneIndices[b]);
                        }
                    } else if (mesh is FLVER2.Mesh flv2)
                    {
                        for (int b = 0; b < flv2.BoneIndices.Count; b++)
                        {
                            if (flv2.BoneIndices[b] == -1)
                            {
                                break;
                            }
                            vtxl.bonePalette.Add((ushort)flv2.BoneIndices[b]);
                        }
                    }
                }
                List<int> indices = new List<int>();
                if (flver is FLVER0)
                {
                    FLVER0.Mesh mesh0 = (FLVER0.Mesh)mesh;
                    vtxl.bonePalette = new List<ushort>();
                    for (int b = 0; b < mesh0.BoneIndices.Length; b++)
                    {
                        if (mesh0.BoneIndices[b] == -1)
                        {
                            break;
                        }
                        vtxl.bonePalette.Add((ushort)mesh0.BoneIndices[b]);
                    }
                    indices = mesh0.Triangulate(((FLVER0)flver).Header.Version);
                }
                else if (flver is FLVER2)
                {
                    FLVER2.Mesh mesh2 = (FLVER2.Mesh)mesh;

                    //Dark souls 3+ (Maybe bloodborne too) use direct bone id references instead of a bone palette
                    vtxl.bonePalette = new List<ushort>();
                    for (int b = 0; b < mesh2.BoneIndices.Count; b++)
                    {
                        if (mesh2.BoneIndices[b] == -1)
                        {
                            break;
                        }
                        vtxl.bonePalette.Add((ushort)mesh2.BoneIndices[b]);
                    }

                    FLVER2.FaceSet faceSet = mesh2.FaceSets[0];
                    indices = faceSet.Triangulate(mesh2.Vertices.Count < ushort.MaxValue);
                }
                else
                {
                    throw new Exception("Unexpected flver variant");
                }

                for (int v = 0; v < vertCount; v++)
                {
                    var vert = mesh.Vertices[v];
                    vtxl.vertPositions.Add(Vector3.Transform(vert.Position, mirrorMat));
                    vtxl.vertNormals.Add(Vector3.Transform(vert.Normal, mirrorMat));

                    if (vert.UVs.Count > 0)
                    {
                        var uv1 = vert.UVs[0];
                        vtxl.uv1List.Add(new Vector2(uv1.X, uv1.Y));
                    }
                    if (vert.UVs.Count > 1)
                    {
                        var uv2 = vert.UVs[1];
                        vtxl.uv2List.Add(new Vector2(uv2.X, uv2.Y));
                    }
                    if (vert.UVs.Count > 2)
                    {
                        var uv3 = vert.UVs[2];
                        vtxl.uv3List.Add(new Vector2(uv3.X, uv3.Y));
                    }
                    if (vert.UVs.Count > 3)
                    {
                        var uv4 = vert.UVs[3];
                        vtxl.uv4List.Add(new Vector2(uv4.X, uv4.Y));
                    }

                    if (vert.Colors.Count > 0)
                    {
                        var color = vert.Colors[0];
                        vtxl.vertColors.Add(new byte[] { (byte)(color.B * 255), (byte)(color.G * 255), (byte)(color.R * 255), (byte)(color.A * 255) });
                    }
                    if (vert.Colors.Count > 1)
                    {
                        var color2 = vert.Colors[1];
                        vtxl.vertColor2s.Add(new byte[] { (byte)(color2.B * 255), (byte)(color2.G * 255), (byte)(color2.R * 255), (byte)(color2.A * 255) });
                    }

                    if(vert.BoneWeights.Length > 0)
                    {
                        vtxl.vertWeights.Add(new Vector4(vert.BoneWeights[0], vert.BoneWeights[1], vert.BoneWeights[2], vert.BoneWeights[3]));
                        vtxl.vertWeightIndices.Add(new int[] { vert.BoneIndices[0], vert.BoneIndices[1], vert.BoneIndices[2], vert.BoneIndices[3] });
                    } else if(vert.BoneIndices.Length > 0)
                    {
                        vtxl.vertWeights.Add(new Vector4(1, 0, 0, 0));
                        vtxl.vertWeightIndices.Add(new int[] { vert.BoneIndices[0], 0, 0, 0 });
                    } else if(vert.NormalW < 65535)
                    {
                        vtxl.vertWeights.Add(new Vector4(1, 0, 0, 0));
                        vtxl.vertWeightIndices.Add(new int[] { vert.NormalW, 0, 0, 0 });
                    }
                }

                vtxl.convertToLegacyTypes();
                aqp.vtxeList.Add(AquaObjectMethods.ConstructClassicVTXE(vtxl, out int vc));
                aqp.vtxlList.Add(vtxl);

                //Face data
                AquaObject.GenericTriangles genMesh = new AquaObject.GenericTriangles();

                List<Vector3> triList = new List<Vector3>();
                if (flver is FLVER0)
                {
                    for (int id = 0; id < indices.Count - 2; id += 3)
                    {
                        triList.Add(new Vector3(indices[id], indices[id + 1], indices[id + 2]));
                    }
                }
                else
                {
                    for (int id = 0; id < indices.Count - 2; id += 3)
                    {
                        triList.Add(new Vector3(indices[id], indices[id + 1], indices[id + 2]));
                    }
                }


                genMesh.triList = triList;

                //Extra
                genMesh.vertCount = vertCount;
                genMesh.matIdList = new List<int>(new int[genMesh.triList.Count]);
                for (int j = 0; j < genMesh.matIdList.Count; j++)
                {
                    genMesh.matIdList[j] = aqp.tempMats.Count;
                }
                aqp.tempTris.Add(genMesh);

                //Material
                var mat = new AquaObject.GenericMaterial();
                var flverMat = flver.Materials[mesh.MaterialIndex];
                mat.matName = flverMat.Name;
                mat.texNames = new List<string>();
                foreach(var tex in flverMat.Textures)
                {
                    mat.texNames.Add(Path.GetFileName(tex.Path));
                }
                aqp.tempMats.Add(mat);
            }

            return aqp;
        }

        public static IFlver ConvertModelToFlver(string initialFilePath, float scaleFactor, bool preAssignNodeIds, bool isNGS, SoulsGame game, IFlver matReferenceFlver = null)
        {
            return null;
            //return AquaToFlver(initialFilePath, ModelImporter.AssimpAquaConvertFull(initialFilePath, scaleFactor, preAssignNodeIds, isNGS, out AquaNode aqn), aqn, game, matReferenceFlver);
        }
        
        public static IFlver AquaToFlver(string initialFilePath, AquaObject aqp, AquaNode aqn, SoulsGame game, IFlver matReferenceFlver)
        {
            switch(game)
            {
                case SoulsGame.DemonsSouls:
                    break;
                default:
                    return null;
            }

            var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            var mtdDict = ReadMTDLayoutData(Path.Combine(exePath, "DeSMtdLayoutData.bin"));
            FLVER0 flver = new FLVER0();
            flver.Header = new FLVER0Header();
            flver.Header.BigEndian = true;
            flver.Header.Unicode = true;
            flver.Header.Version = 0x15;
            flver.Header.Unk4A = 0x1;
            flver.Header.Unk4B = 0;
            flver.Header.Unk4C = 0xFFFF;
            flver.Header.Unk5C = 0;

            List<string> usedMaterials = new List<string>();
            Dictionary<string, FLVER0.Material> matDict = new Dictionary<string, FLVER0.Material>();
            if (matReferenceFlver != null)
            {
                for (int i = 0; i < matReferenceFlver.Materials.Count; i++)
                {
                    matDict.Add(matReferenceFlver.Materials[i].Name, (FLVER0.Material)matReferenceFlver.Materials[i]);
                }
            }

            for (int i = 0; i < aqp.mateList.Count; i++)
            {
                var matIndex = usedMaterials.IndexOf(aqp.mateList[i].matName.GetString());
                if (matIndex != -1)
                {
                    var name = aqp.mateList[i].matName.GetString();
                    var nameSplit = name.Split('|');
                    string mtd = null;
                    if(nameSplit.Length > 1)
                    {
                        mtd = nameSplit[1];
                    } else
                    {
                        mtd = "u:\\nlimited\\based\\works\\p_metal[dsb]_skin.mtd";
                    }

                    var flvMat = new FLVER0.Material(true);
                    flvMat.Name = nameSplit[0];
                    if (mtdDict.ContainsKey(Path.GetFileName(mtd).ToLower()))
                    {
                        flvMat.Layouts.Add(mtdDict[mtd]);
                        flvMat.MTD = mtd;
                    }
                } else
                {
                    //var name = ;
                    usedMaterials.Add(name);
                    if(matDict.TryGetValue(name, out var mat))
                    {
                        flver.Materials.Add(mat);
                    } else
                    {
                        var flvMat = new FLVER0.Material(true);
                        flvMat.Name = name;
                        flvMat.MTD = "u:\\nlimited\\based\\works\\p_metal[dsb]_skin.mtd";
                        flvMat.Layouts = new List<FLVER0.BufferLayout>();

                        //Create Vertex layouts
                        //TODO create them based on MTD if needed? Unsure how much variation is required here
                        //flvMat.Layouts.Add(new FLVER0.BufferLayout());
                        //flvMat.Textures
                    }
                }
            }

            //Bones store bounding which encompass the extents of all vertices onto which they are weighted.
            //When no vertices are weighted to them, this bounding is -3.402823e+38 for all min bound values and 3.402823e+38 for all max bound values
            Dictionary<int, Vector3> MaxBoundingBoxByBone = new Dictionary<int, Vector3>();
            Dictionary<int, Vector3> MinBoundingBoxByBone = new Dictionary<int, Vector3>();

            for (int i = 0; i < aqp.meshList.Count; i++)
            {
                var mesh = aqp.meshList[i];
                var vtxl = aqp.vtxlList[mesh.vsetIndex];
                var faces = aqp.strips[mesh.psetIndex];
                var shader = aqp.shadList[mesh.shadIndex];
                var render = aqp.rendList[mesh.rendIndex];
                var flvMat = flver.Materials[mesh.mateIndex];

                FLVER0.Mesh flvMesh = new FLVER0.Mesh();
                flvMesh.MaterialIndex = (byte)mesh.mateIndex;
                flvMesh.BackfaceCulling = render.twosided > 0;
                flvMesh.Dynamic = vtxl.vertWeights.Count > 0 ? (byte)1 : (byte)0;

                for (int v = 0; v < vtxl.vertPositions.Count; v++)
                {
                    var vert = new FLVER.Vertex();

                    for(int l = 0; l < flvMat.Layouts[0].Count; l++)
                    {
                        switch (flvMat.Layouts[0][l].Semantic)
                        {
                            case FLVER.LayoutSemantic.Position:
                                var pos = Vector3.Transform(vtxl.vertPositions[v], mirrorMat);
                                vert.Position = pos;
                                break;
                            case FLVER.LayoutSemantic.UV:
                                if(flvMat.Layouts[0][l].Type == FLVER.LayoutType.UVPair)
                                {

                                } else
                                {

                                }
                                break;
                            case FLVER.LayoutSemantic.Normal:
                                if (vtxl.vertNormals.Count > 0)
                                {
                                    vert.Normal = Vector3.TransformNormal(vtxl.vertNormals[v], mirrorMat);
                                } else
                                {
                                    vert.Normal = Vector3.One;
                                }
                                break;
                            case FLVER.LayoutSemantic.Tangent:
                                break;
                            case FLVER.LayoutSemantic.Bitangent:
                                break;
                            case FLVER.LayoutSemantic.VertexColor:
                                break;
                            case FLVER.LayoutSemantic.BoneIndices:
                                break;
                            case FLVER.LayoutSemantic.BoneWeights:
                                break;
                        }
                    }

                    if (vtxl.vertTangentList.Count > 0)
                    {
                        vert.Tangents.Add(new Vector4(Vector3.TransformNormal(vtxl.vertTangentList[v], mirrorMat), 0));
                    }

                    if (vtxl.vertBinormalList.Count > 0)
                    {
                        vert.Bitangent = new Vector4(Vector3.TransformNormal(vtxl.vertBinormalList[v], mirrorMat), 0);
                    }

                    if (vtxl.vertColors.Count > 0)
                    {
                        vert.Colors.Add(new FLVER.VertexColor(vtxl.vertColors[v][3], vtxl.vertColors[v][2], vtxl.vertColors[v][1], vtxl.vertColors[v][0]));
                    }

                    if (vtxl.vertColor2s.Count > 0)
                    {
                        vert.Colors.Add(new FLVER.VertexColor(vtxl.vertColor2s[v][3], vtxl.vertColor2s[v][2], vtxl.vertColor2s[v][1], vtxl.vertColor2s[v][0]));
                    }

                    if (vtxl.uv1List.Count > 0)
                    {
                        vert.UVs.Add(new Vector3(vtxl.uv1List[v], 0));
                    }

                    if (vtxl.uv2List.Count > 0)
                    {
                        vert.UVs.Add(new Vector3(vtxl.uv2List[v], 0));
                    }

                    if (vtxl.uv3List.Count > 0)
                    {
                        vert.UVs.Add(new Vector3(vtxl.uv3List[v], 0));
                    }

                    if (vtxl.uv4List.Count > 0)
                    {
                        vert.UVs.Add(new Vector3(vtxl.uv4List[v], 0));
                    }

                    if(vtxl.vertWeightIndices.Count > 0)
                    {
                        var indices = vtxl.vertWeightIndices[v];
                        vert.BoneIndices = new FLVER.VertexBoneIndices() { };
                        vert.BoneIndices[0] = indices[0];
                        vert.BoneIndices[1] = indices[1];
                        vert.BoneIndices[2] = indices[2];
                        vert.BoneIndices[3] = indices[3];

                        int bone0 = indices[0];
                        int bone1 = indices[1];
                        int bone2 = indices[2];
                        int bone3 = indices[3];
                        if (aqp is ClassicAquaObject)
                        {
                            bone0 = vtxl.bonePalette[bone0];
                            bone1 = vtxl.bonePalette[bone1];
                            bone2 = vtxl.bonePalette[bone2];
                            bone3 = vtxl.bonePalette[bone3];
                        }

                        List<int> boneCheckList = new List<int>();
                        boneCheckList.Add(bone0);
                        if (boneCheckList.Contains(bone1))
                        {
                            bone1 = -1;
                        }
                        if (boneCheckList.Contains(bone2))
                        {
                            bone2 = -1;
                        }
                        if (boneCheckList.Contains(bone3))
                        {
                            bone3 = -1;
                        }

                        CheckBounds(MaxBoundingBoxByBone, MinBoundingBoxByBone, vert.Position, bone0);
                        CheckBounds(MaxBoundingBoxByBone, MinBoundingBoxByBone, vert.Position, bone1);
                        CheckBounds(MaxBoundingBoxByBone, MinBoundingBoxByBone, vert.Position, bone2);
                        CheckBounds(MaxBoundingBoxByBone, MinBoundingBoxByBone, vert.Position, bone3);
                    }

                    if (vtxl.vertWeights.Count > 0)
                    {
                        var weights = vtxl.vertWeightIndices[v];
                        vert.BoneWeights = new FLVER.VertexBoneWeights() { };
                        vert.BoneWeights[0] = weights[0];
                        vert.BoneWeights[1] = weights[1];
                        vert.BoneWeights[2] = weights[2];
                        vert.BoneWeights[3] = weights[3];
                    }

                    flvMesh.Vertices.Add(vert);
                }

            }

            foreach (var aqBone in aqn.nodeList)
            {
                FLVER.Bone bone = new FLVER.Bone();
                bone.Name = aqBone.boneName.GetString();
                //bone.
                flver.Bones.Add(bone);
            }

            return flver;
        }

        private static void CheckBounds(Dictionary<int, Vector3> MaxBoundingBoxByBone, Dictionary<int, Vector3> MinBoundingBoxByBone, Vector3 vec3, int boneId)
        {
            if (boneId != -1 && !MaxBoundingBoxByBone.ContainsKey(boneId))
            {
                MaxBoundingBoxByBone[boneId] = vec3;
                MinBoundingBoxByBone[boneId] = vec3;
            }
            else if(boneId != -1)
            {
                MaxBoundingBoxByBone[boneId] = AquaObjectMethods.GetMaximumBounding(MaxBoundingBoxByBone[boneId], vec3);
                MinBoundingBoxByBone[boneId] = AquaObjectMethods.GetMinimumBounding(MinBoundingBoxByBone[boneId], vec3);
            }
        }

        public static void GetDeSLayoutMTDInfo(string desPath)
        {
            Dictionary<string, FLVER0.BufferLayout> mtdLayoutsRawDict = new Dictionary<string, FLVER0.BufferLayout>();
            var files = Directory.EnumerateFiles(desPath, "*.*", SearchOption.AllDirectories);
            foreach (var file in files)
            {
                var loadedFiles = ReadFilesNullable<FLVER0>(file);
                if (loadedFiles != null && loadedFiles.Count > 0)
                {
                    foreach (var fileSet in loadedFiles)
                    {
                        var flver = fileSet.File;

                        foreach (var mat in flver.Materials)
                        {
                            var layout = mat.Layouts[0];
                            if (!mtdLayoutsRawDict.ContainsKey(mat.MTD))
                            {
                                mtdLayoutsRawDict.Add(mat.MTD, layout);
                            }
                        }
                    }
                }

                List<byte> mtdLayoutBytes = new List<byte>();
                mtdLayoutBytes.AddRange(BitConverter.GetBytes(mtdLayoutsRawDict.Count));
                foreach (var entry in mtdLayoutsRawDict)
                {
                    mtdLayoutBytes.AddRange(BitConverter.GetBytes(entry.Key.Length * 2));
                    mtdLayoutBytes.AddRange(UnicodeEncoding.Unicode.GetBytes(entry.Key));
                    mtdLayoutBytes.AddRange(BitConverter.GetBytes(entry.Value.Count));
                    foreach (var layoutEntry in entry.Value)
                    {
                        mtdLayoutBytes.Add((byte)layoutEntry.Type);
                        mtdLayoutBytes.Add((byte)layoutEntry.Semantic);
                    }
                }

                var exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                File.WriteAllBytes(Path.Combine(exePath, "DeSMtdLayoutData.bin"), mtdLayoutBytes.ToArray());
            }
        }

        public static Dictionary<string, FLVER0.BufferLayout> ReadMTDLayoutData(string dataPath)
        {
            var layoutsRaw = File.ReadAllBytes(dataPath);
            int offset = 0;
            int entryCount = BitConverter.ToInt32(layoutsRaw, 0);
            offset += 4;
            Dictionary<string, FLVER0.BufferLayout> layouts = new Dictionary<string, FLVER0.BufferLayout>();
            for (int i = 0; i < entryCount; i++)
            {
                int strByteLen = BitConverter.ToInt32(layoutsRaw, offset);
                offset += 4;
                string mtd = Encoding.Unicode.GetString(layoutsRaw, offset, strByteLen).ToLower();
                offset += strByteLen;

                int layoutLen = BitConverter.ToInt32(layoutsRaw, offset);
                offset += 4;
                FLVER0.BufferLayout layout = new FLVER0.BufferLayout();
                for (int j = 0; j < layoutLen; j++)
                {
                    byte type = layoutsRaw[offset];
                    offset += 1;
                    byte semantic = layoutsRaw[offset];
                    offset += 1;

                    layout.Add(new FLVER.LayoutMember((FLVER.LayoutType)type, (FLVER.LayoutSemantic)semantic, j, 0));
                }
                if (!layouts.ContainsKey(Path.GetFileName(mtd)))
                {
                    layouts.Add(Path.GetFileName(mtd), layout);
                }
            }

            return layouts;
        }

        public class URIFlver0Pair
        {
            public string Uri { get; set; }
            public FLVER0 File { get; set; }
        }

        public static List<URIFlver0Pair> ReadFilesNullable<TFormat>(string path)
    where TFormat : SoulsFile<TFormat>, new()
        {
            if (BND3.Is(path))
            {
                var bnd3 = BND3.Read(path);
                var selected = bnd3.Files.Where(f => Path.GetExtension(f.Name) == ".flver");
                List<URIFlver0Pair> Files = new List<URIFlver0Pair>();
                foreach (var file in bnd3.Files)
                {
                    if (Path.GetExtension(file.Name) == ".flver")
                    {
                        Files.Add(new URIFlver0Pair() { Uri = file.Name, File = SoulsFile<FLVER0>.Read(file.Bytes) });
                    }
                }
                return Files;
            }
            else if (BND4.Is(path))
            {
                var bnd4 = BND4.Read(path);
                var selected = bnd4.Files.Where(f => Path.GetExtension(f.Name) == ".flver");
                List<URIFlver0Pair> Files = new List<URIFlver0Pair>();
                foreach (var file in bnd4.Files)
                {
                    if (Path.GetExtension(file.Name) == ".flver")
                    {
                        Files.Add(new URIFlver0Pair() { Uri = file.Name, File = SoulsFile<FLVER0>.Read(file.Bytes) });
                    }
                }
                return Files;
            }
            else
            {
                var file = File.ReadAllBytes(path);
                if (FLVER0.Is(file))
                {
                    return new List<URIFlver0Pair>() { new URIFlver0Pair() { Uri = path, File = SoulsFile<FLVER0>.Read(file) } };
                }
                return null;
            }

        }

        public static bool IsMaterialUsingSkinning(FLVER0.Material mat)
        {
            for (int i = 0; i < mat.Layouts.Count; i++)
            {
                //HOPEFULLY this should always be 0. If not, pain
                if(mat.Layouts[0][i].Semantic == FLVER.LayoutSemantic.BoneWeights)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
