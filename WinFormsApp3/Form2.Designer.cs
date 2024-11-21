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
            panel1 = new Panel();
            enter = new Button();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            password = new MaskedTextBox();
            username = new TextBox();
            pictureBox1 = new PictureBox();
            label5 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label5);
            panel1.Controls.Add(enter);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(password);
            panel1.Controls.Add(username);
            panel1.Controls.Add(pictureBox1);
            panel1.Location = new Point(248, 32);
            panel1.Name = "panel1";
            panel1.Size = new Size(326, 364);
            panel1.TabIndex = 0;
            // 
            // enter
            // 
            enter.BackColor = Color.PaleGreen;
            enter.Location = new Point(105, 329);
            enter.Name = "enter";
            enter.Size = new Size(75, 23);
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
            label4.Location = new Point(199, 302);
            label4.Name = "label4";
            label4.Size = new Size(33, 15);
            label4.TabIndex = 6;
            label4.Text = "here.";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(76, 302);
            label3.Name = "label3";
            label3.Size = new Size(126, 15);
            label3.TabIndex = 5;
            label3.Text = "Make another account";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(59, 234);
            label2.Name = "label2";
            label2.Size = new Size(60, 15);
            label2.TabIndex = 4;
            label2.Text = "Password:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(59, 173);
            label1.Name = "label1";
            label1.Size = new Size(63, 15);
            label1.TabIndex = 3;
            label1.Text = "Username:";
            // 
            // password
            // 
            password.BackColor = SystemColors.ScrollBar;
            password.Location = new Point(59, 252);
            password.Name = "password";
            password.PasswordChar = '*';
            password.Size = new Size(194, 23);
            password.TabIndex = 2;
            password.UseSystemPasswordChar = true;
            // 
            // username
            // 
            username.BackColor = SystemColors.ScrollBar;
            username.Location = new Point(59, 191);
            username.Name = "username";
            username.Size = new Size(194, 23);
            username.TabIndex = 1;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            pictureBox1.Image = Properties.Resources.piyesa;
            pictureBox1.Location = new Point(76, 22);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(177, 112);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(59, 149);
            label5.Name = "label5";
            label5.Size = new Size(0, 15);
            label5.TabIndex = 8;
            label5.Click += label5_Click;
            this.label5.Click += new System.EventHandler(this.label5_Click);

            // 
            // Form2
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(panel1);
            Name = "Form2";
            Text = "Form2";
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