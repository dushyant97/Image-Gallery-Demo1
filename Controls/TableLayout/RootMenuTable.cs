using System.Drawing;
using System.Windows.Forms;

namespace Image_Gallery_Demo1.Controls
{
    #region Table Control

    public class RootMenuTable : TableLayoutPanel
    {
        #region Private Field Members

        private ExportButton _exportButton;
        private SearchTextBoxPanel _searchTextBoxPanel;
        private SearchPictureBoxPanel _searchPictureBoxPanel;       

        #endregion

        #region Public Property Members

        public ExportButton ExportButton
        {
            get
            {
                return _exportButton;
            }

            set
            {
                _exportButton = value;
            }
        }

        public SearchPictureBoxPanel SearchPictureBoxPanel
        {
            get
            {
                return _searchPictureBoxPanel;
            }

            set
            {
                _searchPictureBoxPanel = value;
            }
        }

        public SearchTextBoxPanel SearchTextBoxPanel
        {
            get
            {
                return _searchTextBoxPanel;
            }

            set
            {
                _searchTextBoxPanel = value;
            }
        }

        #endregion

        #region Constructor

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="name"></param>
        public RootMenuTable(string name) : base()
        {
            //Self initialization
            InitializeTable(name);

            //Add children controls
            AddChildren();            
        }

        #endregion

        #region Private Methods Members

        /// <summary>
        /// Initialization and setup method
        /// </summary>
        /// <param name="name"></param>
        public void InitializeTable(string name)
        {
            //Table name
            Name = name;

            //Column count & tab index
            ColumnCount = 3;
            TabIndex = 0;

            //Column Styles
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5F));
            ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 37.5F));

            //Row Styles
            RowStyles.Add(new RowStyle(System.Windows.Forms.SizeType.Percent, 100F));

            //Location and other settings
            Dock = DockStyle.Fill;
            Location = new Point(0, 0);
            Size = new Size(764, 40);

            //Suspended layout
            SuspendLayout();

            //Resume layout
            ResumeLayout(false);
        }

        /// <summary>
        /// Adding the children of table
        /// </summary>
        public void AddChildren()
        {
            //Initialize the child control
            _exportButton = new ExportButton("_exportImage", "Export To PDF");
            _searchTextBoxPanel = new SearchTextBoxPanel("searchTextBoxPanel");
            _searchPictureBoxPanel = new SearchPictureBoxPanel("searchPictureBoxPanel");

            //Add the child control to this panel
            Controls.Add(_exportButton, 0, 0);
            Controls.Add(_searchTextBoxPanel, 1, 0);
            Controls.Add(_searchPictureBoxPanel, 2, 0);

            //Handler Subscription
            _exportButton.Paint += new PaintEventHandler(_exportButton_Paint);
            _searchTextBoxPanel.SearchTextBox.Paint += new PaintEventHandler(SearchTextBoxPanel_Paint);
        }

        #endregion

        #region Event Handlers       

        private void _exportButton_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = new Rectangle(_exportButton.Location.X, _exportButton.Location.Y, _exportButton.Width, _exportButton.Height);
            r.X -= 29;
            r.Y -= 3;
            r.Width--;
            r.Height--;
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawRectangle(p, r);
            e.Graphics.DrawLine(p, new Point(0, 43), new Point(this.Width, 43));
        }

        private void SearchTextBoxPanel_Paint(object sender, PaintEventArgs e)
        {
            Rectangle r = _searchTextBoxPanel.SearchTextBox.Bounds;
            r.Inflate(3, 3);
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawRectangle(p, r);
        }
        #endregion
    }

    #endregion
}
