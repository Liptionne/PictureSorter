using System.Diagnostics;
using System.Drawing.Imaging;
using System.Net;
using System.Runtime.ConstrainedExecution;
using System.Windows.Forms;

namespace PictureSorterC_
{
    public partial class Form1 : Form
    {
        string SDFolder = "";
        string WorkingFolder = "";
        string AdditionnalCopyFolder = "";

        List<string> extensionsRaw;
        List<string> extensionsImage;

        int IndexOfSelectedImage = 0;

        List<string> ImagesToDelete;
        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;

            LabelAdditionnalFolderPath.Text = string.Empty;
            LabelPathToTargetFolder.Text = string.Empty;
            LabelPathToFolder.Text = string.Empty;
            ButtonStartImport.Enabled = false;

            ImagesToDelete = new List<string>();

            extensionsRaw = new List<string> { ".NEF", ".CR2", ".ARW", ".ORF", ".RW2", ".DNG", ".CR3" };
            extensionsImage = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".JPG" };

        }


        public string SelectFolderWithFileDialog()
        {
            string folderPath = "";

            using (var folderBrowserDialog = new FolderBrowserDialog())
            {
                DialogResult result = folderBrowserDialog.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(folderBrowserDialog.SelectedPath))
                {
                    folderPath = folderBrowserDialog.SelectedPath;
                }
            }

            return folderPath;
        }
              
       



        private void ButtonChooseFolder_Click(object sender, EventArgs e)
        {
            SDFolder = SelectFolderWithFileDialog();
            LabelPathToFolder.Text = Path.GetFileName(SDFolder);

            CheckIfImportButtonIsEnabled();
        }

        private void ButtonChooseTargetFolder_Click(object sender, EventArgs e)
        {
            WorkingFolder = SelectFolderWithFileDialog();
            LabelPathToTargetFolder.Text = Path.GetFileName(WorkingFolder);

            CheckIfImportButtonIsEnabled();
        }

        private void ButtonChooseAdditionnalFolder_Click(object sender, EventArgs e)
        {
            AdditionnalCopyFolder = SelectFolderWithFileDialog();
            LabelAdditionnalFolderPath.Text = Path.GetFileName(AdditionnalCopyFolder);
        }

        private void ButtonStartImport_Click(object sender, EventArgs e)
        {
            MoveFiles();
        }

        private void ComboBoxChoixModeDeplacement_SelectedIndexChanged(object sender, EventArgs e)
        {
            CheckIfImportButtonIsEnabled();
        }

        private void visualisationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            listView1.Visible = false;
            pictureBox1.Visible = true;
            panel1.Visible = false;
            panel3.Visible = true;
            if (listView1.SelectedIndices.Count > 0)
            {
                IndexOfSelectedImage = listView1.SelectedIndices[0];
            }
            LoadImageViewer();
        }

        private void modeGrilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;

            panel1.Visible = true;
            listView1.Visible = true;

        }        

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                //fleche de droite
                ChangeIndexOfSelectedItem(1);
                LoadImageViewer();
            }

            if (e.KeyCode == Keys.Left)
            {
                //fleche de gauche
                ChangeIndexOfSelectedItem(-1);
                LoadImageViewer();
            }
        }

        private void DeleteImageButton_Click(object sender, EventArgs e)
        {
            DeleteImageAtIndex(IndexOfSelectedImage);

            LoadImageViewer();
        }       

        private void button1_Click(object sender, EventArgs e)
        {
            DeleteRaw();
        }
    }
}

/*

TODO Travailler l'UI et l'UX (grille des images, visualiseur d'images, infos sur l'image en visualisation)

TODO Ajouter une logique de tri des images (en fonctionn de critères : ISO? ouverture, date, nom, lieu, taille, résolution)

TODO Ajouter des tests automatiques au projet

TODO Méthode de renommage des fichiers (peut etre des REGEX ?)

TODO Gestion d'erreurs

*/ 