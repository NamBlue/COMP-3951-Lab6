using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        #region Button Methods
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogueImage dialogueImage = new DialogueImage();

            // Display the new form.  
            if (dialogueImage.ShowDialog() == DialogResult.OK)
            {
                if (dialogueImage.checkedRadioButton.Text == "640 x 480")
                {
                    FormChild formChild = new FormChild();
                    formChild.MdiParent = this;
                    formChild.Show();
                }
                if (dialogueImage.checkedRadioButton.Text == "800 x 600")
                {
                    FormChild formChild = new FormChild();
                    formChild.MdiParent = this;
                    formChild.Show();
                }
                if (dialogueImage.checkedRadioButton.Text == "1024 x 768")
                {
                    FormChild formChild = new FormChild();
                    formChild.MdiParent = this;
                    formChild.Show();
                }
            }
        }

        private void openFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void openFromWebToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Close();
        }

        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }

        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }

        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }
        #endregion
    }
}
