namespace MDI
{
    partial class DialogueImage
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
            this.Option1 = new System.Windows.Forms.RadioButton();
            this.Option2 = new System.Windows.Forms.RadioButton();
            this.Option3 = new System.Windows.Forms.RadioButton();
            this.OKButton = new System.Windows.Forms.Button();
            this.CancelButton = new System.Windows.Forms.Button();
            this.RadioGroup = new System.Windows.Forms.GroupBox();
            this.RadioGroup.SuspendLayout();
            this.SuspendLayout();
            // 
            // Option1
            // 
            this.Option1.AutoSize = true;
            this.Option1.Checked = true;
            this.Option1.Location = new System.Drawing.Point(34, 46);
            this.Option1.Name = "Option1";
            this.Option1.Size = new System.Drawing.Size(138, 29);
            this.Option1.TabIndex = 0;
            this.Option1.TabStop = true;
            this.Option1.Text = "640 x 480";
            this.Option1.UseVisualStyleBackColor = true;
            // 
            // Option2
            // 
            this.Option2.AutoSize = true;
            this.Option2.Location = new System.Drawing.Point(34, 162);
            this.Option2.Name = "Option2";
            this.Option2.Size = new System.Drawing.Size(138, 29);
            this.Option2.TabIndex = 1;
            this.Option2.TabStop = true;
            this.Option2.Text = "800 x 600";
            this.Option2.UseVisualStyleBackColor = true;
            // 
            // Option3
            // 
            this.Option3.AutoSize = true;
            this.Option3.Location = new System.Drawing.Point(34, 277);
            this.Option3.Name = "Option3";
            this.Option3.Size = new System.Drawing.Size(150, 29);
            this.Option3.TabIndex = 2;
            this.Option3.TabStop = true;
            this.Option3.Text = "1024 x 768";
            this.Option3.UseVisualStyleBackColor = true;
            // 
            // OKButton
            // 
            this.OKButton.Location = new System.Drawing.Point(459, 210);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(160, 59);
            this.OKButton.TabIndex = 3;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.OKButton_Clicked);
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(459, 334);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(160, 69);
            this.CancelButton.TabIndex = 4;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Clicked);
            // 
            // RadioGroup
            // 
            this.RadioGroup.Controls.Add(this.Option1);
            this.RadioGroup.Controls.Add(this.Option2);
            this.RadioGroup.Controls.Add(this.Option3);
            this.RadioGroup.Location = new System.Drawing.Point(78, 96);
            this.RadioGroup.Name = "RadioGroup";
            this.RadioGroup.Size = new System.Drawing.Size(285, 367);
            this.RadioGroup.TabIndex = 5;
            this.RadioGroup.TabStop = false;
            // 
            // DialogueImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(727, 633);
            this.Controls.Add(this.RadioGroup);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Name = "DialogueImage";
            this.Text = "DialogueImage";
            this.RadioGroup.ResumeLayout(false);
            this.RadioGroup.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton Option1;
        private System.Windows.Forms.RadioButton Option2;
        private System.Windows.Forms.RadioButton Option3;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.GroupBox RadioGroup;
    }
}