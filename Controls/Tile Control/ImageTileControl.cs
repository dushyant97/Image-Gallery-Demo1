using C1.Win.C1Tile;


namespace Image_Gallery_Demo1.Controls
{
    public class ImageTileControl : C1TileControl
    {
        private PanelElement panelElement1;
        private ImageElement imageElement1;
        private TextElement textElement1;
        private Group group1;
 

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="name"></param>
        public ImageTileControl(string name): base()
        {
            BeginInit();

            TileControlInitialize(name);
        }

        /// <summary>
        /// Initialization and setup method
        /// </summary>
        /// <param name="name"></param>
        private void TileControlInitialize(string name)
        {
            //Basic Initialization
            group1 = new Group();

            Groups.Add(group1);
            panelElement1.Children.Add(imageElement1);
            panelElement1.Children.Add(textElement1);
            DefaultTemplate.Elements.Add(panelElement1);

            AllowChecking = true;
            AllowRearranging = true;
            CellHeight = 78;
            CellSpacing = 11;
            CellWidth = 78;        
            
            Dock = System.Windows.Forms.DockStyle.Fill;
            Name = name;
            Size = new System.Drawing.Size(764, 718);
            SurfacePadding = new System.Windows.Forms.Padding(12, 4, 12, 4);
            SwipeDistance = 20;
            SwipeRearrangeDistance = 98;
          
        }

        private void BeginInit()
        {
            panelElement1 = new PanelElement();
            imageElement1 = new ImageElement();
            textElement1 = new TextElement();
        }
    }
}
