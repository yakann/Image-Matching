﻿using System;
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

                MessageBox.Show("Hata Oluştu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
        {
            try
            {
                Bitmap img1 = new Bitmap(pictureBox1.Image);
                Bitmap img2 = new Bitmap(pictureBox2.Image);

                if (img1.Width == img2.Width && img1.Height == img2.Height)
                {
                    int count2 = 0;
                    int count1 = 0;
                    bool flag = false;
                    for (int i = 0; i < img1.Width; i++)//Ex:300
                    {
                        for (int j = 0; j < img1.Height; j++)//Ex:500
                        {
                            string img1_ref = img1.GetPixel(i, j).ToString();
                            string img2_ref = img2.GetPixel(i, j).ToString();
                            if (img1_ref != img2_ref)
                            {
                                count2++;
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
        public void GetPixel_Example()
        {

            // Create a Bitmap object from an image file.
            Bitmap myBitmap = (Bitmap)pictureBox1.Image;
            Bitmap myBitmap2 = (Bitmap)pictureBox2.Image;
            // Get the color of a pixel within myBitmap.
            Color pixelColor = myBitmap.GetPixel(55, 55);
            Color pixelColor2 = myBitmap2.GetPixel(55, 55);
            label2.Text = pixelColor.ToString();
            label3.Text = pixelColor2.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}