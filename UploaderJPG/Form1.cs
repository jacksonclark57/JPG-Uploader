using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UploaderJPG
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }
        public void PixelGenerator()
        {
           
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (pictureBox1 == null)
            {
                throw new Exception("you did not enter a picture to compute !!!");
            }
            else
            {
                Bitmap bmpImage = (Bitmap)pictureBox1.Image;
                Bitmap blueOnly = new Bitmap(bmpImage.Width ,bmpImage.Height);

                Color colCurrent;
                string pixelinfo = "";
                int currentPixel = 0;
                int bluePix = 0;

                double maxPixels = bmpImage.Height * bmpImage.Width;

                progressBar1.Maximum =(int)maxPixels;

                progressBar1.Value = 0;

                //lsbColorData.Items.Clear();

                for (int y = 0; y < bmpImage.Height; y++)
                {
                    for (int x = 0; x < bmpImage.Width; x++)
                    {
                        colCurrent = bmpImage.GetPixel(x, y);

                       // pixelinfo = string.Format("Pixel {5:00000} coord = [{0:00},{1:00}] - Color RGB =  [{2:000},{3:000},{4:000}])", x, y, colCurrent.R, colCurrent.G, colCurrent.B, currentPixel);

                        currentPixel++;

                        progressBar1.Value = currentPixel;

                        //lsbColorData.Items.Add(pixelinfo);

                        if (colCurrent.R < 80 && colCurrent.G < 190 && colCurrent.B < 255)
                        {
                            bluePix++;
                            blueOnly.SetPixel(x, y,colCurrent);
                        }


                    }
                    lblProgress.Text = string.Format("{0}/{1} Pixels Processed", currentPixel, maxPixels);



                }

                pictureBox1.Image = bmpImage;

                picRepeat.Image = blueOnly;
                BluePixel.Text = string.Format("{0} out of {1} are Blue", bluePix, maxPixels);
                double pixelpercent = bluePix / maxPixels * 100;
                BluePercentage.Text = string.Format("{0:00}% is the total percentage of blue pixels", pixelpercent);
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult dgrTemp = openFileDialog1.ShowDialog();

            if (dgrTemp == DialogResult.OK)
            {
                Bitmap bmpTemp = new Bitmap(openFileDialog1.FileName);
                pictureBox1.Image = bmpTemp;
            }
            
        }

        
    }
}
