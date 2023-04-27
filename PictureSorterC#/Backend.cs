using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PictureSorterC_
{
    public partial class Form1
    {
        public void LoadDataGridViewImages(string folder)
        {

            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(100, 100);
            listView1.View = View.LargeIcon;
            imageList.ColorDepth = ColorDepth.Depth32Bit;

            double POURCENTAGE_IMAGE = 0.03;

            int maxSize = 0;
            int maxSizeReduite = 0;
            string[] fileNames = Directory.GetFiles(folder);
            foreach (string fileName in fileNames)
            {
                Image image = Image.FromFile(fileName);
                maxSize = Math.Max(image.Width, image.Height);
                maxSizeReduite = Convert.ToInt32(maxSize * POURCENTAGE_IMAGE);
                imageList.Images.Add(image.GetThumbnailImage(maxSizeReduite, maxSizeReduite, null, IntPtr.Zero));
                image.Dispose();
                ListViewItem item = new ListViewItem(fileName, imageList.Images.Count - 1);
                listView1.Items.Add(item);
            }

            imageList.ImageSize = new Size(maxSizeReduite, maxSizeReduite);

            listView1.LargeImageList = imageList;
            // Afficher les images dans le ListView


        }

        private void CheckIfImportButtonIsEnabled()
        {
            if (SDFolder != "" && WorkingFolder != "" && ComboBoxChoixModeDeplacement.SelectedIndex >= 0)
            {
                ButtonStartImport.Enabled = true;
            }
        }

        public void LoadImageViewer()
        {
            //Load image from targetDirectory + jpg at index .
            pictureBox1.Image.Dispose();
            string filename = Directory.GetFiles(Path.Combine(WorkingFolder, "JPG"))[IndexOfSelectedImage];
            pictureBox1.Image = Image.FromFile(filename);


            PropertyItem[] property = pictureBox1.Image.PropertyItems;
            LabelPictureName.Text = "Name : " + Path.GetFileNameWithoutExtension(filename);


            const int DATE_TAKEN_TAG = 0x9003;
            var propItem = pictureBox1.Image.GetPropertyItem(DATE_TAKEN_TAG);

            var dateValue = System.Text.Encoding.ASCII.GetString(propItem.Value).TrimEnd('\0');
            var dateTaken = DateTime.ParseExact(dateValue, "yyyy:MM:dd HH:mm:ss", null);
            var dateTakenFr = dateTaken.ToString("dd/MM/yyyy HH:mm:ss");
            LabelPictureDate.Text = "Date de prise de vue : " + dateTakenFr;

            LabelPictureSizeInPixel.Text = "Résolution : " + pictureBox1.Image.Width + "x" + pictureBox1.Image.Height;

            LabelPictureISO.Text = "ISO : " + BitConverter.ToUInt16(pictureBox1.Image.GetPropertyItem(0x8827).Value, 0).ToString();

            byte[] spencoded = pictureBox1.Image.GetPropertyItem(0x829A).Value;
            int numerator = BitConverter.ToInt32(spencoded, 0);
            int denominator = BitConverter.ToInt32(spencoded, 4);
            LabelPictureShutterSpeed.Text = "Temps d'ouverture : " + numerator + "/" + denominator;

            var apperture = pictureBox1.Image.GetPropertyItem(0x829D).Value;
            float numerator2 = BitConverter.ToInt32(apperture, 0);
            float denominator2 = BitConverter.ToInt32(apperture, 4);
            LabelPictureAperture.Text = "Ouverture : f/" + numerator2 / denominator2;

            var lensLenght = pictureBox1.Image.GetPropertyItem(0x920A).Value;
            float numerator3 = BitConverter.ToInt32(lensLenght, 0);
            LabelPictureLensLenght.Text = "Longueur focale : " + numerator3 + "mm";
        }

        private void ChangeIndexOfSelectedItem(int numberToAdd)
        {
            int newIndex = IndexOfSelectedImage + numberToAdd;
            if (newIndex < 0 || newIndex >= Directory.GetFiles(Path.Combine(WorkingFolder, "JPG")).Length)
            {
                return;
            }

            IndexOfSelectedImage = newIndex;
        }
    }
}
