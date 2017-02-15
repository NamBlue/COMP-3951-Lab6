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
    /// <summary>
    /// Form Main is a class which displays images to the user in the form of child windows.  The
    /// user can create new images of sizes: 640 x 480, 800 x 600 and 1024 x768 in a child window.  
    /// The user can also choose an image from their local computer or from the internet.  The user
    /// can also arrange the child windows displaying the images in cascading, horizontal or vertical
    /// formats.  The user can save any new image they create on their local computer.  
    /// </summary>
    public partial class FormMain : Form
    {
        /// <summary>
        /// 
        /// </summary>
        Form activeChild;
        /// <summary>
        /// Constructor for the main form.  It initializes the GUI and the window with it's tool
        /// menu to the user.  
        /// </summary>
        public FormMain()
        {
            InitializeComponent();   
        }

        #region Button Methods
        /// <summary>
        /// Method for creating a new image on a window child when the menu button is clicked.  It
        /// brings up a dialogue window for selecting the size of the image created.  Default
        /// size is 640 x 480 if no size is selected.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogueImage dialogueImage = new DialogueImage();

            // Display the Dialogue Image window to the user to select the size of the image.
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
        /// <summary>
        /// Mehthod for opening a image file to display in a child window on the main form.  
        /// The image files that are supported are: BMP, JPG, GIF
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
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
            FormDialogueWeb dialog = new FormDialogueWeb();
            dialog.ShowDialog();
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeChild = this.ActiveMdiChild;
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
        /// <summary>
        /// Method for exiting the program.  It will also ask the user if they wish to save any 
        /// unsaved images before exiting the program.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.MdiChildren.Length > 0)
            {
                foreach (FormChild form in this.MdiChildren)
                {
                    if (!form.Saved)
                    {
                        FormMainDialogueClose formMainDialogueClose = new FormMainDialogueClose();
                        if (formMainDialogueClose.ShowDialog() == DialogResult.OK)
                        {
                            SaveFileDialog dialog = new SaveFileDialog();
                            dialog.InitialDirectory = "./";
                            dialog.Filter = "Image Files(*.BMP;*.JPG;*.GIF)|*.BMP;*.JPG;*.GIF|All files (*.*)|*.*"; // Filter files by extension
                            dialog.FilterIndex = 1;

                            // Show open file dialog box
                            if (dialog.ShowDialog() == DialogResult.OK)
                            { 
                                form.SaveImage(dialog.FileName);
                            }
                        }
                    }
                }
            }
            Close();
        }
        /// <summary>
        /// Method for arranging the child window(s) in a cascading fashion.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cascadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.Cascade);
        }
        /// <summary>
        /// Method for arranging the child window(s) vertically.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tileVerticalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileVertical);
        }
        /// <summary>
        /// Method for arranging the child window(s) horizontally.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tileHorizontalToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(System.Windows.Forms.MdiLayout.TileHorizontal);
        }
        #endregion

        private void fileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            activeChild = this.ActiveMdiChild;
            if (activeChild == null)
            {
                saveToolStripMenuItem.Enabled = false;
                saveAsToolStripMenuItem.Enabled = false;
            }
            else
            {
                saveToolStripMenuItem.Enabled = true;
                saveAsToolStripMenuItem.Enabled = true;
            }
        }
    }
}
