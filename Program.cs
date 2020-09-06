using Image_Gallery_Demo1.Controls;
using System;
using System.Windows.Forms;

namespace Image_Gallery_Demo1
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

            //Load the main form
            LoadForm();
        }

        /// <summary>
        /// Load the Image Gallery
        /// </summary>
        public static void LoadForm()
        {
            Application.Run(new CustomImageGallery());
        }
    }
}
