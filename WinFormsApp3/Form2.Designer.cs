namespace WinFormsApp3
{
    partial class Form2
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form2));
            panel1 = new Panel();
            label5 = new Label();
            enter = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            password = new MaskedTextBox();
            username = new TextBox();
            pictureBox1 = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Anchor = AnchorStyles.None;
            panel1.BackColor = Color.White;
            panel1.BorderStyle = BorderStyle.Fixed3D;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(enter);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(password);
            panel1.Controls.Add(username);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(283, 43);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(373, 485);
            panel1.TabIndex = 0;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.ForeColor = Color.Red;
            label5.Location = new Point(67, 199);
            label5.Name = "label5";
            label5.Size = new Size(0, 20);
            label5.TabIndex = 8;
            label5.Click += label5_Click;
            // 
            // enter
            // 
            enter.BackColor = Color.PaleGreen;
            enter.Location = new Point(120, 439);
            enter.Margin = new Padding(3, 4, 3, 4);
            enter.Name = "enter";
            enter.Size = new Size(86, 31);
            enter.TabIndex = 7;
            enter.Text = "ENTER";
            enter.UseVisualStyleBackColor = false;
            enter.Click += enter_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Transparent;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Underline, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Indigo;
            label4.Location = new Point(227, 403);
            label4.Name = "label4";
            label4.Size = new Size(41, 20);
            label4.TabIndex = 6;
            label4.Text = "here.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(76, 403);
            label3.Name = "label3";
            label3.Size = new Size(156, 20);
            label3.TabIndex = 5;
            label3.Text = "Make another account";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 312);
            label2.Name = "label2";
            label2.Size = new Size(73, 20);
            label2.TabIndex = 4;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 231);
            label1.Name = "label1";
            label1.Size = new Size(78, 20);
            label1.TabIndex = 3;
            label1.Text = "Username:";
            // 
            // password
            // 
            password.BackColor = SystemColors.ScrollBar;
            password.Location = new Point(67, 336);
            password.Margin = new Padding(3, 4, 3, 4);
            password.Name = "password";
            password.PasswordChar = '*';
            password.Size = new Size(221, 27);
            password.TabIndex = 2;
            password.UseSystemPasswordChar = true;
            // 
            // username
            // 
            username.BackColor = SystemColors.ScrollBar;
            username.Location = new Point(67, 255);
            username.Margin = new Padding(3, 4, 3, 4);
            username.Name = "username";
            username.Size = new Size(221, 27);
            username.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.piyesa;
            pictureBox1.Location = new Point(86, 50);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(202, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = (Image)resources.GetObject("$this.BackgroundImage");
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(914, 600);
            Controls.Add(panel1);
            DoubleBuffered = true;
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form2";
            Text = "Form2";
            WindowState = FormWindowState.Maximized;
            FormClosed += Form2_FormClosed;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private PictureBox pictureBox1;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private MaskedTextBox password;
        private TextBox username;
        private Button enter;
        private Label label5;
    }
}