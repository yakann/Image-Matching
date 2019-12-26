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
        private bool _flag = false;
        private int _count = 0;

        public List<string> PathList = new List<string>();

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
            try
            {
                foreach (var path in PathList)
                {

                    ImageMethod(GetPath(path));

                }
                //Get all image path in folder.

                label1.Text = "Finished..";
                label2.Text = this._count.ToString();

            }
            catch (Exception)
            {

                MessageBox.Show("ERROR", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private string[] GetPath(string val)
        {
            string[] filePaths = Directory.GetFiles(val, "*.jpg",
                SearchOption.TopDirectoryOnly);
            return filePaths;
        }
        private string[] GetPath(int val)
        {
            string[] filePaths = Directory.GetFiles(this.PathList[val], "*.jpg",
                SearchOption.TopDirectoryOnly);
            return filePaths;
        }
        private void ImageMethod(string[] filePaths1)
        {
            for (int i = 0; i < filePaths1.Length; i++)
            {
                pictureBox1.Image = Image.FromFile(filePaths1[i].ToString());
                label8.Text = filePaths1[i].Split('\\').Last();
                for (int t = 0; t < PathList.Count; t++)
                {
                    string[] filePaths2 = GetPath(t);

                    for (int j = 0; j < filePaths2.Length; j++)
                    {
                        pictureBox2.Image = Image.FromFile(filePaths2[j].ToString());
                        label7.Text = filePaths1[j].Split('\\').Last();
                        CompareImage();
                        if (this._flag != false)
                        {
                            MessageBox.Show(" Images are same.");
                            this._flag = false;
                        }


                    }
                }

                this._flag = false;
            }

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
                                this._flag = false;
                                break;
                            }

                            this._flag = true;
                        }
                        if (this._flag == true)
                        {
                            break;
                        }
                    }
                    if (this._flag == true)
                    {
                        this._count += 1;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("You must choose picture.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AddPathName()
        {
            try
            {
                using (var fbd = new FolderBrowserDialog())
                {
                    DialogResult result = fbd.ShowDialog();

                    if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath) && PathList.Contains(fbd.SelectedPath) == false)
                    {
                        PathList.Add(fbd.SelectedPath.ToString());
                        //string[] files = Directory.GetFiles(fbd.SelectedPath);
                        checkedListBox1.Items.Add(fbd.SelectedPath.Split('\\').Last());
                    }
                    else
                    {
                        MessageBox.Show("This folder already exist.");
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Hata Oluştu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            AddPathName();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.Items)
            {
                label1.Text = PathList[0];
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {
            foreach (var item in checkedListBox1.Items)
            {
                if (item.Equals(true))
                {
                    MessageBox.Show("true");
                }
            }
            checkedListBox1.CheckOnClick = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            int sub = checkedListBox1.Items.Count;
            

            if (SelectAll.Text == "Deselect")
            {
                for (int i = 0; i < sub; i++)
                {
                    checkedListBox1.SetItemChecked(i, false);
                }
                SelectAll.Text = "All Select";
            }
            else
            {
                for (int i = 0; i < sub; i++)
                {
                    checkedListBox1.SetItemChecked(i, true);
                }
                SelectAll.Text = "Deselect";
            }
        }
    }
}
