using static System.Net.Mime.MediaTypeNames;
using System.Windows.Forms;
using System.Xml.Linq;

namespace c__11_winform
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
            panel1 = new Panel();
            label15 = new Label();
            label14 = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            label1 = new Label();
            panel2 = new Panel();
            textBox2 = new TextBox();
            textBox1 = new TextBox();
            button4 = new Button();
            button3 = new Button();
            button2 = new Button();
            button1 = new Button();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(label15);
            panel1.Controls.Add(label14);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(702, 744);
            panel1.TabIndex = 0;
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(62, 661);
            label15.Name = "label15";
            label15.Size = new Size(74, 24);
            label15.TabIndex = 14;
            label15.Text = "label15";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(62, 564);
            label14.Name = "label14";
            label14.Size = new Size(82, 24);
            label14.TabIndex = 13;
            label14.Text = "订单时间";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(462, 464);
            label13.Name = "label13";
            label13.Size = new Size(74, 24);
            label13.TabIndex = 12;
            label13.Text = "label13";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(254, 464);
            label12.Name = "label12";
            label12.Size = new Size(74, 24);
            label12.TabIndex = 11;
            label12.Text = "label12";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(70, 464);
            label11.Name = "label11";
            label11.Size = new Size(74, 24);
            label11.TabIndex = 10;
            label11.Text = "label11";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(464, 345);
            label10.Name = "label10";
            label10.Size = new Size(46, 24);
            label10.TabIndex = 9;
            label10.Text = "总价";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(265, 345);
            label9.Name = "label9";
            label9.Size = new Size(46, 24);
            label9.TabIndex = 8;
            label9.Text = "数量";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(74, 345);
            label8.Name = "label8";
            label8.Size = new Size(46, 24);
            label8.TabIndex = 7;
            label8.Text = "单价";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(464, 218);
            label7.Name = "label7";
            label7.Size = new Size(63, 24);
            label7.TabIndex = 6;
            label7.Text = "label7";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(267, 218);
            label6.Name = "label6";
            label6.Size = new Size(63, 24);
            label6.TabIndex = 5;
            label6.Text = "label6";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(62, 218);
            label5.Name = "label5";
            label5.Size = new Size(63, 24);
            label5.TabIndex = 4;
            label5.Text = "label5";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(462, 109);
            label4.Name = "label4";
            label4.Size = new Size(65, 24);
            label4.TabIndex = 3;
            label4.Text = "订单ID";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(264, 109);
            label3.Name = "label3";
            label3.Size = new Size(64, 24);
            label3.TabIndex = 2;
            label3.Text = "商品名";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(44, 109);
            label2.Name = "label2";
            label2.Size = new Size(100, 24);
            label2.TabIndex = 1;
            label2.Text = "消费者姓名";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(248, 41);
            label1.Name = "label1";
            label1.Size = new Size(82, 24);
            label1.TabIndex = 0;
            label1.Text = "订单数据";
            // 
            // panel2
            // 
            panel2.Controls.Add(textBox2);
            panel2.Controls.Add(textBox1);
            panel2.Controls.Add(button4);
            panel2.Controls.Add(button3);
            panel2.Controls.Add(button2);
            panel2.Controls.Add(button1);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(697, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(681, 744);
            panel2.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(433, 410);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(120, 30);
            textBox2.TabIndex = 7;
            textBox2.Text = "输入ID";
            textBox2.TextAlign = HorizontalAlignment.Center;
            textBox2.UseWaitCursor = true;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(104, 410);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(130, 30);
            textBox1.TabIndex = 5;
            textBox1.Text = "输入ID";
            // 
            // button4
            // 
            button4.Location = new Point(395, 464);
            button4.Name = "button4";
            button4.Size = new Size(180, 89);
            button4.TabIndex = 3;
            button4.Text = "查找订单";
            button4.UseVisualStyleBackColor = true;
            button4.Click += button4_Click;
            // 
            // button3
            // 
            button3.Location = new Point(89, 464);
            button3.Name = "button3";
            button3.Size = new Size(180, 89);
            button3.TabIndex = 2;
            button3.Text = "删除订单";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // button2
            // 
            button2.Location = new Point(395, 77);
            button2.Name = "button2";
            button2.Size = new Size(180, 89);
            button2.TabIndex = 1;
            button2.Text = "修改订单";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button1
            // 
            button1.Location = new Point(89, 77);
            button1.Name = "button1";
            button1.Size = new Size(180, 89);
            button1.TabIndex = 0;
            button1.Text = "新增订单";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 24F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1378, 744);
            Controls.Add(panel2);
            Controls.Add(panel1);
            MaximumSize = new Size(1400, 800);
            MinimumSize = new Size(1400, 800);
            Name = "Form1";
            Text = "Form1";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private Button button2;
        private Button button1;
        private Button button4;
        private Button button3;
        private TextBox textBox1;
        private TextBox textBox2;

        private Label label4;
        private Label label3;
        private Label label2;
        private Label label1;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label label15;
        private Label label14;
    }
}