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

//the check window when print is selected

namespace WindowsFormsApplication1
{
    using benefitdatabase;
    using pinfo;

    public partial class Checkform : Form
    {
        public Checkform()
        {
            InitializeComponent();
        }

        private person data;
        public string rtnum = "";
        public void indata(person source)
        {
            data = new person();
            data.copy(source);
        }

        private void Checkform_Load(object sender, EventArgs e)
        {
            PointF firstLocation = new PointF(10f, 10f);
            PointF secondLocation = new PointF(10f, 50f);

            string imageFilePath = @"bankcheck.dat";
            Bitmap bitmap = (Bitmap)Image.FromFile(imageFilePath);//load the image file


            using(Graphics graphics = Graphics.FromImage(bitmap))
            {
                         
                using (Font arialFont =  new Font("Arial", 10))
                {
                    graphics.DrawString(data.firstname, arialFont, Brushes.Black, 255f,160f);
                    graphics.DrawString(data.lastname, arialFont, Brushes.Black, 255f, 188f);
                    graphics.DrawString(data.accnum, arialFont, Brushes.Black, 255f, 217f);
                    graphics.DrawString(rtnum, arialFont, Brushes.Black, 255f, 245);
                    graphics.DrawString(data.state, arialFont, Brushes.Black, 255f, 275f);
                    graphics.DrawString("$ " + data.stax.ToString(), arialFont, Brushes.Black, 255f, 303f);
                    graphics.DrawString("$ " + data.gincome.ToString(), arialFont, Brushes.Black, 255f, 332f);
                    graphics.DrawString("$ " + data.npay.ToString(), arialFont, Brushes.Black, 255f, 362f);

                    graphics.DrawString(data.benefit, arialFont, Brushes.Black, 580f, 160f);
                    graphics.DrawString(data.benefitdetail.brand, arialFont, Brushes.Black, 580f, 188f);
                    graphics.DrawString(data.benefitdetail.type, arialFont, Brushes.Black, 580f, 217f);
                    graphics.DrawString(data.benefitdetail.level, arialFont, Brushes.Black, 580f, 245);
                    graphics.DrawString("$ " + data.benefitdetail.value.ToString(), arialFont, Brushes.Black, 580f, 275f);
                    graphics.DrawString(data.dental, arialFont, Brushes.Black, 580f, 303f);
                    graphics.DrawString(data.dentaldetail.brand, arialFont, Brushes.Black, 580f, 332f);
                    graphics.DrawString(data.dentaldetail.type, arialFont, Brushes.Black, 580f, 359f);
                    graphics.DrawString(data.dentaldetail.level, arialFont, Brushes.Black, 580f, 387f);
                    graphics.DrawString("$ " + data.dentaldetail.value.ToString(), arialFont, Brushes.Black, 580f, 416f);

                    pictureBox1.Image = bitmap;
                }
                
            }


            //checkhere
            //Graphics.DrawImage(bitmap, 50, 50);
            
            

            //bitmap.Save("tempimage.bmp");//save the image file

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
