using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using resimesle;

namespace ImageMatching
{
    public partial class Form1 : Form
    {
        private bool flag = false;
        private readonly MethodOfFormsElement _methodOfFormsElement;
        public Form1()
        {
            InitializeComponent();
        }

        public Form1(MethodOfFormsElement methodOfFormsElement):this()
        {
            _methodOfFormsElement = methodOfFormsElement;
        }

        private void ImageMethod(string[] filePaths)
        {
            for (int i = 0; i < filePaths.Length; i++)
            {
                pictureBox1.Image = Image.FromFile(filePaths[i]);
                for (int j = i + 1; j < filePaths.Length; j++)
                {
                    pictureBox2.Image = Image.FromFile(filePaths[j]);
                    CompareImage();
                    if (this.flag == false)
                    {
                        MessageBox.Show("Farklı resimler");
                    }
                    else if (this.flag == true)
                    {
                        MessageBox.Show("Aynı resim bunlar");
                    }
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //Get all image path in folder.
                string[] filePaths = Directory.GetFiles(@"C:\Users\mahmu\OneDrive\Masaüstü\imageler", "*.jpg",
                    SearchOption.TopDirectoryOnly);

                ImageMethod(filePaths);
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _methodOfFormsElement.UploadImage(pictureBox2);
        }

        private void CompareImage()
        {
            try
            {
                Bitmap img1 = new Bitmap(pictureBox1.Image);
                Bitmap img2 = new Bitmap(pictureBox2.Image);

                if (img1.Width == img2.Width && img1.Height == img2.Height)
                {


                    
                    for (int i = 0; i < img1.Width; i++)//Ex:300
                    {
                        for (int j = 0; j < img1.Height; j++)//Ex:500
                        {
                            string img1_ref = img1.GetPixel(i, j).ToString();
                            string img2_ref = img2.GetPixel(i, j).ToString();
                            if (img1_ref != img2_ref)
                            {
                                flag = false;
                                break;
                            }

                            flag = true;
                        }
                    }

                }
                this.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("You must choose picture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
