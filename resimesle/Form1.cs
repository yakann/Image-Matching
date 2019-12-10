using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace resimesle
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            try
            {
                OpenFileDialog file = new OpenFileDialog();

                if (file.ShowDialog() == DialogResult.OK)
                {                

                    pictureBox1.Image = Image.FromFile(file.FileName);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu","Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file2 = new OpenFileDialog();

                if (file2.ShowDialog() == DialogResult.OK)
                {

                    pictureBox2.Image = Image.FromFile(file2.FileName);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {   /*
            (Burada değerlerin eşit olup olmadığını kontrol eden equals denendi.)
            object deger = pictureBox1.Image.Equals(pictureBox2.Image);
            MessageBox.Show(deger.ToString());
            */
            GetPixel_Example();

         
        }
        public void GetPixel_Example()
        {

            // Create a Bitmap object from an image file.
            Bitmap myBitmap = (Bitmap) pictureBox1.Image;
            Bitmap myBitmap2 = (Bitmap) pictureBox2.Image;
            // Get the color of a pixel within myBitmap.
            Color pixelColor = myBitmap.GetPixel(55, 55);
            Color pixelColor2 = myBitmap2.GetPixel(55, 55);
            label2.Text = pixelColor.ToString();
            label3.Text = pixelColor2.ToString();
        }
    }
}
