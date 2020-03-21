namespace Assignment2
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.x1TextBox = new System.Windows.Forms.TextBox();
            this.x2TextBox = new System.Windows.Forms.TextBox();
            this.y1TextBox = new System.Windows.Forms.TextBox();
            this.y2TextBox = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "X1 :";
            this.label1.Click += new System.EventHandler(this.Label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 58);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "X2 :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Y1 :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(175, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Y2 :";
            // 
            // x1TextBox
            // 
            this.x1TextBox.Location = new System.Drawing.Point(53, 20);
            this.x1TextBox.Name = "x1TextBox";
            this.x1TextBox.Size = new System.Drawing.Size(100, 26);
            this.x1TextBox.TabIndex = 4;
            // 
            // x2TextBox
            // 
            this.x2TextBox.Location = new System.Drawing.Point(53, 58);
            this.x2TextBox.Name = "x2TextBox";
            this.x2TextBox.Size = new System.Drawing.Size(100, 26);
            this.x2TextBox.TabIndex = 5;
            this.x2TextBox.TextChanged += new System.EventHandler(this.TextBox2_TextChanged);
            // 
            // y1TextBox
            // 
            this.y1TextBox.Location = new System.Drawing.Point(237, 18);
            this.y1TextBox.Name = "y1TextBox";
            this.y1TextBox.Size = new System.Drawing.Size(100, 26);
            this.y1TextBox.TabIndex = 6;
            // 
            // y2TextBox
            // 
            this.y2TextBox.Location = new System.Drawing.Point(237, 58);
            this.y2TextBox.Name = "y2TextBox";
            this.y2TextBox.Size = new System.Drawing.Size(100, 26);
            this.y2TextBox.TabIndex = 7;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(137, 138);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(86, 31);
            this.button1.TabIndex = 8;
            this.button1.Text = "Generate";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.y2TextBox);
            this.Controls.Add(this.y1TextBox);
            this.Controls.Add(this.x2TextBox);
            this.Controls.Add(this.x1TextBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox x1TextBox;
        private System.Windows.Forms.TextBox x2TextBox;
        private System.Windows.Forms.TextBox y1TextBox;
        private System.Windows.Forms.TextBox y2TextBox;
        private System.Windows.Forms.Button button1;
    }
}

