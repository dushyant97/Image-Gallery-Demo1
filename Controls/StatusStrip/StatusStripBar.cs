using System.Windows.Forms;

namespace Image_Gallery_Demo1.Controls
{
    public class StatusStripBar : StatusStrip
    {

        private ToolStripProgressBar toolStripProgressBar1;

        /// <summary>
        /// Parameterized constructor
        /// </summary>
        /// <param name="name"></param>
        public StatusStripBar(string name) : base()
        {
            BeginInit();
            StatusStripInitialize(name);
        }

        /// <summary>
        /// Initialization and setup method
        /// </summary>
        /// <param name="name"></param>
        private void StatusStripInitialize(string name)
        {
            Name = name;
            Items.AddRange(new ToolStripItem[] {this.toolStripProgressBar1});
            Location = new System.Drawing.Point(0, 683);
            Size = new System.Drawing.Size(780, 22);
            TabIndex = 2;
            Text = name;
            Visible = false;


            toolStripProgressBar1.Name = "toolStripProgressBar1";
            toolStripProgressBar1.Size = new System.Drawing.Size(100, 16);
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;

            SuspendLayout();

            ResumeLayout(false);
            PerformLayout();
        }

        private void BeginInit()
        {
            toolStripProgressBar1 = new ToolStripProgressBar();
        }
    }
}
