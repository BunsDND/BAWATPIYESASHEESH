namespace WinFormsApp3
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            enter = new Button();
            SuspendLayout();
            // 
            // enter
            // 
            enter.BackgroundImage = Properties.Resources.piyesa;
            enter.BackgroundImageLayout = ImageLayout.Zoom;
            enter.ForeColor = SystemColors.ControlLightLight;
            enter.Location = new Point(255, 172);
            enter.Margin = new Padding(3, 4, 3, 4);
            enter.Name = "enter";
            enter.Size = new Size(401, 224);
            enter.TabIndex = 1;
            enter.UseVisualStyleBackColor = true;
            enter.Click += enter_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(914, 600);
            Controls.Add(enter);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button enter;
    }
}
