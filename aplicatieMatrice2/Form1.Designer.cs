namespace aplicatieMatrice2
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
            components = new System.ComponentModel.Container();
            button1 = new Button();
            pictureBox1 = new PictureBox();
            pictureBox2 = new PictureBox();
            textBox1 = new TextBox();
            contextMenuStrip1 = new ContextMenuStrip(components);
            label1 = new Label();
            button2 = new Button();
            textBox2 = new TextBox();
            label2 = new Label();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            button6 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.ActiveCaptionText;
            button1.Font = new Font("Microsoft JhengHei UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button1.ForeColor = SystemColors.Highlight;
            button1.Location = new Point(314, 23);
            button1.Name = "button1";
            button1.Size = new Size(186, 49);
            button1.TabIndex = 0;
            button1.Text = "TO RGB";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.ActiveBorder;
            pictureBox1.Location = new Point(62, 23);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(232, 205);
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = SystemColors.AppWorkspace;
            pictureBox2.Location = new Point(516, 23);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(219, 205);
            pictureBox2.TabIndex = 2;
            pictureBox2.TabStop = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(34, 263);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(294, 23);
            textBox1.TabIndex = 3;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label1.Location = new Point(121, 244);
            label1.Name = "label1";
            label1.Size = new Size(114, 15);
            label1.TabIndex = 5;
            label1.Text = "Cale Imagine Input";
            // 
            // button2
            // 
            button2.Location = new Point(34, 312);
            button2.Name = "button2";
            button2.Size = new Size(109, 23);
            button2.TabIndex = 6;
            button2.Text = "Incarca Imagine";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(475, 263);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(294, 23);
            textBox2.TabIndex = 7;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(584, 245);
            label2.Name = "label2";
            label2.Size = new Size(124, 15);
            label2.TabIndex = 8;
            label2.Text = "Cale Imagine Output";
            // 
            // button3
            // 
            button3.Location = new Point(475, 312);
            button3.Name = "button3";
            button3.Size = new Size(109, 23);
            button3.TabIndex = 9;
            button3.Text = "Salveaza Imagine";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button4
            // 
            button4.BackColor = Color.Indigo;
            button4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button4.ForeColor = Color.Gold;
            button4.Location = new Point(314, 78);
            button4.Name = "button4";
            button4.Size = new Size(186, 49);
            button4.TabIndex = 10;
            button4.Text = "TO ROYAL";
            button4.UseVisualStyleBackColor = false;
            button4.Click += button4_Click;
            // 
            // button5
            // 
            button5.BackColor = Color.LightSlateGray;
            button5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button5.ForeColor = SystemColors.ControlLightLight;
            button5.Location = new Point(314, 133);
            button5.Name = "button5";
            button5.Size = new Size(186, 44);
            button5.TabIndex = 11;
            button5.Text = "TO REMOVE_BACKGROUND";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // button6
            // 
            button6.BackColor = SystemColors.Highlight;
            button6.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            button6.ForeColor = SystemColors.HighlightText;
            button6.Location = new Point(314, 183);
            button6.Name = "button6";
            button6.Size = new Size(186, 45);
            button6.TabIndex = 12;
            button6.Text = "EUROPE SKY";
            button6.UseVisualStyleBackColor = false;
            button6.Click += button6_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(button6);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(label2);
            Controls.Add(textBox2);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(textBox1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Name = "Form1";
            Text = "Filtre Imagini";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private TextBox textBox1;
        private ContextMenuStrip contextMenuStrip1;
        private Label label1;
        private Button button2;
        private TextBox textBox2;
        private Label label2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Button button6;
    }
}
