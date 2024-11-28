namespace WinFormsApp3
{
    partial class Form5
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
            btnEnter = new Button();
            quant = new TextBox();
            label5 = new Label();
            lbl_stock = new Label();
            label3 = new Label();
            lbl_price = new Label();
            lbl_brand = new Label();
            prod_pic = new PictureBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)prod_pic).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(btnEnter);
            panel1.Controls.Add(quant);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(lbl_stock);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(lbl_price);
            panel1.Controls.Add(lbl_brand);
            panel1.Controls.Add(prod_pic);
            panel1.Location = new Point(0, 1);
            panel1.Name = "panel1";
            panel1.Size = new Size(366, 501);
            panel1.TabIndex = 0;
            // 
            // btnEnter
            // 
            btnEnter.BackColor = Color.LightGreen;
            btnEnter.Font = new Font("Segoe UI Black", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnter.Location = new Point(200, 443);
            btnEnter.Name = "btnEnter";
            btnEnter.Size = new Size(152, 47);
            btnEnter.TabIndex = 7;
            btnEnter.Text = "Enter";
            btnEnter.UseVisualStyleBackColor = false;
            btnEnter.Click += btnEnter_Click;
            // 
            // quant
            // 
            quant.BackColor = Color.Silver;
            quant.Location = new Point(104, 397);
            quant.Name = "quant";
            quant.Size = new Size(177, 27);
            quant.TabIndex = 6;
            quant.KeyPress += quant_KeyPress;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(25, 399);
            label5.Name = "label5";
            label5.Size = new Size(72, 25);
            label5.TabIndex = 5;
            label5.Text = "Quality:";
            // 
            // lbl_stock
            // 
            lbl_stock.AutoSize = true;
            lbl_stock.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            lbl_stock.Location = new Point(86, 458);
            lbl_stock.Name = "lbl_stock";
            lbl_stock.Size = new Size(39, 23);
            lbl_stock.TabIndex = 4;
            lbl_stock.Text = "invi";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.Location = new Point(25, 458);
            label3.Name = "label3";
            label3.Size = new Size(55, 23);
            label3.TabIndex = 3;
            label3.Text = "Stock:";
            // 
            // lbl_price
            // 
            lbl_price.AutoSize = true;
            lbl_price.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbl_price.Location = new Point(25, 335);
            lbl_price.Name = "lbl_price";
            lbl_price.Size = new Size(82, 41);
            lbl_price.TabIndex = 2;
            lbl_price.Text = "Price";
            // 
            // lbl_brand
            // 
            lbl_brand.AutoSize = true;
            lbl_brand.Font = new Font("Segoe UI Black", 15F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbl_brand.Location = new Point(25, 289);
            lbl_brand.Name = "lbl_brand";
            lbl_brand.Size = new Size(89, 35);
            lbl_brand.TabIndex = 1;
            lbl_brand.Text = "Brand";
            // 
            // prod_pic
            // 
            prod_pic.BackgroundImageLayout = ImageLayout.Stretch;
            prod_pic.Location = new Point(12, 11);
            prod_pic.Name = "prod_pic";
            prod_pic.Size = new Size(341, 275);
            prod_pic.TabIndex = 0;
            prod_pic.TabStop = false;
            prod_pic.Click += prod_pic_Click;
            // 
            // Form5
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(364, 503);
            Controls.Add(panel1);
            Name = "Form5";
            Text = "Form5";
            Leave += Form5_Leave;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)prod_pic).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label lbl_stock;
        private Label label3;
        private Label lbl_price;
        private Label lbl_brand;
        private PictureBox prod_pic;
        private Button btnEnter;
        private TextBox quant;
        private Label label5;
    }
}