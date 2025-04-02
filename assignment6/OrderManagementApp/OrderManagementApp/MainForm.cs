using OrderService;
using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace OrderManagementApp
{
    public partial class MainForm : Form
    {
        private OrderService.OrderService orderService = new OrderService.OrderService();
        private BindingSource orderBindingSource = new BindingSource();
        private BindingSource orderDetailBindingSource = new BindingSource();

        public MainForm()
        {
            InitializeComponent();
            InitializeDataBindings();
            LoadOrders();
        }

        private void InitializeDataBindings()
        {
            // 设置主从数据绑定
            orderBindingSource.DataSource = typeof(Order);
            orderDetailBindingSource.DataSource = orderBindingSource;
            orderDetailBindingSource.DataMember = "OrderDetails";

            // 绑定主表到DataGridView
            dgvOrders.AutoGenerateColumns = false;
            dgvOrders.DataSource = orderBindingSource;

            // 绑定从表到DataGridView
            dgvOrderDetails.AutoGenerateColumns = false;
            dgvOrderDetails.DataSource = orderDetailBindingSource;

            // 配置订单列表列
            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "OrderId",
                HeaderText = "订单号",
                Name = "colOrderId"
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Customer",
                HeaderText = "客户",
                Name = "colCustomer"
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "OrderDate",
                HeaderText = "日期",
                Name = "colOrderDate",
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "yyyy-MM-dd" }
            });

            dgvOrders.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "TotalAmount",
                HeaderText = "总金额",
                Name = "colTotalAmount",
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });

            // 配置订单明细列
            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "ProductName",
                HeaderText = "产品名称",
                Name = "colProductName"
            });

            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "UnitPrice",
                HeaderText = "单价",
                Name = "colUnitPrice",
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });

            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Quantity",
                HeaderText = "数量",
                Name = "colQuantity"
            });

            dgvOrderDetails.Columns.Add(new DataGridViewTextBoxColumn()
            {
                DataPropertyName = "Amount",
                HeaderText = "金额",
                Name = "colAmount",
                DefaultCellStyle = new DataGridViewCellStyle() { Format = "C2" }
            });
        }

        private void LoadOrders()
        {
            var orders = orderService.GetAllOrders().OrderByDescending(o => o.OrderDate).ToList();
            orderBindingSource.DataSource = orders;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            var editForm = new OrderEditForm(null);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                orderService.AddOrder(editForm.EditedOrder);
                LoadOrders();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current == null)
            {
                MessageBox.Show("请先选择要修改的订单", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var currentOrder = (Order)orderBindingSource.Current;
            var editForm = new OrderEditForm(currentOrder);
            if (editForm.ShowDialog() == DialogResult.OK)
            {
                orderService.UpdateOrder(editForm.EditedOrder);
                LoadOrders();
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (orderBindingSource.Current == null)
            {
                MessageBox.Show("请先选择要删除的订单", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (MessageBox.Show("确定要删除选中的订单吗?", "确认删除", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var currentOrder = (Order)orderBindingSource.Current;
                orderService.DeleteOrder(currentOrder.OrderId);
                LoadOrders();
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            var queryForm = new QueryForm();
            if (queryForm.ShowDialog() == DialogResult.OK)
            {
                var orders = orderService.QueryOrders(
                    queryForm.CustomerName,
                    queryForm.ProductName,
                    queryForm.MinTotalAmount);

                orderBindingSource.DataSource = orders;
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadOrders();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // 设置窗口初始大小和布局
            this.WindowState = FormWindowState.Maximized;
        }

        private void MainForm_SizeChanged(object sender, EventArgs e)
        {
            // 调整控件大小以适应窗口变化
            int margin = 10;
            int buttonHeight = 40;
            int buttonWidth = 100;

            btnAdd.Location = new System.Drawing.Point(margin, margin);
            btnEdit.Location = new System.Drawing.Point(btnAdd.Right + margin, margin);
            btnDelete.Location = new System.Drawing.Point(btnEdit.Right + margin, margin);
            btnQuery.Location = new System.Drawing.Point(btnDelete.Right + margin, margin);
            btnRefresh.Location = new System.Drawing.Point(btnQuery.Right + margin, margin);

            dgvOrders.Location = new System.Drawing.Point(margin, buttonHeight + margin * 2);
            dgvOrders.Width = this.ClientSize.Width - margin * 2;
            dgvOrders.Height = (this.ClientSize.Height - buttonHeight - margin * 4) * 2 / 3;

            dgvOrderDetails.Location = new System.Drawing.Point(margin, dgvOrders.Bottom + margin);
            dgvOrderDetails.Width = this.ClientSize.Width - margin * 2;
            dgvOrderDetails.Height = this.ClientSize.Height - dgvOrders.Bottom - margin * 3;
        }
    }
}