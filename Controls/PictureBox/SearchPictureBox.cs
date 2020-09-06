using System.Windows.Forms;

namespace Image_Gallery_Demo1.Controls
{
    public class SearchPictureBox : PictureBox
    {
        #region constructor

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="name"></param>
        public SearchPictureBox(string name, string ImageLocation) : base()
        {
            InitializePictureBox(name, ImageLocation);

            BeginInit();
        }

        #endregion

        /// <summary>
        /// Initialization Method
        /// </summary>
        /// <param name="name"></param>
        private void InitializePictureBox(string name, string ImageLocation)
        {
            Name = name;
            Dock = DockStyle.Left;

            this.ImageLocation = ImageLocation;

            Location = new System.Drawing.Point(0, 0);

            Margin = new Padding(0);
            Size = new System.Drawing.Size(40, 16);
            SizeMode = PictureBoxSizeMode.Zoom;
            
            TabIndex = 0;
            TabStop = false;
        }

        /// <summary>
        /// Begin Init Method
        /// </summary>
        private void BeginInit()
        {
            ((System.ComponentModel.ISupportInitialize)(this)).BeginInit();
        }
    }
}
