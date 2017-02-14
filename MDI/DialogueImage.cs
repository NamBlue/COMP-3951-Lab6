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
    public partial class DialogueImage : Form
    {
        public RadioButton checkedRadioButton { get; set; }

        public DialogueImage()
        {
            InitializeComponent();
            if(checkedRadioButton == null)
            {
                checkedRadioButton = Option1;
            }
        }


        #region Button Methods

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

        private void CancelButton_Clicked(object sender, EventArgs e)
        {
            Close();
        }

        #endregion
    }
}
