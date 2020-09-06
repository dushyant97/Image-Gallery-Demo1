using System.Windows.Forms;
using System.Drawing;

namespace Image_Gallery_Demo1.Controls
{
    #region Button Control

    public class ExportButton : Button
    {
        #region Constructor

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="name"></param>
        public ExportButton(string name, string textName) : base()
        {
            //Self initialization
            InitializePanel(name, textName);
        }

        #endregion

        #region Private Methods Members

        /// <summary>
        /// Initialization and setup method
        /// </summary>
        /// <param name="name"></param>
        private void InitializePanel(string name, string textName)
        {
            Name = name;
            Text = textName;
            Anchor = AnchorStyles.None;
            BackgroundImageLayout = ImageLayout.None;

            BackColor = Color.White;
            
            Location = new Point(30, 6);
            Margin = new Padding(0);
            
            Size = new Size(135, 28);
            TabIndex = 2;
            
            Visible = false;            
        }              

        #endregion        
    }

    #endregion
}

