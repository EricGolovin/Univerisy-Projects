using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NET_lab03
{
    public partial class Form1 : Form
    {
        private static Image image1 = Image.FromFile("C:/Users/ericg/source/repos/EricGolovin/Univerisy-Projects/net-subject/NET-lab03/NET-lab03/resources/dotnet.png");
        private static Bitmap bitmap1;
        public Form1()
        {
            InitializeComponent();
        }

        private void InitializeBitmap()
        {
            try
            {

                bitmap1 = Resize(image1, 500, 500);
                pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;
                pictureBox1.Image = bitmap1;
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("There was an error." + "Check the path to the bitmap.");
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            InitializeBitmap();
            resizePictureBox(100, 100);
            rotateImageBy(RotateFlipType.Rotate90FlipNone);
            Image newImage = bitmap1;
            Graphics gf = Graphics.FromImage(newImage);

            gf.DrawEllipse(new Pen(Color.Red, 10), new Rectangle(pictureBox1.Width / 4, pictureBox1.Height/ 4, pictureBox1.Width / 2, pictureBox1.Height / 2));

            pictureBox1.Image = newImage;
        }

        private void rotateImageBy(RotateFlipType rotateFlipType)
        {
            if (bitmap1 != null)
            {
                bitmap1.RotateFlip(rotateFlipType);
                pictureBox1.Image = bitmap1;
            }
        }
        private void resizePictureBox(int width, int height)
        {
            pictureBox1.Width = width;
            pictureBox1.Height = height;
            pictureBox1.Refresh();
        }
        private static Bitmap Resize(Image image, int width, int height)
        {

            var destRect = new Rectangle(0, 0, width, height);
            var destImage = new Bitmap(width, height);

            destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);

            using (var graphics = Graphics.FromImage(destImage))
            {
                graphics.CompositingMode = CompositingMode.SourceCopy;
                graphics.CompositingQuality = CompositingQuality.HighQuality;
                graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
                graphics.SmoothingMode = SmoothingMode.HighQuality;
                graphics.PixelOffsetMode = PixelOffsetMode.HighQuality;

                using (var wrapMode = new ImageAttributes())
                {
                    wrapMode.SetWrapMode(WrapMode.TileFlipXY);
                    graphics.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                }
            }

            return destImage;
        }
    }
}
