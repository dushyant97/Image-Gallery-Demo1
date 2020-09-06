using System.Windows.Forms;

namespace Image_Gallery_Demo1.Controls
{
    public class SearchTextBox : TextBox
    {

        /// <summary>
        /// Parameterized Constructor
        /// </summary>
        /// <param name="name"></param>
        public SearchTextBox(string name): base()
        {
            InitializeTextBox(name);
        }

        /// <summary>
        /// Initialization method
        /// </summary>
        /// <param name="name"></param>
        private void InitializeTextBox(string name)
        {
            Name = name;
            Text = "Search Image";

            BorderStyle = BorderStyle.None;
            
            Location = new System.Drawing.Point(16, 9);
            Size = new System.Drawing.Size(244, 13);
            
            TabIndex = 0;
            
        }
    }
}
