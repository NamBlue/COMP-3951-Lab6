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
    public partial class FormMainDialogueClose : Form
    {
        public Button Save { get; set; }
        public FormMainDialogueClose()
        {
            InitializeComponent();
        }

        private void SaveButton_Clicked(object sender, EventArgs e)
        {

            Close();
        }

        private void NoSaveButton_Clicked(object sender, EventArgs e)
        {
            Close();
        }
    }
}
