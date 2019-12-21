using System;
using System.Drawing;
using System.Windows.Forms;

namespace resimesle
{
    public class MethodOfFormsElement
    {
        public void UploadImage(PictureBox picturebox)
        {
            try
            {
                var file = new OpenFileDialog();

                if (file.ShowDialog() == DialogResult.OK)
                {
                    picturebox.Image = Image.FromFile(file.FileName);
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
