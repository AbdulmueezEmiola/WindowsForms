namespace _3d
{
    partial class Form_main
    {
        /// <summary>
        /// Требуется переменная конструктора.
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
        /// Обязательный метод для поддержки конструктора - не изменяйте
        /// содержимое данного метода при помощи редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.pictureBox_main = new System.Windows.Forms.PictureBox();
            this.button_prism = new System.Windows.Forms.Button();
            this.trackBar_OX = new System.Windows.Forms.TrackBar();
            this.trackBar_res_OXY = new System.Windows.Forms.TrackBar();
            this.button_cub = new System.Windows.Forms.Button();
            this.button_circle = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_OX)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_res_OXY)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox_main
            // 
            this.pictureBox_main.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox_main.BackColor = System.Drawing.Color.Silver;
            this.pictureBox_main.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox_main.Location = new System.Drawing.Point(12, 12);
            this.pictureBox_main.Name = "pictureBox_main";
            this.pictureBox_main.Size = new System.Drawing.Size(647, 567);
            this.pictureBox_main.TabIndex = 0;
            this.pictureBox_main.TabStop = false;
            this.pictureBox_main.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox_main_MouseDown);
            this.pictureBox_main.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_main_MouseMove);
            // 
            // button_prism
            // 
            this.button_prism.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_prism.Location = new System.Drawing.Point(716, 12);
            this.button_prism.Name = "button_prism";
            this.button_prism.Size = new System.Drawing.Size(96, 29);
            this.button_prism.TabIndex = 1;
            this.button_prism.Text = "призма";
            this.button_prism.UseVisualStyleBackColor = true;
            this.button_prism.Click += new System.EventHandler(this.button_prism_Click);
            // 
            // trackBar_OX
            // 
            this.trackBar_OX.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_OX.Location = new System.Drawing.Point(12, 585);
            this.trackBar_OX.Maximum = 628;
            this.trackBar_OX.Name = "trackBar_OX";
            this.trackBar_OX.Size = new System.Drawing.Size(647, 45);
            this.trackBar_OX.TabIndex = 2;
            this.trackBar_OX.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_OX.Scroll += new System.EventHandler(this.trackBar1_Scroll);
            // 
            // trackBar_res_OXY
            // 
            this.trackBar_res_OXY.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.trackBar_res_OXY.Location = new System.Drawing.Point(665, 12);
            this.trackBar_res_OXY.Maximum = 628;
            this.trackBar_res_OXY.Name = "trackBar_res_OXY";
            this.trackBar_res_OXY.Orientation = System.Windows.Forms.Orientation.Vertical;
            this.trackBar_res_OXY.Size = new System.Drawing.Size(45, 567);
            this.trackBar_res_OXY.TabIndex = 3;
            this.trackBar_res_OXY.TickStyle = System.Windows.Forms.TickStyle.Both;
            this.trackBar_res_OXY.Scroll += new System.EventHandler(this.trackBar_res_OXY_Scroll);
            // 
            // button_cub
            // 
            this.button_cub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_cub.Location = new System.Drawing.Point(716, 47);
            this.button_cub.Name = "button_cub";
            this.button_cub.Size = new System.Drawing.Size(96, 29);
            this.button_cub.TabIndex = 4;
            this.button_cub.Text = "куб";
            this.button_cub.UseVisualStyleBackColor = true;
            this.button_cub.Click += new System.EventHandler(this.button_cub_Click);
            // 
            // button_circle
            // 
            this.button_circle.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button_circle.Location = new System.Drawing.Point(716, 82);
            this.button_circle.Name = "button_circle";
            this.button_circle.Size = new System.Drawing.Size(96, 29);
            this.button_circle.TabIndex = 5;
            this.button_circle.Text = "сфера";
            this.button_circle.UseVisualStyleBackColor = true;
            this.button_circle.Click += new System.EventHandler(this.button_circle_Click);
            // 
            // Form_main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(824, 642);
            this.Controls.Add(this.button_circle);
            this.Controls.Add(this.button_cub);
            this.Controls.Add(this.trackBar_res_OXY);
            this.Controls.Add(this.trackBar_OX);
            this.Controls.Add(this.button_prism);
            this.Controls.Add(this.pictureBox_main);
            this.Name = "Form_main";
            this.Text = "3D";
            this.Resize += new System.EventHandler(this.Form_main_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox_main)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_OX)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trackBar_res_OXY)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox_main;
        private System.Windows.Forms.Button button_prism;
        private System.Windows.Forms.TrackBar trackBar_OX;
        private System.Windows.Forms.TrackBar trackBar_res_OXY;
        private System.Windows.Forms.Button button_cub;
        private System.Windows.Forms.Button button_circle;
    }
}

