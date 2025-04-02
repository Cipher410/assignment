using OrderService;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace OrderManagementApp
{
    public partial class OrderEditForm : Form
    {
        public Order EditedOrder { get; private set; }
        private BindingSource detailBindingSource = new BindingSource();

        public OrderEditForm(Order orderToEdit)
        {
            InitializeComponent();

            if (orderToEdit == null)
            {
                // 新建订单
                EditedOrder = new Order
                {
                    OrderId = Guid.NewGuid().ToString(),
                    OrderDate = DateTime.Now,
                    OrderDetails = new List<OrderDetail>()
                };
                Text = "新建订单";
            }
            else
            {
                // 编辑现有订单
                EditedOrder = new Order
                {
                    OrderId = orderToEdit.OrderId,
                    Customer = orderToEdit.Customer,
                    OrderDate = orderToEdit.OrderDate,
                    OrderDetails = new List<OrderDetail>(orderToEdit.OrderDetails)
                };
                Text = "编辑订单";
            }

            InitializeDataBindings();
        }

        private void InitializeDataBindings()
        {
            // 绑定订单基本信息
            txtOrderId.DataBindings.Add("Text", EditedOrder, "OrderId", true, DataSourceUpdateMode.OnPropertyChanged);
            txtCustomer.DataBindings.Add("Text", EditedOrder, "Customer", true, DataSourceUpdateMode.OnPropertyChanged);
            dtpOrderDate.DataBindings.Add("Value", EditedOrder, "OrderDate", true, DataSourceUpdateMode.OnPropertyChanged);

            // 绑定订单明细
            detailBindingSource.DataSource = EditedOrder.OrderDetails;
            dgvDetails.AutoGenerateColumns = false;
            dgvDetails.DataSource = detailBindingSource;

            // 配置明细列
            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ProductName",
                HeaderText = "产品名称",
                Name = "colProductName"
            });

            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "单价",
                Name = "colUnitPrice",
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });

            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Quantity",
                HeaderText = "数量",
                Name = "colQuantity"
            });

            dgvDetails.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Amount",
                HeaderText = "金额",
                Name = "colAmount",
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });
        }

        private void btnAddDetail_Click(object sender, EventArgs e)
        {
            var detail = new OrderDetail
            {
                ProductName = txtProductName.Text,
                UnitPrice = decimal.Parse(txtUnitPrice.Text),
                Quantity = int.Parse(txtQuantity.Text)
            };

            EditedOrder.OrderDetails.Add(detail);
            detailBindingSource.ResetBindings(false);
            CalculateTotal();
        }

        private void btnRemoveDetail_Click(object sender, EventArgs e)
        {
            if (dgvDetails.CurrentRow != null)
            {
                var detail = (OrderDetail)dgvDetails.CurrentRow.DataBoundItem;
                EditedOrder.OrderDetails.Remove(detail);
                detailBindingSource.ResetBindings(false);
                CalculateTotal();
            }
        }

        private void CalculateTotal()
        {
            decimal total = 0;
            foreach (var detail in EditedOrder.OrderDetails)
            {
                total += detail.UnitPrice * detail.Quantity;
            }
            lblTotalAmount.Text = total.ToString("C2");
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(EditedOrder.Customer))
            {
                MessageBox.Show("请输入客户名称", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (EditedOrder.OrderDetails.Count == 0)
            {
                MessageBox.Show("请添加至少一个订单明细", "错误", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void OrderEditForm_Load(object sender, EventArgs e)
        {
            // 设置窗口初始大小
            this.Size = new System.Drawing.Size(800, 600);
        }

        private void txtNumeric_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 只允许输入数字和小数点
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.Handled = true;
            }

            // 只允许一个小数点
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.Handled = true;
            }
        }

        private void txtQuantity_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 只允许输入数字
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}