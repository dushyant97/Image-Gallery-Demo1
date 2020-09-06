using System.Windows.Forms;

namespace Image_Gallery_Demo1.Controls
{
    #region Panel Control

    public class SearchTextBoxPanel : Panel
    {
        #region Private Field Members

        private SearchTextBox _searchTextBox;

        #endregion

        #region Public Property Members

        public SearchTextBox SearchTextBox
        {
            get
            {
                return _searchTextBox;
            }

            set
            {
                _searchTextBox = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="name"></param>
        public SearchTextBoxPanel(string name) : base()
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
            TabIndex = 0;

            Dock = DockStyle.Fill;
            Location = new System.Drawing.Point(477, 0);            
            Size = new System.Drawing.Size(287, 40);

            SuspendLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        /// <summary>
        /// Adding the children of container
        /// </summary>
        private void AddChildren()
        {
            //Initialize the child control
            _searchTextBox = new SearchTextBox("_searchBox");

            //Add the child control to this panel
            Controls.Add(_searchTextBox);
        }

        #endregion
    }

    #endregion
}
