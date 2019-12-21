using System;
using System.Windows.Forms;
using ImageMatching;

namespace resimesle
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            MethodOfFormsElement methodOfFormsElement = new MethodOfFormsElement();

            Application.Run(new Form1(methodOfFormsElement));
        }
    }
}
