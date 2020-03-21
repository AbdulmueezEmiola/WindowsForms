namespace WindowsFormsApp3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.tbScale = new System.Windows.Forms.TrackBar();
            this.tbRotateX = new System.Windows.Forms.TrackBar();
            this.tbRotateY = new System.Windows.Forms.TrackBar();
            this.tbRotateZ = new System.Windows.Forms.TrackBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateY)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateZ)).BeginInit();
            this.SuspendLayout();
            // 
            // tbScale
            // 
            this.tbScale.Location = new System.Drawing.Point(12, 32);
            this.tbScale.Maximum = 150;
            this.tbScale.Name = "tbScale";
            this.tbScale.Size = new System.Drawing.Size(104, 45);
            this.tbScale.TabIndex = 0;
            this.tbScale.Value = 100;
            this.tbScale.ValueChanged += new System.EventHandler(this.tb_ValueChanged);
            // 
            // tbRotateX
            // 
            this.tbRotateX.Location = new System.Drawing.Point(146, 32);
            this.tbRotateX.Maximum = 360;
            this.tbRotateX.Name = "tbRotateX";
            this.tbRotateX.Size = new System.Drawing.Size(104, 45);
            this.tbRotateX.TabIndex = 1;
            this.tbRotateX.Value = 30;
            this.tbRotateX.ValueChanged += new System.EventHandler(this.tb_ValueChanged);
            // 
            // tbRotateY
            // 
            this.tbRotateY.Location = new System.Drawing.Point(290, 32);
            this.tbRotateY.Maximum = 360;
            this.tbRotateY.Name = "tbRotateY";
            this.tbRotateY.Size = new System.Drawing.Size(104, 45);
            this.tbRotateY.TabIndex = 2;
            this.tbRotateY.Value = 45;
            this.tbRotateY.ValueChanged += new System.EventHandler(this.tb_ValueChanged);
            // 
            // tbRotateZ
            // 
            this.tbRotateZ.Location = new System.Drawing.Point(429, 32);
            this.tbRotateZ.Maximum = 360;
            this.tbRotateZ.Name = "tbRotateZ";
            this.tbRotateZ.Size = new System.Drawing.Size(104, 45);
            this.tbRotateZ.TabIndex = 3;
            this.tbRotateZ.Value = 45;
            this.tbRotateZ.ValueChanged += new System.EventHandler(this.tb_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Scaling:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(159, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Rotation X:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(304, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(60, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Rotation Y:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(440, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(60, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "Rotation Z:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(684, 561);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tbRotateZ);
            this.Controls.Add(this.tbRotateY);
            this.Controls.Add(this.tbRotateX);
            this.Controls.Add(this.tbScale);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.tbScale)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateY)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbRotateZ)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TrackBar tbScale;
        private System.Windows.Forms.TrackBar tbRotateX;
        private System.Windows.Forms.TrackBar tbRotateY;
        private System.Windows.Forms.TrackBar tbRotateZ;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

