using System;

namespace OrderService
{
    public class OrderDetail
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        public decimal Amount
        {
            get { return UnitPrice * Quantity; }
        }

        public OrderDetail() { }

        public OrderDetail(string productName, decimal unitPrice, int quantity)
        {
            ProductName = productName;
            UnitPrice = unitPrice;
            Quantity = quantity;
        }

        public override bool Equals(object obj)
        {
            return obj is OrderDetail detail &&
                   ProductName == detail.ProductName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName);
        }

        public override string ToString()
        {
            return $"[Product:{ProductName}, UnitPrice:{UnitPrice:C}, Quantity:{Quantity}, Amount:{Amount:C}]";
        }
    }
}