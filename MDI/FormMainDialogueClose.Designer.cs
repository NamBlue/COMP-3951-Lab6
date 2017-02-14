namespace MDI
{
    partial class FormMainDialogueClose
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.SaveButton = new System.Windows.Forms.Button();
            this.NoSaveButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Menu;
            this.textBox1.Location = new System.Drawing.Point(169, 110);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(358, 31);
            this.textBox1.TabIndex = 0;
            this.textBox1.Text = "Do you want to save before closing?";
            // 
            // SaveButton
            // 
            this.SaveButton.Location = new System.Drawing.Point(135, 280);
            this.SaveButton.Name = "SaveButton";
            this.SaveButton.Size = new System.Drawing.Size(146, 64);
            this.SaveButton.TabIndex = 1;
            this.SaveButton.Text = "Save";
            this.SaveButton.UseVisualStyleBackColor = true;
            this.SaveButton.Click += new System.EventHandler(this.SaveButton_Clicked);
            // 
            // NoSaveButton
            // 
            this.NoSaveButton.Location = new System.Drawing.Point(421, 280);
            this.NoSaveButton.Name = "NoSaveButton";
            this.NoSaveButton.Size = new System.Drawing.Size(149, 64);
            this.NoSaveButton.TabIndex = 2;
            this.NoSaveButton.Text = "Don\'t Save";
            this.NoSaveButton.UseVisualStyleBackColor = true;
            this.NoSaveButton.Click += new System.EventHandler(this.NoSaveButton_Clicked);
            // 
            // FormMainDialogueClose
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(688, 541);
            this.Controls.Add(this.NoSaveButton);
            this.Controls.Add(this.SaveButton);
            this.Controls.Add(this.textBox1);
            this.Name = "FormMainDialogueClose";
            this.Text = "FormMainDialogueClose";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button SaveButton;
        private System.Windows.Forms.Button NoSaveButton;
    }
}