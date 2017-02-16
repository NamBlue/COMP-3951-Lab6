using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MDI
{
    /// <summary>
    /// Class for defining the form window that prompts the user if they wish to 
    /// import an image from a URL.  
    /// </summary>
    public partial class FormDialogueWeb : Form
    {
        /// <summary>
        /// Image reference variable for selecting the image object.  
        /// </summary>
        public Image Image { get; set; }
        /// <summary>
        /// Variable for specifying the URL of where to recieve the image object.  
        /// </summary>
        public String Path { get; set; }

        /// <summary>
        /// Constructor for the FormDialogueWeb.  It intializes the component and displays
        /// the dialogue to the user.  
        /// </summary>
        public FormDialogueWeb()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Button method for confirming that the user wishes to import the image from the URL.  
        /// It gets the image object from the input stream from the website's URL and creates
        /// an Image object which can be referenced by the Main form.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void okButton_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult = DialogResult.OK;
                Path = urlBox.Text;
                WebRequest req = WebRequest.Create(urlBox.Text);
                WebResponse response = req.GetResponse();
                Stream stream = response.GetResponseStream();
                Image = Image.FromStream(stream);
                stream.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Invalid Url or Site not found, Please try again.", "Error", MessageBoxButtons.OK);
                DialogResult = DialogResult.Cancel;
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }
        /// <summary>
        /// Button method for the dialogue box in case the user wishes to cancel out of the
        /// FormDialogueWeb box.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}