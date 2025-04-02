using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderService
{
    public class Order
    {
        public string OrderId { get; set; }
        public string Customer { get; set; }
        public DateTime OrderDate { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        public decimal TotalAmount
        {
            get { return OrderDetails.Sum(d => d.Amount); }
        }

        public Order()
        {
            OrderId = Guid.NewGuid().ToString();
            OrderDate = DateTime.Now;
        }

        public void AddDetail(OrderDetail detail)
        {
            if (OrderDetails.Contains(detail))
            {
                throw new ApplicationException($"The product ({detail.ProductName}) already exists in this order!");
            }
            OrderDetails.Add(detail);
        }

        public void RemoveDetail(OrderDetail detail)
        {
            OrderDetails.Remove(detail);
        }

        public override bool Equals(object obj)
        {
            return obj is Order order &&
                   OrderId == order.OrderId;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(OrderId);
        }

        public override string ToString()
        {
            string details = string.Join("\n", OrderDetails);
            return $"OrderID:{OrderId}, Customer:{Customer}, OrderDate:{OrderDate:yyyy-MM-dd}\nDetails:\n{details}\nTotal:{TotalAmount:C}";
        }
    }
}