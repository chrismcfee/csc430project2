using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Drawing.Text;

namespace WindowsFormsApplication1
{
    using benefitdatabase;

    public partial class Checkform : Form
    {
        public Checkform()
        {
            InitializeComponent();
        }


        private void Checkform_Load(object sender, EventArgs e)
        {
            string firstText = "CSC430";
            string secondText = "g5";

            PointF firstLocation = new PointF(10f, 10f);
            PointF secondLocation = new PointF(10f, 50f);

            string imageFilePath = @"abc.bmp";
            Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file


            using(Graphics graphics = Graphics.FromImage(bitmap))
            {
                         
                using (Font arialFont =  new Font("Arial", 10))
                {
                    graphics.DrawString(firstText, arialFont, Brushes.Blue, firstLocation);
                    graphics.DrawString(secondText, arialFont, Brushes.Red, secondLocation);
                }
                
            }
            

            bitmap.Save("tempimage.bmp");//save the image file

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
