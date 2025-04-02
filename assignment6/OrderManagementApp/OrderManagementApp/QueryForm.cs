using System;
using System.Windows.Forms;

namespace OrderManagementApp
{
    public partial class QueryForm : Form
    {
        public string CustomerName { get; private set; }
        public string ProductName { get; private set; }
        public decimal MinTotalAmount { get; private set; }

        public QueryForm()
        {
            InitializeComponent();
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            CustomerName = txtCustomerName.Text.Trim();
            ProductName = txtProductName.Text.Trim();

            if (decimal.TryParse(txtMinTotalAmount.Text, out decimal minTotal))
            {
                MinTotalAmount = minTotal;
            }
            else
            {
                MinTotalAmount = 0;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}