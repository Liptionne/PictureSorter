using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PictureSorterC_
{
    public partial class Form1
    {
        public void LoadDataGridViewImages(string folder)
        {
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(180, 180);
            listView1.View = View.LargeIcon;
            imageList.ColorDepth = ColorDepth.Depth32Bit;
          
            int maxSize = 180;
            string[] fileNames = Directory.GetFiles(folder);
            foreach (string fileName in fileNames)
            {
               
                Image image = Image.FromFile(fileName);

                if (image.PropertyIdList.Contains(0x0112)) // 0x0112 est l'identifiant de la propriété Orientation
                {
                    int orientation = (int)image.GetPropertyItem(0x0112).Value[0];
                    Debug.WriteLine("orientation = " + orientation);
                    if (orientation == 6) // Si l'orientation est 6, l'image doit être pivotée de 90 degrés dans le sens horaire
                    {
                        image.RotateFlip(RotateFlipType.Rotate90FlipNone);
                    }
                    if (orientation == 8) // Si l'orientation est 6, l'image doit être pivotée de 90 degrés dans le sens horaire
                    {
                        image.RotateFlip(RotateFlipType.Rotate270FlipNone);
                    }
                }

                // Calculate new size based on maximum allowed size
                var ratioX = (double)maxSize / image.Width;
                var ratioY = (double)maxSize / image.Height;
                var ratio = Math.Min(ratioX, ratioY);
                var newWidth = (int)(image.Width * ratio);
                var newHeight = (int)(image.Height * ratio);

                // Create a new bitmap of the desired size
                var newImage = new Bitmap(maxSize, maxSize, PixelFormat.Format32bppArgb);

                // Draw the resized image onto the new bitmap with padding to fill any empty space
                using (var graphics = Graphics.FromImage(newImage))
                {
                    graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                    graphics.Clear(Color.Transparent);
                    graphics.DrawImage(image, (maxSize - newWidth) / 2, (maxSize - newHeight) / 2, newWidth, newHeight);
                }

                image.Dispose();
                imageList.Images.Add(newImage);



                ListViewItem item = new ListViewItem(fileName, imageList.Images.Count-1);
                listView1.Items.Add(item);
                

                
            }

            listView1.LargeImageList = imageList;

        }

        private void CheckIfImportButtonIsEnabled()
        {
            if (SDFolder != "" && WorkingFolder != "" && ComboBoxChoixModeDeplacement.SelectedIndex >= 0)
            {
                ButtonStartImport.Enabled = true;
            }
        }

        public void LoadImageViewer(string pathToFolder)
        {
         
            //unload previous the image
            pictureBox1.Image.Dispose();

            //load the new image
            string filename = Directory.GetFiles(Path.Combine(pathToFolder, "JPG"))[IndexOfSelectedImage];
            pictureBox1.Image = Image.FromFile(filename);

            LoadPicturesproperties(filename);

            
        }

        private void LoadPicturesproperties(string filename)
        {

            const int DATE_TAKEN_TAG = 0x9003;
            const int ISO_FLAG = 0x8827;
            const int EXPOSITION_TIME_FLAG = 0x829A;
            const int APPERTURE_FLAG = 0x829D;
            const int FOCAL_LENGHT_FLAG = 0x920A;

            PropertyItem[] property = pictureBox1.Image.PropertyItems;

            LabelPictureName.Text = "Name : " + Path.GetFileNameWithoutExtension(filename);


            var DateOfPictureBits = pictureBox1.Image.GetPropertyItem(DATE_TAKEN_TAG);
            var StringValueOfDate = Encoding.ASCII.GetString(DateOfPictureBits.Value).TrimEnd('\0');
            var dateToDisplay = DateTime.ParseExact(StringValueOfDate, "yyyy:MM:dd HH:mm:ss", null);                         
           

            byte[] spencoded = pictureBox1.Image.GetPropertyItem(EXPOSITION_TIME_FLAG).Value;
            int numerator = BitConverter.ToInt32(spencoded, 0);
            int denominator = BitConverter.ToInt32(spencoded, 4);

            var apperture = pictureBox1.Image.GetPropertyItem(APPERTURE_FLAG).Value;
            float numerator2 = BitConverter.ToInt32(apperture, 0);
            float denominator2 = BitConverter.ToInt32(apperture, 4);

            var lensLenght = pictureBox1.Image.GetPropertyItem(FOCAL_LENGHT_FLAG).Value;
            float numerator3 = BitConverter.ToInt32(lensLenght, 0);

            LabelPictureDate.Text = "Date de prise de vue : " + dateToDisplay.ToString("dd/MM/yyyy HH:mm:ss");

            LabelPictureSizeInPixel.Text = "Résolution : " + pictureBox1.Image.Width + "x" + pictureBox1.Image.Height;

            LabelPictureISO.Text = "ISO : " + BitConverter.ToUInt16(pictureBox1.Image.GetPropertyItem(ISO_FLAG).Value, 0).ToString();

            LabelPictureShutterSpeed.Text = "Temps d'ouverture : " + numerator + "/" + denominator;

            LabelPictureAperture.Text = "Ouverture : f/" + numerator2 / denominator2;

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
    }
}
