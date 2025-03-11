using System;
using System.Windows.Forms;

namespace CalculatorApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        // 计算按钮的点击事件
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // 获取输入的数字
                double num1 = Convert.ToDouble(txtNumber1.Text);
                double num2 = Convert.ToDouble(txtNumber2.Text);

                // 获取选择的运算符
                string operatorChoice = cmbOperator.SelectedItem.ToString();

                double result = 0;

                // 根据运算符执行相应的计算
                switch (operatorChoice)
                {
                    case "+":
                        result = num1 + num2;
                        break;

                    case "-":
                        result = num1 - num2;
                        break;

                    case "*":
                        result = num1 * num2;
                        break;

                    case "/":
                        if (num2 == 0)
                        {
                            lblResult.Text = "除数不能为零！";
                            return;
                        }
                        result = num1 / num2;
                        break;

                    default:
                        lblResult.Text = "无效的运算符！";
                        return;
                }

                // 显示计算结果
                lblResult.Text = $"结果: {result}";
            }
            catch (FormatException)
            {
                lblResult.Text = "请输入有效的数字！";
            }
        }

        // 窗体加载时设置默认值
        private void Form1_Load(object sender, EventArgs e)
        {
            // 设置默认选择运算符为 "+"
            cmbOperator.SelectedItem = "+";
        }
    }
}
