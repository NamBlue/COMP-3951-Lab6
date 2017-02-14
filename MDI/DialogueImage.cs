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
    /// Class for creating a Dialogue image box to the user when they are selecting to create
    /// a new image in a child window on the main form.  The user will need to specify the size
    /// of the image they wish to create.  
    /// </summary>
    public partial class DialogueImage : Form
    {
        /// <summary>
        /// Variable for getting and setting the radio button selected.  
        /// </summary>
        public RadioButton checkedRadioButton { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public DialogueImage()
        {
            InitializeComponent();
            if(checkedRadioButton == null)
            {
                checkedRadioButton = Option1;
            }
        }
        #region Button Methods
        /// <summary>
        /// Method for handling when the OK button is selected. A radio button must be selected for  
        /// the size of the image.  Default size is 640 x 480.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OKButton_Clicked(object sender, EventArgs e)
        {
            var checkedButton = RadioGroup.Controls.OfType<RadioButton>()
                                      .FirstOrDefault(r => r.Checked);
            if (checkedButton!= null)
            {
                checkedRadioButton = checkedButton;
                DialogResult = DialogResult.OK;
                Close();
            }
        }
        /// <summary>
        /// Method for closing the Dialogue Image window when the Cancel button is clicked.  
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        #endregion
    }
}
