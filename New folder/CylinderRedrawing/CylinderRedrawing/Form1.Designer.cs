namespace CylinderRedrawing
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.computeButton = new System.Windows.Forms.Button();
            this.trackBarRotX = new System.Windows.Forms.TrackBar();
            this.trackBarRotY = new System.Windows.Forms.TrackBar();
            this.trackBarScaleRadius = new System.Windows.Forms.TrackBar();
            this.trackBarScaleHeight = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScaleRadius)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScaleHeight)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1177, 562);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // computeButton
            // 
            this.computeButton.Location = new System.Drawing.Point(1222, 13);
            this.computeButton.Name = "computeButton";
            this.computeButton.Size = new System.Drawing.Size(103, 42);
            this.computeButton.TabIndex = 1;
            this.computeButton.Text = "button1";
            this.computeButton.UseVisualStyleBackColor = true;
            this.computeButton.Click += new System.EventHandler(this.ComputeButton_Click);
            // 
            // trackBarRotX
            // 
            this.trackBarRotX.Location = new System.Drawing.Point(1221, 79);
            this.trackBarRotX.Maximum = 180;
            this.trackBarRotX.Name = "trackBarRotX";
            this.trackBarRotX.Size = new System.Drawing.Size(104, 69);
            this.trackBarRotX.TabIndex = 2;
            this.trackBarRotX.Scroll += new System.EventHandler(this.TrackBarRotX_Scroll);
            // 
            // trackBarRotY
            // 
            this.trackBarRotY.Location = new System.Drawing.Point(1221, 170);
            this.trackBarRotY.Maximum = 180;
            this.trackBarRotY.Name = "trackBarRotY";
            this.trackBarRotY.Size = new System.Drawing.Size(104, 69);
            this.trackBarRotY.TabIndex = 3;
            this.trackBarRotY.Scroll += new System.EventHandler(this.TrackBarRotY_Scroll);
            // 
            // trackBarScaleRadius
            // 
            this.trackBarScaleRadius.Location = new System.Drawing.Point(1221, 287);
            this.trackBarScaleRadius.Minimum = 1;
            this.trackBarScaleRadius.Name = "trackBarScaleRadius";
            this.trackBarScaleRadius.Size = new System.Drawing.Size(104, 69);
            this.trackBarScaleRadius.TabIndex = 4;
            this.trackBarScaleRadius.Value = 1;
            this.trackBarScaleRadius.Scroll += new System.EventHandler(this.TrackBarScaleRadius_Scroll);
            // 
            // trackBarScaleHeight
            // 
            this.trackBarScaleHeight.Location = new System.Drawing.Point(1221, 408);
            this.trackBarScaleHeight.Name = "trackBarScaleHeight";
            this.trackBarScaleHeight.Size = new System.Drawing.Size(104, 69);
            this.trackBarScaleHeight.TabIndex = 5;
            this.trackBarScaleHeight.Scroll += new System.EventHandler(this.TrackBarScaleHeight_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1573, 615);
            this.Controls.Add(this.trackBarScaleHeight);
            this.Controls.Add(this.trackBarScaleRadius);
            this.Controls.Add(this.trackBarRotY);
            this.Controls.Add(this.trackBarRotX);
            this.Controls.Add(this.computeButton);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarRotY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScaleRadius)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarScaleHeight)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button computeButton;
        private System.Windows.Forms.TrackBar trackBarRotX;
        private System.Windows.Forms.TrackBar trackBarRotY;
        private System.Windows.Forms.TrackBar trackBarScaleRadius;
        private System.Windows.Forms.TrackBar trackBarScaleHeight;
    }
}

