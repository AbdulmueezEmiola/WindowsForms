namespace DrawingCylinder
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
            this.rotXTrackBar = new System.Windows.Forms.TrackBar();
            this.rotYTrackBar = new System.Windows.Forms.TrackBar();
            this.rotZTrackBar = new System.Windows.Forms.TrackBar();
            this.rotateX = new System.Windows.Forms.Label();
            this.RotateY = new System.Windows.Forms.Label();
            this.RotateZ = new System.Windows.Forms.Label();
            this.scaleRadiusTrackBar1 = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.rotXTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotYTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotZTrackBar)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleRadiusTrackBar1)).BeginInit();
            this.SuspendLayout();
            // 
            // rotXTrackBar
            // 
            this.rotXTrackBar.Location = new System.Drawing.Point(35, 30);
            this.rotXTrackBar.Maximum = 360;
            this.rotXTrackBar.Name = "rotXTrackBar";
            this.rotXTrackBar.Size = new System.Drawing.Size(195, 69);
            this.rotXTrackBar.TabIndex = 0;
            this.rotXTrackBar.Scroll += new System.EventHandler(this.RotXTrackBar_Scroll);
            // 
            // rotYTrackBar
            // 
            this.rotYTrackBar.Location = new System.Drawing.Point(35, 123);
            this.rotYTrackBar.Maximum = 360;
            this.rotYTrackBar.Name = "rotYTrackBar";
            this.rotYTrackBar.Size = new System.Drawing.Size(195, 69);
            this.rotYTrackBar.TabIndex = 1;
            this.rotYTrackBar.Scroll += new System.EventHandler(this.RotYTrackBar_Scroll);
            // 
            // rotZTrackBar
            // 
            this.rotZTrackBar.Location = new System.Drawing.Point(35, 210);
            this.rotZTrackBar.Maximum = 360;
            this.rotZTrackBar.Name = "rotZTrackBar";
            this.rotZTrackBar.Size = new System.Drawing.Size(195, 69);
            this.rotZTrackBar.TabIndex = 2;
            this.rotZTrackBar.Scroll += new System.EventHandler(this.RotZtrackBar_Scroll);
            // 
            // rotateX
            // 
            this.rotateX.AutoSize = true;
            this.rotateX.Location = new System.Drawing.Point(104, 9);
            this.rotateX.Name = "rotateX";
            this.rotateX.Size = new System.Drawing.Size(69, 20);
            this.rotateX.TabIndex = 3;
            this.rotateX.Text = "RotateX";
            // 
            // RotateY
            // 
            this.RotateY.AutoSize = true;
            this.RotateY.Location = new System.Drawing.Point(104, 102);
            this.RotateY.Name = "RotateY";
            this.RotateY.Size = new System.Drawing.Size(69, 20);
            this.RotateY.TabIndex = 4;
            this.RotateY.Text = "RotateY";
            // 
            // RotateZ
            // 
            this.RotateZ.AutoSize = true;
            this.RotateZ.Location = new System.Drawing.Point(104, 187);
            this.RotateZ.Name = "RotateZ";
            this.RotateZ.Size = new System.Drawing.Size(68, 20);
            this.RotateZ.TabIndex = 5;
            this.RotateZ.Text = "RotateZ";
            // 
            // scaleRadiusTrackBar1
            // 
            this.scaleRadiusTrackBar1.Location = new System.Drawing.Point(35, 307);
            this.scaleRadiusTrackBar1.Minimum = 1;
            this.scaleRadiusTrackBar1.Name = "scaleRadiusTrackBar1";
            this.scaleRadiusTrackBar1.Size = new System.Drawing.Size(195, 69);
            this.scaleRadiusTrackBar1.TabIndex = 6;
            this.scaleRadiusTrackBar1.Value = 1;
            this.scaleRadiusTrackBar1.Scroll += new System.EventHandler(this.ScaleRadiusTrackBar1_Scroll);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(104, 282);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(49, 20);
            this.label1.TabIndex = 7;
            this.label1.Text = "Scale";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(48, 396);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 24);
            this.checkBox1.TabIndex = 8;
            this.checkBox1.Text = "ShowEnds";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.CheckBox1_CheckedChanged);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1104, 625);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.scaleRadiusTrackBar1);
            this.Controls.Add(this.RotateZ);
            this.Controls.Add(this.RotateY);
            this.Controls.Add(this.rotateX);
            this.Controls.Add(this.rotZTrackBar);
            this.Controls.Add(this.rotYTrackBar);
            this.Controls.Add(this.rotXTrackBar);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            ((System.ComponentModel.ISupportInitialize)(this.rotXTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotYTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rotZTrackBar)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.scaleRadiusTrackBar1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar rotXTrackBar;
        private System.Windows.Forms.TrackBar rotYTrackBar;
        private System.Windows.Forms.TrackBar rotZTrackBar;
        private System.Windows.Forms.Label rotateX;
        private System.Windows.Forms.Label RotateY;
        private System.Windows.Forms.Label RotateZ;
        private System.Windows.Forms.TrackBar scaleRadiusTrackBar1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

