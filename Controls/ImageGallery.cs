using System.Windows.Forms;
using Image_Gallery_Demo1.Controls;

namespace Image_Gallery_Demo1.Controls
{
    #region Form Control

    public class CustomImageGallery : Form
    {
        #region Private Field Members

        private Container _container;

        #endregion

        #region Constructor

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        public CustomImageGallery()
        {
            //Self initialization
            InitializeImageGallery("ImageGalleryForm", "ImageGallery");

            //Add children controls
            AddChildren();            
        }

        #endregion

        #region Private Method Members

        /// <summary>
        /// Initialization and setup method
        /// </summary>
        /// <param name="name"></param>
        public void InitializeImageGallery(string name, string text)
        {
            Name = name;
            Text = text;

            AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(780, 800);
            
            MaximizeBox = false;
            MaximumSize = new System.Drawing.Size(810, 810);
            
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterParent;
            
            SuspendLayout();

            ResumeLayout(false);
        }

        /// <summary>
        /// Adding the children of container
        /// </summary>
        private void AddChildren()
        {
            //Initialize the child control
            _container = new Container("SplitContainer");

            //Add the child control to this panel
            Controls.Add(_container);
        }

        #endregion
    }

    #endregion    
}

