using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderService
{
    public class OrderService
    {
        private readonly List<Order> orders = new List<Order>();

        public OrderService()
        {
            // 初始化一些测试数据
            InitializeTestData();
        }

        private void InitializeTestData()
        {
            var order1 = new Order { Customer = "张三", OrderDate = DateTime.Parse("2023-01-01") };
            order1.AddDetail(new OrderDetail("手机", 2999m, 1));
            order1.AddDetail(new OrderDetail("耳机", 399m, 2));

            var order2 = new Order { Customer = "李四", OrderDate = DateTime.Parse("2023-01-02") };
            order2.AddDetail(new OrderDetail("笔记本电脑", 8999m, 1));
            order2.AddDetail(new OrderDetail("鼠标", 199m, 1));

            var order3 = new Order { Customer = "王五", OrderDate = DateTime.Parse("2023-01-03") };
            order3.AddDetail(new OrderDetail("平板电脑", 4999m, 1));
            order3.AddDetail(new OrderDetail("键盘", 299m, 1));
            order3.AddDetail(new OrderDetail("保护套", 99m, 2));

            orders.AddRange(new[] { order1, order2, order3 });
        }

        // 添加订单
        public void AddOrder(Order order)
        {
            if (orders.Contains(order))
            {
                throw new ApplicationException($"Order {order.OrderId} already exists!");
            }
            orders.Add(order);
        }

        // 删除订单
        public void DeleteOrder(string orderId)
        {
            var order = orders.FirstOrDefault(o => o.OrderId == orderId);
            if (order == null)
            {
                throw new ApplicationException($"Order {orderId} not found!");
            }
            orders.Remove(order);
        }

        // 更新订单
        public void UpdateOrder(Order newOrder)
        {
            var oldOrder = orders.FirstOrDefault(o => o.OrderId == newOrder.OrderId);
            if (oldOrder == null)
            {
                throw new ApplicationException($"Order {newOrder.OrderId} not found!");
            }
            orders.Remove(oldOrder);
            orders.Add(newOrder);
        }

        // 获取所有订单
        public List<Order> GetAllOrders()
        {
            return orders.OrderByDescending(o => o.OrderDate).ToList();
        }

        // 根据ID查询订单
        public Order GetOrderById(string orderId)
        {
            return orders.FirstOrDefault(o => o.OrderId == orderId);
        }

        // 查询订单
        public List<Order> QueryOrders(string customerName = null, string productName = null, decimal minTotalAmount = 0)
        {
            var query = orders.AsEnumerable();

            if (!string.IsNullOrWhiteSpace(customerName))
            {
                query = query.Where(o => o.Customer.Contains(customerName));
            }

            if (!string.IsNullOrWhiteSpace(productName))
            {
                query = query.Where(o => o.OrderDetails.Any(d => d.ProductName.Contains(productName)));
            }

            if (minTotalAmount > 0)
            {
                query = query.Where(o => o.TotalAmount >= minTotalAmount);
            }

            return query.OrderByDescending(o => o.OrderDate).ToList();
        }

        // 按总金额排序查询
        public List<Order> QueryOrdersByAmount(bool ascending = false)
        {
            if (ascending)
            {
                return orders.OrderBy(o => o.TotalAmount).ToList();
            }
            else
            {
                return orders.OrderByDescending(o => o.TotalAmount).ToList();
            }
        }

        // 按客户名排序查询
        public List<Order> QueryOrdersByCustomer(bool ascending = true)
        {
            if (ascending)
            {
                return orders.OrderBy(o => o.Customer).ToList();
            }
            else
            {
                return orders.OrderByDescending(o => o.Customer).ToList();
            }
        }
    }
}