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
    /// <summary>
    /// Class for the FormMainDialogueClose which is a dialogue box that asks the users if they
    /// wish to save any unsaved images before they exit the program.  Will only be called upon
    /// if the user has unsaved images on the Main Form.  
    /// </summary>
    public partial class FormMainDialogueClose : Form
    {
        /// <summary>
        /// Button reference variable for passing the user's response if they wish to
        /// save their unsaved images.  
        /// </summary>
        public Button Save { get; set; }
        /// <summary>
        /// Constructor for the FormMainDialogueClose dialogue box that appears
        /// if the user has unsaved images.  It allows the user one last chance to save their
        /// unsaved images before exiting the program.  
        /// </summary>
        public FormMainDialogueClose()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Button method for allowing the user to confirm they wish to save their
        /// images before exiting the program.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SaveButton_Clicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        /// <summary>
        /// Button method for canceling out of the unsaved exit dialogue box.  This
        /// will allow the user to avoid saving their unsaved images and exit the program.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void NoSaveButton_Clicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
