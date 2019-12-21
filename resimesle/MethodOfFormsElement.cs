using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace resimesle
{
    public class MethodOfFormsElement
    {
        public void UploadImage(PictureBox picturebox)
        {
            try
            {
                //Get all image path in folder.
                string[] filePaths = Directory.GetFiles(@"C:\Users\mahmu\OneDrive\Masaüstü\imageler", "*.jpg",
                    SearchOption.TopDirectoryOnly);
                foreach (var path_img in filePaths)
                {
                    picturebox.Image = Image.FromFile(path_img);
                }
                

            }
            catch (Exception)
            {

                MessageBox.Show("Hata Oluştu", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
