namespace PictureSorterC_
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            fichierToolStripMenuItem = new ToolStripMenuItem();
            editionToolStripMenuItem = new ToolStripMenuItem();
            optionsToolStripMenuItem = new ToolStripMenuItem();
            panel1 = new Panel();
            ButtonStartImport = new Button();
            CheckBoxSeparateFolders = new CheckBox();
            ButtonChooseAdditionnalFolder = new Button();
            LabelAdditionnalFolderPath = new Label();
            LabelAdditionalFolder = new Label();
            ButtonChooseTargetFolder = new Button();
            LabelPathToTargetFolder = new Label();
            LabelTargetFolder = new Label();
            ComboBoxChoixModeDeplacement = new ComboBox();
            LabelChoixModeDeplacement = new Label();
            ButtonChooseFolder = new Button();
            LabelPathToFolder = new Label();
            LabelFolderName = new Label();
            panel2 = new Panel();
            dataGridView1 = new DataGridView();
            menuStrip1.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { fichierToolStripMenuItem, editionToolStripMenuItem, optionsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1315, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // fichierToolStripMenuItem
            // 
            fichierToolStripMenuItem.Name = "fichierToolStripMenuItem";
            fichierToolStripMenuItem.Size = new Size(66, 24);
            fichierToolStripMenuItem.Text = "Fichier";
            // 
            // editionToolStripMenuItem
            // 
            editionToolStripMenuItem.Name = "editionToolStripMenuItem";
            editionToolStripMenuItem.Size = new Size(70, 24);
            editionToolStripMenuItem.Text = "Edition";
            // 
            // optionsToolStripMenuItem
            // 
            optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            optionsToolStripMenuItem.Size = new Size(75, 24);
            optionsToolStripMenuItem.Text = "Options";
            // 
            // panel1
            // 
            panel1.Controls.Add(ButtonStartImport);
            panel1.Controls.Add(CheckBoxSeparateFolders);
            panel1.Controls.Add(ButtonChooseAdditionnalFolder);
            panel1.Controls.Add(LabelAdditionnalFolderPath);
            panel1.Controls.Add(LabelAdditionalFolder);
            panel1.Controls.Add(ButtonChooseTargetFolder);
            panel1.Controls.Add(LabelPathToTargetFolder);
            panel1.Controls.Add(LabelTargetFolder);
            panel1.Controls.Add(ComboBoxChoixModeDeplacement);
            panel1.Controls.Add(LabelChoixModeDeplacement);
            panel1.Controls.Add(ButtonChooseFolder);
            panel1.Controls.Add(LabelPathToFolder);
            panel1.Controls.Add(LabelFolderName);
            panel1.Location = new Point(0, 31);
            panel1.Name = "panel1";
            panel1.Size = new Size(346, 698);
            panel1.TabIndex = 1;
            // 
            // ButtonStartImport
            // 
            ButtonStartImport.FlatStyle = FlatStyle.Popup;
            ButtonStartImport.Font = new Font("Segoe UI", 15F, FontStyle.Regular, GraphicsUnit.Point);
            ButtonStartImport.Location = new Point(107, 568);
            ButtonStartImport.Name = "ButtonStartImport";
            ButtonStartImport.Size = new Size(177, 42);
            ButtonStartImport.TabIndex = 25;
            ButtonStartImport.Text = "IMPORTER";
            ButtonStartImport.UseVisualStyleBackColor = true;
            // 
            // CheckBoxSeparateFolders
            // 
            CheckBoxSeparateFolders.AutoSize = true;
            CheckBoxSeparateFolders.Location = new Point(12, 292);
            CheckBoxSeparateFolders.Name = "CheckBoxSeparateFolders";
            CheckBoxSeparateFolders.Size = new Size(272, 24);
            CheckBoxSeparateFolders.TabIndex = 24;
            CheckBoxSeparateFolders.Text = "Séparer en 2 dossiers (RAW et JPG) ?";
            CheckBoxSeparateFolders.UseVisualStyleBackColor = true;
            // 
            // ButtonChooseAdditionnalFolder
            // 
            ButtonChooseAdditionnalFolder.Location = new Point(12, 246);
            ButtonChooseAdditionnalFolder.Name = "ButtonChooseAdditionnalFolder";
            ButtonChooseAdditionnalFolder.Size = new Size(237, 29);
            ButtonChooseAdditionnalFolder.TabIndex = 23;
            ButtonChooseAdditionnalFolder.Text = "Choisir dossier supplémentaire";
            ButtonChooseAdditionnalFolder.UseVisualStyleBackColor = true;
            // 
            // LabelAdditionnalFolderPath
            // 
            LabelAdditionnalFolderPath.AutoSize = true;
            LabelAdditionnalFolderPath.Location = new Point(265, 212);
            LabelAdditionnalFolderPath.Name = "LabelAdditionnalFolderPath";
            LabelAdditionnalFolderPath.Size = new Size(0, 20);
            LabelAdditionnalFolderPath.TabIndex = 22;
            // 
            // LabelAdditionalFolder
            // 
            LabelAdditionalFolder.AutoSize = true;
            LabelAdditionalFolder.Location = new Point(12, 212);
            LabelAdditionalFolder.Name = "LabelAdditionalFolder";
            LabelAdditionalFolder.Size = new Size(247, 20);
            LabelAdditionalFolder.TabIndex = 21;
            LabelAdditionalFolder.Text = "Dossier supplémentaire de recopie :";
            // 
            // ButtonChooseTargetFolder
            // 
            ButtonChooseTargetFolder.Location = new Point(12, 165);
            ButtonChooseTargetFolder.Name = "ButtonChooseTargetFolder";
            ButtonChooseTargetFolder.Size = new Size(237, 29);
            ButtonChooseTargetFolder.TabIndex = 20;
            ButtonChooseTargetFolder.Text = "Choisir le dossier où déplacer";
            ButtonChooseTargetFolder.UseVisualStyleBackColor = true;
            // 
            // LabelPathToTargetFolder
            // 
            LabelPathToTargetFolder.AutoSize = true;
            LabelPathToTargetFolder.Location = new Point(166, 130);
            LabelPathToTargetFolder.Name = "LabelPathToTargetFolder";
            LabelPathToTargetFolder.Size = new Size(0, 20);
            LabelPathToTargetFolder.TabIndex = 19;
            // 
            // LabelTargetFolder
            // 
            LabelTargetFolder.AutoSize = true;
            LabelTargetFolder.Location = new Point(12, 130);
            LabelTargetFolder.Name = "LabelTargetFolder";
            LabelTargetFolder.Size = new Size(148, 20);
            LabelTargetFolder.TabIndex = 18;
            LabelTargetFolder.Text = "Dossier où déplacer :";
            // 
            // ComboBoxChoixModeDeplacement
            // 
            ComboBoxChoixModeDeplacement.DropDownStyle = ComboBoxStyle.DropDownList;
            ComboBoxChoixModeDeplacement.FormattingEnabled = true;
            ComboBoxChoixModeDeplacement.Items.AddRange(new object[] { "Déplacer", "Copier", "Copier et déplacer" });
            ComboBoxChoixModeDeplacement.Location = new Point(183, 93);
            ComboBoxChoixModeDeplacement.Name = "ComboBoxChoixModeDeplacement";
            ComboBoxChoixModeDeplacement.Size = new Size(151, 28);
            ComboBoxChoixModeDeplacement.TabIndex = 17;
            // 
            // LabelChoixModeDeplacement
            // 
            LabelChoixModeDeplacement.AutoSize = true;
            LabelChoixModeDeplacement.Location = new Point(12, 96);
            LabelChoixModeDeplacement.Name = "LabelChoixModeDeplacement";
            LabelChoixModeDeplacement.Size = new Size(167, 20);
            LabelChoixModeDeplacement.TabIndex = 16;
            LabelChoixModeDeplacement.Text = "Mode de déplacement :";
            // 
            // ButtonChooseFolder
            // 
            ButtonChooseFolder.Location = new Point(12, 47);
            ButtonChooseFolder.Name = "ButtonChooseFolder";
            ButtonChooseFolder.Size = new Size(237, 29);
            ButtonChooseFolder.TabIndex = 15;
            ButtonChooseFolder.Text = "Choisir mon dossier";
            ButtonChooseFolder.UseVisualStyleBackColor = true;
            // 
            // LabelPathToFolder
            // 
            LabelPathToFolder.AutoSize = true;
            LabelPathToFolder.Location = new Point(151, 24);
            LabelPathToFolder.Name = "LabelPathToFolder";
            LabelPathToFolder.Size = new Size(0, 20);
            LabelPathToFolder.TabIndex = 14;
            // 
            // LabelFolderName
            // 
            LabelFolderName.AutoSize = true;
            LabelFolderName.Location = new Point(12, 14);
            LabelFolderName.Name = "LabelFolderName";
            LabelFolderName.Size = new Size(121, 20);
            LabelFolderName.TabIndex = 13;
            LabelFolderName.Text = "Nom du dossier :";
            // 
            // panel2
            // 
            panel2.Controls.Add(dataGridView1);
            panel2.Location = new Point(352, 31);
            panel2.Name = "panel2";
            panel2.Size = new Size(963, 698);
            panel2.TabIndex = 2;
            // 
            // dataGridView1
            // 
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.BackgroundColor = SystemColors.ActiveBorder;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(20, 14);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 29;
            dataGridView1.Size = new Size(931, 553);
            dataGridView1.TabIndex = 0;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1315, 727);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "Form1";
            Text = "Form1";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private MenuStrip menuStrip1;
        private ToolStripMenuItem fichierToolStripMenuItem;
        private ToolStripMenuItem editionToolStripMenuItem;
        private ToolStripMenuItem optionsToolStripMenuItem;
        private Panel panel1;
        private CheckBox CheckBoxSeparateFolders;
        private Button ButtonChooseAdditionnalFolder;
        private Label LabelAdditionnalFolderPath;
        private Label LabelAdditionalFolder;
        private Button ButtonChooseTargetFolder;
        private Label LabelPathToTargetFolder;
        private Label LabelTargetFolder;
        private ComboBox ComboBoxChoixModeDeplacement;
        private Label LabelChoixModeDeplacement;
        private Button ButtonChooseFolder;
        private Label LabelPathToFolder;
        private Label LabelFolderName;
        private Button ButtonStartImport;
        private Panel panel2;
        private DataGridView dataGridView1;
    }
}