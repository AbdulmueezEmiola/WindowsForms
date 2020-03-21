namespace _3dCylenderKG
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
            this.pictureBox_main = new System.Windows.Forms.PictureBox();
            this.cylinder_btn = new System.Windows.Forms.Button();
            this.trackBar_OX = new System.Windows.Forms.TrackBar();
            this.trackBar_res_OXY = new System.Windows.Forms.TrackBar();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_OX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_res_OXY)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_main
            // 
            this.pictureBox_main.Location = new System.Drawing.Point(20, 20);
            this.pictureBox_main.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox_main.Name = "pictureBox_main";
            this.pictureBox_main.Size = new System.Drawing.Size(970, 872);
            this.pictureBox_main.TabIndex = 0;
            this.pictureBox_main.TabStop = false;
            this.pictureBox_main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox_main_MouseDown);
            this.pictureBox_main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox_main_MouseMove);
            // 
            // cylinder_btn
            // 
            this.cylinder_btn.Location = new System.Drawing.Point(998, 900);
            this.cylinder_btn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cylinder_btn.Name = "cylinder_btn";
            this.cylinder_btn.Size = new System.Drawing.Size(92, 65);
            this.cylinder_btn.TabIndex = 1;
            this.cylinder_btn.Text = "Цилиндр";
            this.cylinder_btn.UseVisualStyleBackColor = true;
            this.cylinder_btn.Click += new System.EventHandler(this.Cylinder_btn_Click);
            // 
            // trackBar_OX
            // 
            this.trackBar_OX.Location = new System.Drawing.Point(20, 902);
            this.trackBar_OX.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar_OX.Maximum = 628;
            this.trackBar_OX.Name = "trackBar_OX";
            this.trackBar_OX.Size = new System.Drawing.Size(969, 69);
            this.trackBar_OX.TabIndex = 2;
            this.trackBar_OX.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_OX.Scroll += new System.EventHandler(this.TrackBar_OX_Scroll);
            // 
            // trackBar_res_OXY
            // 
            this.trackBar_res_OXY.Location = new System.Drawing.Point(1022, 18);
            this.trackBar_res_OXY.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.trackBar_res_OXY.Maximum = 628;
            this.trackBar_res_OXY.Name = "trackBar_res_OXY";
            this.trackBar_res_OXY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_res_OXY.Size = new System.Drawing.Size(69, 872);
            this.trackBar_res_OXY.TabIndex = 3;
            this.trackBar_res_OXY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_res_OXY.Scroll += new System.EventHandler(this.TrackBar_res_OXY_Scroll);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1107, 983);
            this.Controls.Add(this.trackBar_res_OXY);
            this.Controls.Add(this.trackBar_OX);
            this.Controls.Add(this.cylinder_btn);
            this.Controls.Add(this.pictureBox_main);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Form1";
            this.Text = "Cylinder3D";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_OX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_res_OXY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_main;
        private System.Windows.Forms.Button cylinder_btn;
        private System.Windows.Forms.TrackBar trackBar_OX;
        private System.Windows.Forms.TrackBar trackBar_res_OXY;
    }
}

