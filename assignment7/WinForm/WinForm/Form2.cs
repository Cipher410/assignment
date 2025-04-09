using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static c__11_winform.Program;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace c__11_winform
{
    public partial class Form2 : Form
    {
        //OrderService orders2 = new OrderService();
        public Form2()
        {
            InitializeComponent();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string NameOfCustomer = textBox1.Text;
            string NameOfGoods = textBox2.Text;
            int Number = int.TryParse(textBox3.Text, out Number)
                ? Convert.ToInt32(textBox3.Text) : -1;
            double price = double.TryParse(textBox4.Text, out price)
                ? Convert.ToDouble(textBox4.Text) : -1.0;
            if (Number <= 0 || price <= 0.0) MessageBox.Show("错误，单价或数量必须为正数");
            else
            {
                orderservice.addorder(NameOfGoods, NameOfCustomer, Number, price);
                MessageBox.Show("完成添加");
            }
        }
    }
}