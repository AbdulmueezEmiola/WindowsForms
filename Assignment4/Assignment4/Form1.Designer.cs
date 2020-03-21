namespace Assignment4
{
    partial class Form1
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
            this.radiusLabel = new System.Windows.Forms.Label();
            this.angleLabel = new System.Windows.Forms.Label();
            this.radiusTextBox = new System.Windows.Forms.TextBox();
            this.angleTextBox = new System.Windows.Forms.TextBox();
            this.computeButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // radiusLabel
            // 
            this.radiusLabel.AutoSize = true;
            this.radiusLabel.Location = new System.Drawing.Point(30, 28);
            this.radiusLabel.Name = "radiusLabel";
            this.radiusLabel.Size = new System.Drawing.Size(59, 20);
            this.radiusLabel.TabIndex = 0;
            this.radiusLabel.Text = "Radius";
            // 
            // angleLabel
            // 
            this.angleLabel.AutoSize = true;
            this.angleLabel.Location = new System.Drawing.Point(30, 90);
            this.angleLabel.Name = "angleLabel";
            this.angleLabel.Size = new System.Drawing.Size(50, 20);
            this.angleLabel.TabIndex = 1;
            this.angleLabel.Text = "Angle";
            // 
            // radiusTextBox
            // 
            this.radiusTextBox.Location = new System.Drawing.Point(104, 22);
            this.radiusTextBox.Name = "radiusTextBox";
            this.radiusTextBox.Size = new System.Drawing.Size(100, 26);
            this.radiusTextBox.TabIndex = 2;
            // 
            // angleTextBox
            // 
            this.angleTextBox.Location = new System.Drawing.Point(101, 84);
            this.angleTextBox.Name = "angleTextBox";
            this.angleTextBox.Size = new System.Drawing.Size(100, 26);
            this.angleTextBox.TabIndex = 3;
            // 
            // computeButton
            // 
            this.computeButton.Location = new System.Drawing.Point(101, 146);
            this.computeButton.Name = "computeButton";
            this.computeButton.Size = new System.Drawing.Size(100, 35);
            this.computeButton.TabIndex = 4;
            this.computeButton.Text = "Compute";
            this.computeButton.UseVisualStyleBackColor = true;
            this.computeButton.Click += new System.EventHandler(this.ComputeButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Location = new System.Drawing.Point(298, 43);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(854, 568);
            this.pictureBox1.TabIndex = 5;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox1_MouseMove);
            // 
            // Form1
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1344, 696);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.computeButton);
            this.Controls.Add(this.angleTextBox);
            this.Controls.Add(this.radiusTextBox);
            this.Controls.Add(this.angleLabel);
            this.Controls.Add(this.radiusLabel);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label radiusLabel;
        private System.Windows.Forms.Label angleLabel;
        private System.Windows.Forms.TextBox radiusTextBox;
        private System.Windows.Forms.TextBox angleTextBox;
        private System.Windows.Forms.Button computeButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}

