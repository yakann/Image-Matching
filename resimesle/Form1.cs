using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ImageMatching
{
    public partial class Form1 : Form
    {
        private readonly MethodOfFormsElement _methodOfFormsElement;

        public Form1()
        {
            InitializeComponent();
        }

        public Form1(MethodOfFormsElement methodOfFormsElement) : this()
        {
            _methodOfFormsElement = methodOfFormsElement;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            _methodOfFormsElement.uploadImage(pictureBox1.Image);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            _methodOfFormsElement.uploadImage(pictureBox2.Image);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap img1 = new Bitmap(pictureBox1.Image);
                Bitmap img2 = new Bitmap(pictureBox2.Image);

                if (img1.Width == img2.Width && img1.Height == img2.Height)
                {


                    bool flag = false;
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
                    if (flag == false)
                        MessageBox.Show("Sorry, Images are not same.");
                    else
                        MessageBox.Show(" Images are same.");
                }
                else
                    MessageBox.Show("Can not compare this images.");
                this.Dispose();
            }
            catch (Exception)
            {
                MessageBox.Show("You must choose picture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
