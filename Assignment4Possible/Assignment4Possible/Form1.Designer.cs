namespace Assignment4Possible
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
            this.rowTrackBar = new System.Windows.Forms.TrackBar();
            this.rotationTrackBarY = new System.Windows.Forms.TrackBar();
            this.rotationTrackBarZ = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.rowTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationTrackBarY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationTrackBarZ)).BeginInit();
            this.SuspendLayout();
            // 
            // rowTrackBar
            // 
            this.rowTrackBar.Location = new System.Drawing.Point(110, 43);
            this.rowTrackBar.Maximum = 360;
            this.rowTrackBar.Name = "rowTrackBar";
            this.rowTrackBar.Size = new System.Drawing.Size(159, 69);
            this.rowTrackBar.TabIndex = 0;
            this.rowTrackBar.Scroll += new System.EventHandler(this.RowTrackBar_Scroll);
            // 
            // rotationTrackBarY
            // 
            this.rotationTrackBarY.Location = new System.Drawing.Point(404, 43);
            this.rotationTrackBarY.Maximum = 360;
            this.rotationTrackBarY.Name = "rotationTrackBarY";
            this.rotationTrackBarY.Size = new System.Drawing.Size(220, 69);
            this.rotationTrackBarY.TabIndex = 1;
            this.rotationTrackBarY.Scroll += new System.EventHandler(this.RotationTrackBarY_Scroll);
            // 
            // rotationTrackBarZ
            // 
            this.rotationTrackBarZ.Location = new System.Drawing.Point(729, 43);
            this.rotationTrackBarZ.Maximum = 360;
            this.rotationTrackBarZ.Name = "rotationTrackBarZ";
            this.rotationTrackBarZ.Size = new System.Drawing.Size(294, 69);
            this.rotationTrackBarZ.TabIndex = 2;
            this.rotationTrackBarZ.Scroll += new System.EventHandler(this.RotationTrackBarZ_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1230, 615);
            this.Controls.Add(this.rotationTrackBarZ);
            this.Controls.Add(this.rotationTrackBarY);
            this.Controls.Add(this.rowTrackBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.rowTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationTrackBarY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotationTrackBarZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar rowTrackBar;
        private System.Windows.Forms.TrackBar rotationTrackBarY;
        private System.Windows.Forms.TrackBar rotationTrackBarZ;
    }
}

