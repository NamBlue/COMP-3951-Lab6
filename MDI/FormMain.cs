using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
                    FormChild formChild = new FormChild(640, 480);
                    formChild.MdiParent = this;
                    formChild.Show();
                }
                if (dialogueImage.checkedRadioButton.Text == "800 x 600")
                {
                    FormChild formChild = new FormChild(800, 600);
                    formChild.MdiParent = this;
                    formChild.Show();
                }
                if (dialogueImage.checkedRadioButton.Text == "1024 x 768")
                {
                    FormChild formChild = new FormChild(1024, 768);
                    formChild.MdiParent = this;
                    formChild.Show();
                }
            }
        }

        private void openFromFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Configure open file dialog box
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.InitialDirectory = "./";
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"; // Filter files by extension
            dialog.FilterIndex = 1;

            // Show open file dialog box
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Process open file dialog box results
                FormChild formChild = new FormChild(dialog.FileName);
                formChild.MdiParent = this;
                formChild.Show();              
            }
        }

        private void openFromWebToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form activeChild = this.ActiveMdiChild;
            if (activeChild != null)
            {
                try
                {
                    FormChild child = (FormChild)activeChild;
                    if (child.Saved)
                    { 
                        ((FormChild)activeChild).SaveImage(((FormChild)activeChild).Path);
                    }
                    else
                    {
                        saveAsToolStripMenuItem_Click(null, null);
                    }
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex);
                }
            }
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.InitialDirectory = "./";
            dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"; // Filter files by extension
            dialog.FilterIndex = 1;

            // Show open file dialog box
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                // Determine the active child form.  
                Form activeChild = this.ActiveMdiChild;

                // If there is an active child form
                if (activeChild != null)
                {
                    try
                    {
                        ((FormChild)activeChild).SaveImage(dialog.FileName);
                    }
                    catch (Exception ex)
                    {
                        System.Diagnostics.Debug.WriteLine(ex);
                    }
                }
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormMainDialogueClose formMainDialogueClose = new FormMainDialogueClose();
            if (formMainDialogueClose.ShowDialog() == DialogResult.OK)
            {

                Close();
            }
        }
        /// <summary>
        /// Method for arranging the child windows in a cascading fashion.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }
        /// <summary>
        /// Method for arranging the child windows vertically.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }
        /// <summary>
        /// Method for arranging the child window horizontally.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }
        #endregion
    }
}
