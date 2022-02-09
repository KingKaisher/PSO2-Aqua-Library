﻿namespace AquaModelTool
{
    partial class AquaModelTool
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.extraToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.averageNormalsOnSharedPositionVerticesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.batchParsePSO2SetToTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.getToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checkAllShaderExtrasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.generateCharacterFileSheetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pSOnrelTotrpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parsePSO2TextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parsePSO2TextFolderSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertTxtToPSO2TextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertTxtToPSO2TextFolderSelectToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.parseVTBFToTextToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateClassicPlayerAnimToNGSAnimToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legacyAqp2objObjExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legacyAqp2objBatchExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.legacyAqp2objObjImportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prmEffectModelExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.prmEffectFromModelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.convertAnimationToAQMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.spirefierToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.debugToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readBonesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToGLTFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.importFromGLTFToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.computeTangentSpaceTestToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cloneBoneTransformsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.testVTXEToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpNOF0ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readBTIToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readMagIndicesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readCMOToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpFigEffectTypesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readCMXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readFIGToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dumpFigShapesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.readLacToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filePanel = new System.Windows.Forms.Panel();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.readLacToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.extraToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.debugToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(384, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.exportModelToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // exportModelToolStripMenuItem
            // 
            this.exportModelToolStripMenuItem.Name = "exportModelToolStripMenuItem";
            this.exportModelToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.exportModelToolStripMenuItem.Text = "Export Model (Buggy)";
            this.exportModelToolStripMenuItem.ToolTipText = "May produce strange results or crash on some models.";
            this.exportModelToolStripMenuItem.Click += new System.EventHandler(this.exportModelToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.saveAsToolStripMenuItem.Text = "Save As";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // extraToolStripMenuItem
            // 
            this.extraToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.averageNormalsOnSharedPositionVerticesToolStripMenuItem,
            this.toolStripSeparator1});
            this.extraToolStripMenuItem.Name = "extraToolStripMenuItem";
            this.extraToolStripMenuItem.Size = new System.Drawing.Size(45, 20);
            this.extraToolStripMenuItem.Text = "Extra";
            // 
            // averageNormalsOnSharedPositionVerticesToolStripMenuItem
            // 
            this.averageNormalsOnSharedPositionVerticesToolStripMenuItem.Name = "averageNormalsOnSharedPositionVerticesToolStripMenuItem";
            this.averageNormalsOnSharedPositionVerticesToolStripMenuItem.Size = new System.Drawing.Size(309, 22);
            this.averageNormalsOnSharedPositionVerticesToolStripMenuItem.Text = "Average Normals on shared position vertices";
            this.averageNormalsOnSharedPositionVerticesToolStripMenuItem.Click += new System.EventHandler(this.averageNormalsOnSharedPositionVerticesToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(306, 6);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.batchParsePSO2SetToTextToolStripMenuItem,
            this.getToolStripMenuItem,
            this.checkAllShaderExtrasToolStripMenuItem,
            this.generateCharacterFileSheetToolStripMenuItem,
            this.pSOnrelTotrpToolStripMenuItem,
            this.parsePSO2TextToolStripMenuItem,
            this.parsePSO2TextFolderSelectToolStripMenuItem,
            this.convertTxtToPSO2TextToolStripMenuItem,
            this.convertTxtToPSO2TextFolderSelectToolStripMenuItem,
            this.parseVTBFToTextToolStripMenuItem,
            this.updateClassicPlayerAnimToNGSAnimToolStripMenuItem,
            this.legacyAqp2objObjExportToolStripMenuItem,
            this.legacyAqp2objBatchExportToolStripMenuItem,
            this.legacyAqp2objObjImportToolStripMenuItem,
            this.prmEffectModelExportToolStripMenuItem,
            this.prmEffectFromModelToolStripMenuItem,
            this.convertAnimationToAQMToolStripMenuItem,
            this.spirefierToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
            this.toolsToolStripMenuItem.Text = "Tools";
            // 
            // batchParsePSO2SetToTextToolStripMenuItem
            // 
            this.batchParsePSO2SetToTextToolStripMenuItem.Name = "batchParsePSO2SetToTextToolStripMenuItem";
            this.batchParsePSO2SetToTextToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.batchParsePSO2SetToTextToolStripMenuItem.Text = "Batch Parse PSO2 Set to Text";
            this.batchParsePSO2SetToTextToolStripMenuItem.Click += new System.EventHandler(this.batchParsePSO2SetToTextToolStripMenuItem_Click);
            // 
            // getToolStripMenuItem
            // 
            this.getToolStripMenuItem.Name = "getToolStripMenuItem";
            this.getToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.getToolStripMenuItem.Text = "Compile Shader Texture Sheet";
            this.getToolStripMenuItem.Click += new System.EventHandler(this.getShadTexSheetToolStripMenuItem_Click);
            // 
            // checkAllShaderExtrasToolStripMenuItem
            // 
            this.checkAllShaderExtrasToolStripMenuItem.Name = "checkAllShaderExtrasToolStripMenuItem";
            this.checkAllShaderExtrasToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.checkAllShaderExtrasToolStripMenuItem.Text = "Check All Shader Extras";
            this.checkAllShaderExtrasToolStripMenuItem.Click += new System.EventHandler(this.checkAllShaderExtrasToolStripMenuItem_Click);
            // 
            // generateCharacterFileSheetToolStripMenuItem
            // 
            this.generateCharacterFileSheetToolStripMenuItem.Name = "generateCharacterFileSheetToolStripMenuItem";
            this.generateCharacterFileSheetToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.generateCharacterFileSheetToolStripMenuItem.Text = "Generate Character FileSheet";
            this.generateCharacterFileSheetToolStripMenuItem.Click += new System.EventHandler(this.generateCharacterFileSheetToolStripMenuItem_Click_1);
            // 
            // pSOnrelTotrpToolStripMenuItem
            // 
            this.pSOnrelTotrpToolStripMenuItem.Name = "pSOnrelTotrpToolStripMenuItem";
            this.pSOnrelTotrpToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.pSOnrelTotrpToolStripMenuItem.Text = "PSO *n.rel to .trp";
            this.pSOnrelTotrpToolStripMenuItem.Click += new System.EventHandler(this.pSOnrelTotrpToolStripMenuItem_Click);
            // 
            // parsePSO2TextToolStripMenuItem
            // 
            this.parsePSO2TextToolStripMenuItem.Name = "parsePSO2TextToolStripMenuItem";
            this.parsePSO2TextToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.parsePSO2TextToolStripMenuItem.Text = "Parse PSO2 Text";
            this.parsePSO2TextToolStripMenuItem.Click += new System.EventHandler(this.parsePSO2TextToolStripMenuItem_Click);
            // 
            // parsePSO2TextFolderSelectToolStripMenuItem
            // 
            this.parsePSO2TextFolderSelectToolStripMenuItem.Name = "parsePSO2TextFolderSelectToolStripMenuItem";
            this.parsePSO2TextFolderSelectToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.parsePSO2TextFolderSelectToolStripMenuItem.Text = "Parse PSO2 Text (Folder Select)";
            this.parsePSO2TextFolderSelectToolStripMenuItem.Click += new System.EventHandler(this.parsePSO2TextFolderSelectToolStripMenuItem_Click);
            // 
            // convertTxtToPSO2TextToolStripMenuItem
            // 
            this.convertTxtToPSO2TextToolStripMenuItem.Name = "convertTxtToPSO2TextToolStripMenuItem";
            this.convertTxtToPSO2TextToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.convertTxtToPSO2TextToolStripMenuItem.Text = "Convert txt to PSO2 Text";
            this.convertTxtToPSO2TextToolStripMenuItem.Click += new System.EventHandler(this.convertTxtToPSO2TextToolStripMenuItem_Click);
            // 
            // convertTxtToPSO2TextFolderSelectToolStripMenuItem
            // 
            this.convertTxtToPSO2TextFolderSelectToolStripMenuItem.Name = "convertTxtToPSO2TextFolderSelectToolStripMenuItem";
            this.convertTxtToPSO2TextFolderSelectToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.convertTxtToPSO2TextFolderSelectToolStripMenuItem.Text = "Convert txt to PSO2 Text (Folder Select)";
            this.convertTxtToPSO2TextFolderSelectToolStripMenuItem.Click += new System.EventHandler(this.convertTxtToPSO2TextFolderSelectToolStripMenuItem_Click);
            // 
            // parseVTBFToTextToolStripMenuItem
            // 
            this.parseVTBFToTextToolStripMenuItem.Name = "parseVTBFToTextToolStripMenuItem";
            this.parseVTBFToTextToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.parseVTBFToTextToolStripMenuItem.Text = "Parse VTBF To Text";
            this.parseVTBFToTextToolStripMenuItem.Click += new System.EventHandler(this.parseVTBFToTextToolStripMenuItem_Click);
            // 
            // updateClassicPlayerAnimToNGSAnimToolStripMenuItem
            // 
            this.updateClassicPlayerAnimToNGSAnimToolStripMenuItem.Name = "updateClassicPlayerAnimToNGSAnimToolStripMenuItem";
            this.updateClassicPlayerAnimToNGSAnimToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.updateClassicPlayerAnimToNGSAnimToolStripMenuItem.Text = "Update classic player anim to NGS anim";
            this.updateClassicPlayerAnimToNGSAnimToolStripMenuItem.Click += new System.EventHandler(this.updateClassicPlayerAnimToNGSAnimToolStripMenuItem_Click);
            // 
            // legacyAqp2objObjExportToolStripMenuItem
            // 
            this.legacyAqp2objObjExportToolStripMenuItem.Name = "legacyAqp2objObjExportToolStripMenuItem";
            this.legacyAqp2objObjExportToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.legacyAqp2objObjExportToolStripMenuItem.Text = "(Legacy) aqp2obj obj export from current model";
            this.legacyAqp2objObjExportToolStripMenuItem.Click += new System.EventHandler(this.legacyAqp2objObjExportToolStripMenuItem_Click);
            // 
            // legacyAqp2objBatchExportToolStripMenuItem
            // 
            this.legacyAqp2objBatchExportToolStripMenuItem.Name = "legacyAqp2objBatchExportToolStripMenuItem";
            this.legacyAqp2objBatchExportToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.legacyAqp2objBatchExportToolStripMenuItem.Text = "(Legacy) aqp2obj batch export";
            this.legacyAqp2objBatchExportToolStripMenuItem.Click += new System.EventHandler(this.legacyAqp2objBatchExportToolStripMenuItem_Click);
            // 
            // legacyAqp2objObjImportToolStripMenuItem
            // 
            this.legacyAqp2objObjImportToolStripMenuItem.Name = "legacyAqp2objObjImportToolStripMenuItem";
            this.legacyAqp2objObjImportToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.legacyAqp2objObjImportToolStripMenuItem.Text = "(Legacy) aqp2obj obj import";
            this.legacyAqp2objObjImportToolStripMenuItem.Click += new System.EventHandler(this.legacyAqp2objObjImportToolStripMenuItem_Click);
            // 
            // prmEffectModelExportToolStripMenuItem
            // 
            this.prmEffectModelExportToolStripMenuItem.Name = "prmEffectModelExportToolStripMenuItem";
            this.prmEffectModelExportToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.prmEffectModelExportToolStripMenuItem.Text = "prm Effect Model Export";
            this.prmEffectModelExportToolStripMenuItem.Click += new System.EventHandler(this.prmEffectModelExportToolStripMenuItem_Click);
            // 
            // prmEffectFromModelToolStripMenuItem
            // 
            this.prmEffectFromModelToolStripMenuItem.Name = "prmEffectFromModelToolStripMenuItem";
            this.prmEffectFromModelToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.prmEffectFromModelToolStripMenuItem.Text = "prm Effect From Model";
            this.prmEffectFromModelToolStripMenuItem.Click += new System.EventHandler(this.prmEffectFromModelToolStripMenuItem_Click);
            // 
            // convertAnimationToAQMToolStripMenuItem
            // 
            this.convertAnimationToAQMToolStripMenuItem.Name = "convertAnimationToAQMToolStripMenuItem";
            this.convertAnimationToAQMToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.convertAnimationToAQMToolStripMenuItem.Text = "Convert Animation to AQM";
            this.convertAnimationToAQMToolStripMenuItem.Click += new System.EventHandler(this.convertAnimationToAQMToolStripMenuItem_Click);
            // 
            // spirefierToolStripMenuItem
            // 
            this.spirefierToolStripMenuItem.Name = "spirefierToolStripMenuItem";
            this.spirefierToolStripMenuItem.Size = new System.Drawing.Size(329, 22);
            this.spirefierToolStripMenuItem.Text = "Spirefier";
            this.spirefierToolStripMenuItem.Click += new System.EventHandler(this.spirefierToolStripMenuItem_Click);
            // 
            // debugToolStripMenuItem
            // 
            this.debugToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.readBonesToolStripMenuItem,
            this.exportToGLTFToolStripMenuItem,
            this.importFromGLTFToolStripMenuItem,
            this.computeTangentSpaceTestToolStripMenuItem,
            this.cloneBoneTransformsToolStripMenuItem,
            this.testVTXEToolStripMenuItem,
            this.dumpNOF0ToolStripMenuItem,
            this.readBTIToolStripMenuItem,
            this.readMagIndicesToolStripMenuItem,
            this.readCMOToolStripMenuItem,
            this.dumpFigEffectTypesToolStripMenuItem,
            this.readCMXToolStripMenuItem,
            this.readFIGToolStripMenuItem,
            this.dumpFigShapesToolStripMenuItem,
            this.readLacToolStripMenuItem,
            this.readLacToolStripMenuItem1});
            this.debugToolStripMenuItem.Name = "debugToolStripMenuItem";
            this.debugToolStripMenuItem.Size = new System.Drawing.Size(54, 20);
            this.debugToolStripMenuItem.Text = "Debug";
            // 
            // readBonesToolStripMenuItem
            // 
            this.readBonesToolStripMenuItem.Name = "readBonesToolStripMenuItem";
            this.readBonesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.readBonesToolStripMenuItem.Text = "Read Bones";
            this.readBonesToolStripMenuItem.Click += new System.EventHandler(this.readBonesToolStripMenuItem_Click);
            // 
            // exportToGLTFToolStripMenuItem
            // 
            this.exportToGLTFToolStripMenuItem.Name = "exportToGLTFToolStripMenuItem";
            this.exportToGLTFToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.exportToGLTFToolStripMenuItem.Text = "Export To GLTF";
            this.exportToGLTFToolStripMenuItem.Click += new System.EventHandler(this.exportToGLTFToolStripMenuItem_Click);
            // 
            // importFromGLTFToolStripMenuItem
            // 
            this.importFromGLTFToolStripMenuItem.Name = "importFromGLTFToolStripMenuItem";
            this.importFromGLTFToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.importFromGLTFToolStripMenuItem.Text = "Import From GLTF";
            this.importFromGLTFToolStripMenuItem.Click += new System.EventHandler(this.importFromGLTFToolStripMenuItem_Click);
            // 
            // computeTangentSpaceTestToolStripMenuItem
            // 
            this.computeTangentSpaceTestToolStripMenuItem.Name = "computeTangentSpaceTestToolStripMenuItem";
            this.computeTangentSpaceTestToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.computeTangentSpaceTestToolStripMenuItem.Text = "Compute Tangent Space Test";
            this.computeTangentSpaceTestToolStripMenuItem.Click += new System.EventHandler(this.computeTangentSpaceTestToolStripMenuItem_Click);
            // 
            // cloneBoneTransformsToolStripMenuItem
            // 
            this.cloneBoneTransformsToolStripMenuItem.Name = "cloneBoneTransformsToolStripMenuItem";
            this.cloneBoneTransformsToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.cloneBoneTransformsToolStripMenuItem.Text = "Clone Bone Transforms";
            this.cloneBoneTransformsToolStripMenuItem.Click += new System.EventHandler(this.cloneBoneTransformsToolStripMenuItem_Click);
            // 
            // testVTXEToolStripMenuItem
            // 
            this.testVTXEToolStripMenuItem.Name = "testVTXEToolStripMenuItem";
            this.testVTXEToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.testVTXEToolStripMenuItem.Text = "TestVTXE";
            this.testVTXEToolStripMenuItem.Click += new System.EventHandler(this.testVTXEToolStripMenuItem_Click);
            // 
            // dumpNOF0ToolStripMenuItem
            // 
            this.dumpNOF0ToolStripMenuItem.Name = "dumpNOF0ToolStripMenuItem";
            this.dumpNOF0ToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.dumpNOF0ToolStripMenuItem.Text = "DumpNOF0";
            this.dumpNOF0ToolStripMenuItem.Click += new System.EventHandler(this.dumpNOF0ToolStripMenuItem_Click);
            // 
            // readBTIToolStripMenuItem
            // 
            this.readBTIToolStripMenuItem.Name = "readBTIToolStripMenuItem";
            this.readBTIToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.readBTIToolStripMenuItem.Text = "ReadBTI";
            this.readBTIToolStripMenuItem.Click += new System.EventHandler(this.readBTIToolStripMenuItem_Click);
            // 
            // readMagIndicesToolStripMenuItem
            // 
            this.readMagIndicesToolStripMenuItem.Name = "readMagIndicesToolStripMenuItem";
            this.readMagIndicesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.readMagIndicesToolStripMenuItem.Text = "ReadMagIndices";
            this.readMagIndicesToolStripMenuItem.Click += new System.EventHandler(this.readMagIndicesToolStripMenuItem_Click);
            // 
            // readCMOToolStripMenuItem
            // 
            this.readCMOToolStripMenuItem.Name = "readCMOToolStripMenuItem";
            this.readCMOToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.readCMOToolStripMenuItem.Text = "ReadCMO";
            this.readCMOToolStripMenuItem.Click += new System.EventHandler(this.readCMOToolStripMenuItem_Click);
            // 
            // dumpFigEffectTypesToolStripMenuItem
            // 
            this.dumpFigEffectTypesToolStripMenuItem.Name = "dumpFigEffectTypesToolStripMenuItem";
            this.dumpFigEffectTypesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.dumpFigEffectTypesToolStripMenuItem.Text = "DumpFigEffectTypes";
            this.dumpFigEffectTypesToolStripMenuItem.Click += new System.EventHandler(this.dumpFigEffectTypesToolStripMenuItem_Click);
            // 
            // readCMXToolStripMenuItem
            // 
            this.readCMXToolStripMenuItem.Name = "readCMXToolStripMenuItem";
            this.readCMXToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.readCMXToolStripMenuItem.Text = "ReadCMX";
            this.readCMXToolStripMenuItem.Click += new System.EventHandler(this.readCMXToolStripMenuItem_Click);
            // 
            // readFIGToolStripMenuItem
            // 
            this.readFIGToolStripMenuItem.Name = "readFIGToolStripMenuItem";
            this.readFIGToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.readFIGToolStripMenuItem.Text = "ReadFIG";
            this.readFIGToolStripMenuItem.Click += new System.EventHandler(this.readFIGToolStripMenuItem_Click);
            // 
            // dumpFigShapesToolStripMenuItem
            // 
            this.dumpFigShapesToolStripMenuItem.Name = "dumpFigShapesToolStripMenuItem";
            this.dumpFigShapesToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.dumpFigShapesToolStripMenuItem.Text = "DumpFigShapes";
            this.dumpFigShapesToolStripMenuItem.Click += new System.EventHandler(this.dumpFigShapesToolStripMenuItem_Click);
            // 
            // readLacToolStripMenuItem
            // 
            this.readLacToolStripMenuItem.Name = "readLacToolStripMenuItem";
            this.readLacToolStripMenuItem.Size = new System.Drawing.Size(226, 22);
            this.readLacToolStripMenuItem.Text = "ReadRebootLac";
            this.readLacToolStripMenuItem.Click += new System.EventHandler(this.readRebootLacToolStripMenuItem_Click);
            // 
            // filePanel
            // 
            this.filePanel.AutoSize = true;
            this.filePanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.filePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filePanel.Location = new System.Drawing.Point(0, 24);
            this.filePanel.Name = "filePanel";
            this.filePanel.Size = new System.Drawing.Size(384, 256);
            this.filePanel.TabIndex = 1;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 256);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // readLacToolStripMenuItem1
            // 
            this.readLacToolStripMenuItem1.Name = "readLacToolStripMenuItem1";
            this.readLacToolStripMenuItem1.Size = new System.Drawing.Size(226, 22);
            this.readLacToolStripMenuItem1.Text = "ReadLac";
            this.readLacToolStripMenuItem1.Click += new System.EventHandler(this.readLacToolStripMenuItem1_Click);
            // 
            // AquaModelTool
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 280);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.filePanel);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "AquaModelTool";
            this.Text = "Aqua Model Tool";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.Panel filePanel;
        private System.Windows.Forms.ToolStripMenuItem extraToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem averageNormalsOnSharedPositionVerticesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem debugToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readBonesToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.ToolStripMenuItem exportToGLTFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importFromGLTFToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem generateCharacterFileSheetToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateClassicPlayerAnimToNGSAnimToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pSOnrelTotrpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parsePSO2TextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parseVTBFToTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem batchParsePSO2SetToTextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem getToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checkAllShaderExtrasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem parsePSO2TextFolderSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem computeTangentSpaceTestToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cloneBoneTransformsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legacyAqp2objObjExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legacyAqp2objObjImportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem testVTXEToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertTxtToPSO2TextToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertTxtToPSO2TextFolderSelectToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpNOF0ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readBTIToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prmEffectModelExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem prmEffectFromModelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readMagIndicesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem convertAnimationToAQMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readCMOToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem legacyAqp2objBatchExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpFigEffectTypesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem spirefierToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readCMXToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readFIGToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dumpFigShapesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readLacToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem readLacToolStripMenuItem1;
    }
}

