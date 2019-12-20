using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using resimesle;

namespace ImageMatching
{
    public class MethodOfFormsElement
    {
        public void uploadImage(object pictureBox)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();

                if (file.ShowDialog() == DialogResult.OK)
                {

                    pictureBox = Image.FromFile(file.FileName);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
