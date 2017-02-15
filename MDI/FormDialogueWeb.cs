﻿using System;
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
    public partial class FormDialogueWeb : Form
    {
        public Image Image { get; set; }
        public String Path { get; set; }

        public FormDialogueWeb()
        {
            InitializeComponent();
        }

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
                MessageBox.Show("Invalid Url, Please try again.", "Error", MessageBoxButtons.OK);
                DialogResult = DialogResult.Cancel;
                System.Diagnostics.Debug.WriteLine(ex);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}