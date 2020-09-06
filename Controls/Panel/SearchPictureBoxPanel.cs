using System.Windows.Forms;
using System.Drawing;
using System;
using System.IO;

namespace Image_Gallery_Demo1.Controls
{
    #region Panel Control

    public class SearchPictureBoxPanel : Panel
    {
        #region Private Field Members

        private SearchPictureBox _searchPictureBox;

        #endregion

        #region Public Property Members

        public SearchPictureBox SearchPictureBox
        {
            get
            {
                return _searchPictureBox;
            }

            set
            {
                _searchPictureBox = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="name"></param>
        public SearchPictureBoxPanel(string name) : base()
        {

            //Self initialization
            InitializePanel(name);

            //Add children controls
            AddChildren();
        }

        #endregion

        #region Private Methods Members

        /// <summary>
        /// Initialization and setup method
        /// </summary>
        /// <param name="name"></param>
        private void InitializePanel(string name)
        {
            Name = name;

            Location = new Point(479, 12);
            Margin = new Padding(2, 12, 45, 12);
            Size = new Size(40, 16);
            
            TabIndex = 1;

            SuspendLayout();
            ResumeLayout(false);
        }

        /// <summary>
        /// Adding the children of container
        /// </summary>
        private void AddChildren()
        {
            string basePath = Directory.GetParent(Environment.CurrentDirectory).Parent.FullName;
            string picturePath = @"Resources\search.jpg";

            string absolutePath = Path.Combine(basePath, picturePath);
            _searchPictureBox = new SearchPictureBox("_search", absolutePath);

            Controls.Add(_searchPictureBox);
        }

        #endregion
    }

    #endregion
}

