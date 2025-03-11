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

        // ���㰴ť�ĵ���¼�
        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                // ��ȡ���������
                double num1 = Convert.ToDouble(txtNumber1.Text);
                double num2 = Convert.ToDouble(txtNumber2.Text);

                // ��ȡѡ��������
                string operatorChoice = cmbOperator.SelectedItem.ToString();

                double result = 0;

                // ���������ִ����Ӧ�ļ���
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
                            lblResult.Text = "��������Ϊ�㣡";
                            return;
                        }
                        result = num1 / num2;
                        break;

                    default:
                        lblResult.Text = "��Ч���������";
                        return;
                }

                // ��ʾ������
                lblResult.Text = $"���: {result}";
            }
            catch (FormatException)
            {
                lblResult.Text = "��������Ч�����֣�";
            }
        }

        // �������ʱ����Ĭ��ֵ
        private void Form1_Load(object sender, EventArgs e)
        {
            // ����Ĭ��ѡ�������Ϊ "+"
            cmbOperator.SelectedItem = "+";
        }
    }
}
