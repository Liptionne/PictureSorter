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

        const int INCREASE_INDEX_VALUE = 1;
        const int DECREASE_INDEX_VALUE = -1;
        public Form1()
        {
            InitializeComponent();

            this.KeyPreview = true;
            this.Focus();

            LabelAdditionnalFolderPath.Text = string.Empty;
            LabelPathToTargetFolder.Text = string.Empty;
            LabelPathToFolder.Text = string.Empty;
            ButtonStartImport.Enabled = false;

            ImagesToDelete = new List<string>();

            extensionsRaw = new List<string> { ".NEF", ".CR2", ".ARW", ".ORF", ".RW2", ".DNG", ".CR3" };
            extensionsImage = new List<string> { ".jpg", ".jpeg", ".png", ".gif", ".bmp", ".tiff", ".JPG" };

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
            LoadImageViewer(WorkingFolder);
        }

        private void modeGrilleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = false;

            panel1.Visible = true;
            listView1.Visible = true;

        }
        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            
            if(keyData == Keys.Left)
            {
                ChangeIndexOfSelectedItem(DECREASE_INDEX_VALUE);
                LoadImageViewer(WorkingFolder);
                return true;
            }
            if(keyData == Keys.Right)
            {
                ChangeIndexOfSelectedItem(INCREASE_INDEX_VALUE);
                LoadImageViewer(WorkingFolder);
                return true;
            }

            // Sinon, nous appelons la méthode ProcessCmdKey de la classe de base pour traiter les autres touches
            return base.ProcessCmdKey(ref msg, keyData);
        }

        private void DeleteImageButton_Click(object sender, EventArgs e)
        {
            DeleteImageAtIndex(IndexOfSelectedImage);

            LoadImageViewer(WorkingFolder);
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