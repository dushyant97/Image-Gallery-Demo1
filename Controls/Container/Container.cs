using C1.C1Pdf;
using C1.Win.C1Tile;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Image_Gallery_Demo1.Controls
{
    #region Container Control

    /// <summary>
    /// Split container custom
    /// </summary>
    public partial class Container : SplitContainer
    {
        #region Private Field Members

        private RootMenuTable _rootTable;
        private ImageTileControl _imageTileControl;
        private StatusStripBar _statusStrip;
        private int checkedItems = 0;

        C1PdfDocument imagePdfDocument = new C1PdfDocument();
        DataFetcher datafetch;
        List<ImageItem> imagesList;

        #endregion

        #region Constructor

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="name"></param>
        public Container(string name) : base()
        {
            //Base initialization
            BeginInit();

            //Self initialization
            InitializeContainer(name);

            //Add children controls
            AddChildren();

            //Base initialization
            EndInit();
        }

        #endregion

        #region Private Methods Members

        /// <summary>
        /// Initialization and setup method
        /// </summary>
        /// <param name="name"></param>
        private void InitializeContainer(string name)
        {
            //Basic setup
            Name = name;
            IsSplitterFixed = true;
            SplitterDistance = 40;
            TabIndex = 0;

            //Location and Margin
            Location = new Point(0, 0);
            Margin = new Padding(2);
            Size = new Size(780, 749);

            //Orientation and other settings
            Dock = DockStyle.Fill;
            FixedPanel = FixedPanel.Panel1;
            Orientation = Orientation.Horizontal;

            //Suspended Layout
            Panel1.SuspendLayout();
            Panel2.SuspendLayout();
            SuspendLayout();

            //Resume Layout
            Panel1.ResumeLayout(false);
            Panel2.ResumeLayout(false);
            Panel2.PerformLayout();
            ResumeLayout(false);
        }

        /// <summary>
        /// Adding the children of container
        /// </summary>
        private void AddChildren()
        {
            //Initialize the child control
            _rootTable = new RootMenuTable("tableLayoutPanel1");
            _imageTileControl = new ImageTileControl("_imageTileControl");
            _statusStrip = new StatusStripBar("StatusStrip");

            //Add the child control to this panel
            Panel1.Controls.Add(_rootTable);
            Panel2.Controls.Add(_imageTileControl);
            Panel2.Controls.Add(_statusStrip);
            
            _rootTable.ExportButton.Click += new EventHandler(_exportButton_Click);
            _rootTable.SearchPictureBoxPanel.SearchPictureBox.Click += new EventHandler(_search_Click);

            _imageTileControl.TileChecked += new EventHandler<TileEventArgs>(_imageTileControl_TileChecked);
            _imageTileControl.TileUnchecked += new EventHandler<TileEventArgs>(_imageTileControl_TileUnchecked);
            _imageTileControl.Paint += new PaintEventHandler(_imageTileControl_Paint);
        }

        /// <summary>
        /// Begin the base initialization
        /// </summary>
        private new void BeginInit()
        {
            base.BeginInit();
            datafetch = new DataFetcher();
        }

        private new void EndInit()
        {
            base.EndInit();
        }

        private void AddTiles(List<ImageItem> imageList)
        {
            _imageTileControl.Groups[0].Tiles.Clear();
            foreach (var imageitem in imageList)
            {
                Tile tile = new Tile();
                tile.HorizontalSize = 2;
                tile.VerticalSize = 2;
                _imageTileControl.Groups[0].Tiles.Add(tile);
                Image img = Image.FromStream(new MemoryStream(imageitem.Base64));
                Template tl = new Template();
                ImageElement ie = new ImageElement();
                ie.ImageLayout = ForeImageLayout.Stretch;
                tl.Elements.Add(ie);
                tile.Template = tl;
                tile.Image = img;
            }
        }

        private void ConvertToPdf(List<Image> images)
        {
            RectangleF rect = imagePdfDocument.PageRectangle;
            bool firstPage = true;
            foreach (var selectedimg in images)
            {
                if (!firstPage)
                {
                    imagePdfDocument.NewPage();
                }
                firstPage = false;
                rect.Inflate(-72, -72);
                imagePdfDocument.DrawImage(selectedimg, rect);
            }
        }

        #endregion

        #region Event Handlers

        private void _exportButton_Click(object sender, EventArgs e)
        {
            List<Image> images = new List<Image>();
            foreach (Tile tile in _imageTileControl.Groups[0].Tiles)
            {
                if (tile.Checked)
                {
                    images.Add(tile.Image);
                }
            }

            ConvertToPdf(images);
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = "pdf";
            saveFile.Filter = "PDF files (*.pdf)|*.pdf*";
            if (saveFile.ShowDialog() == DialogResult.OK)
            {
                imagePdfDocument.Save(saveFile.FileName);
            }
        }

        private async void _search_Click(object sender, EventArgs e)
        {
            _statusStrip.Visible = true;
            imagesList = await datafetch.GetImageData(_rootTable.SearchTextBoxPanel.SearchTextBox.Text);
            AddTiles(imagesList);
            _statusStrip.Visible = false;
        }

        private void _imageTileControl_TileChecked(object sender, TileEventArgs e)
        {
            checkedItems++;
            _rootTable.ExportButton.Visible = true;
        }

        private void _imageTileControl_TileUnchecked(object sender, TileEventArgs e)
        {
            checkedItems--;
            _rootTable.ExportButton.Visible = checkedItems > 0;
        }

        private void _imageTileControl_Paint(object sender, PaintEventArgs e)
        {
            Pen p = new Pen(Color.LightGray);
            e.Graphics.DrawLine(p, 0, 43, 800, 43);
        }

        #endregion
    }

    #endregion
}
