namespace WinFormsApp3
{
    partial class UserControl1
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            label3 = new Label();
            label_price = new Label();
            label_name = new Label();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label_price);
            panel1.Controls.Add(label_name);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(6, 6);
            panel1.Name = "panel1";
            panel1.Size = new Size(260, 256);
            panel1.TabIndex = 0;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(144, 205);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 1;
            label3.Text = "label1";
            // 
            // label_price
            // 
            label_price.AutoSize = true;
            label_price.Location = new Point(27, 223);
            label_price.Name = "label_price";
            label_price.Size = new Size(50, 20);
            label_price.TabIndex = 1;
            label_price.Text = "label1";
            // 
            // label_name
            // 
            label_name.AutoSize = true;
            label_name.Location = new Point(27, 189);
            label_name.Name = "label_name";
            label_name.Size = new Size(50, 20);
            label_name.TabIndex = 1;
            label_name.Text = "label1";
            // 
            // pictureBox1
            // 
            pictureBox1.Location = new Point(12, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(231, 163);
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // UserControl1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Name = "UserControl1";
            Size = new Size(270, 265);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label_name;
        private PictureBox pictureBox1;
        private Label label3;
        private Label label_price;
    }
}
