using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UberFrba.Menu
{
    public abstract class ABM : Form
    {
        protected Form parent;

        public void setParent(Form parent)
        { 
            this.parent = parent;
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ABM
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "ABM";
            this.Load += new System.EventHandler(this.ABM_Load);
            this.ResumeLayout(false);

        }

        private void ABM_Load(object sender, EventArgs e)
        {

        }
    }
}
