using System;
using System.Collections.Generic;
using System.Linq;

// 商品类
public class Product
{
    public string Id { get; set; }
    public string Name { get; set; }
    public decimal Price { get; set; }

    public Product(string id, string name, decimal price)
    {
        Id = id;
        Name = name;
        Price = price;
    }

    public override string ToString()
    {
        return $"商品ID: {Id}, 名称: {Name}, 价格: {Price:C}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Product other)
        {
            return Id == other.Id && Name == other.Name && Price == other.Price;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Price);
    }
}

// 客户类
public class Customer
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Contact { get; set; }

    public Customer(string id, string name, string contact)
    {
        Id = id;
        Name = name;
        Contact = contact;
    }

    public override string ToString()
    {
        return $"客户ID: {Id}, 姓名: {Name}, 联系方式: {Contact}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Customer other)
        {
            return Id == other.Id && Name == other.Name && Contact == other.Contact;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Name, Contact);
    }
}

// 订单明细类
public class OrderDetail
{
    public Product Product { get; set; }
    public int Quantity { get; set; }
    public decimal Amount => Product.Price * Quantity;

    public OrderDetail(Product product, int quantity)
    {
        Product = product;
        Quantity = quantity;
    }

    public override string ToString()
    {
        return $"{Product}, 数量: {Quantity}, 小计: {Amount:C}";
    }

    public override bool Equals(object obj)
    {
        if (obj is OrderDetail other)
        {
            return Product.Equals(other.Product) && Quantity == other.Quantity;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Product, Quantity);
    }
}

// 订单类
public class Order : IComparable<Order>
{
    public string Id { get; set; }
    public Customer Customer { get; set; }
    public List<OrderDetail> Details { get; set; } = new List<OrderDetail>();
    public DateTime OrderTime { get; set; }
    public decimal TotalAmount => Details.Sum(d => d.Amount);

    public Order(string id, Customer customer)
    {
        Id = id;
        Customer = customer;
        OrderTime = DateTime.Now;
    }

    public void AddDetail(OrderDetail detail)
    {
        if (Details.Contains(detail))
        {
            throw new ArgumentException("订单明细已存在!");
        }
        Details.Add(detail);
    }

    public void RemoveDetail(Product product)
    {
        var detail = Details.FirstOrDefault(d => d.Product.Equals(product));
        if (detail == null)
        {
            throw new ArgumentException("订单中不存在该商品的明细!");
        }
        Details.Remove(detail);
    }

    public override string ToString()
    {
        var detailsStr = string.Join("\n  ", Details.Select(d => d.ToString()));
        return $"订单号: {Id}, 下单时间: {OrderTime:yyyy-MM-dd HH:mm:ss}\n" +
               $"客户信息: {Customer}\n" +
               $"订单明细:\n  {detailsStr}\n" +
               $"总金额: {TotalAmount:C}";
    }

    public override bool Equals(object obj)
    {
        if (obj is Order other)
        {
            return Id == other.Id && Customer.Equals(other.Customer) &&
                   Details.SequenceEqual(other.Details);
        }
        return false;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Id, Customer, Details);
    }

    public int CompareTo(Order other)
    {
        return Id.CompareTo(other.Id);
    }
}

// 订单服务类
public class OrderService
{
    private List<Order> orders = new List<Order>();

    // 添加订单
    public void AddOrder(Order order)
    {
        if (orders.Contains(order))
        {
            throw new ArgumentException("订单已存在!");
        }
        orders.Add(order);
    }

    // 删除订单
    public void RemoveOrder(string orderId)
    {
        var order = orders.FirstOrDefault(o => o.Id == orderId);
        if (order == null)
        {
            throw new ArgumentException($"订单 {orderId} 不存在!");
        }
        orders.Remove(order);
    }

    // 修改订单
    public void UpdateOrder(Order order)
    {
        var existingOrder = orders.FirstOrDefault(o => o.Id == order.Id);
        if (existingOrder == null)
        {
            throw new ArgumentException($"订单 {order.Id} 不存在!");
        }
        orders.Remove(existingOrder);
        orders.Add(order);
    }

    // 查询所有订单
    public List<Order> GetAllOrders()
    {
        return orders.OrderBy(o => o.TotalAmount).ToList();
    }

    // 按订单号查询
    public List<Order> QueryByOrderId(string orderId)
    {
        return orders.Where(o => o.Id.Contains(orderId))
                     .OrderBy(o => o.TotalAmount)
                     .ToList();
    }

    // 按商品名称查询
    public List<Order> QueryByProductName(string productName)
    {
        return orders.Where(o => o.Details.Any(d => d.Product.Name.Contains(productName)))
                     .OrderBy(o => o.TotalAmount)
                     .ToList();
    }

    // 按客户查询
    public List<Order> QueryByCustomer(string customerName)
    {
        return orders.Where(o => o.Customer.Name.Contains(customerName))
                     .OrderBy(o => o.TotalAmount)
                     .ToList();
    }

    // 按金额范围查询
    public List<Order> QueryByAmountRange(decimal min, decimal max)
    {
        return orders.Where(o => o.TotalAmount >= min && o.TotalAmount <= max)
                     .OrderBy(o => o.TotalAmount)
                     .ToList();
    }

    // 排序方法
    public void SortOrders()
    {
        orders.Sort();
    }

    // 自定义排序方法
    public void SortOrders(Func<Order, Order, int> comparer)
    {
        orders.Sort((x, y) => comparer(x, y));
    }

    // 导出订单到文件
    public void Export(string filePath)
    {
        System.IO.File.WriteAllText(filePath, string.Join("\n\n", orders.Select(o => o.ToString())));
    }

    // 从文件导入订单
    public void Import(string filePath)
    {
        // 简单实现，实际应用中需要更复杂的解析逻辑
        throw new NotImplementedException("导入功能尚未实现");
    }
}

// 测试类
public class OrderServiceTests
{
    private OrderService service;
    private Product p1, p2;
    private Customer c1, c2;
    private Order o1, o2, o3;

    public OrderServiceTests()
    {
        service = new OrderService();

        p1 = new Product("P001", "笔记本电脑", 5999m);
        p2 = new Product("P002", "手机", 3999m);

        c1 = new Customer("C001", "张三", "13800138000");
        c2 = new Customer("C002", "李四", "13900139000");

        o1 = new Order("O001", c1);
        o1.AddDetail(new OrderDetail(p1, 1));
        o1.AddDetail(new OrderDetail(p2, 2));

        o2 = new Order("O002", c2);
        o2.AddDetail(new OrderDetail(p1, 2));

        o3 = new Order("O003", c1);
        o3.AddDetail(new OrderDetail(p2, 3));
    }

    public void TestAddOrder()
    {
        service.AddOrder(o1);
        service.AddOrder(o2);
        service.AddOrder(o3);

        Console.WriteLine("添加订单测试通过");
    }

    public void TestAddDuplicateOrder()
    {
        try
        {
            service.AddOrder(o1);
            Console.WriteLine("添加重复订单测试失败");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"添加重复订单测试通过: {e.Message}");
        }
    }

    public void TestRemoveOrder()
    {
        service.RemoveOrder("O001");

        try
        {
            service.RemoveOrder("O999");
            Console.WriteLine("删除不存在的订单测试失败");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"删除订单测试通过: {e.Message}");
        }
    }

    public void TestUpdateOrder()
    {
        var newOrder = new Order("O002", c1);
        newOrder.AddDetail(new OrderDetail(p2, 5));
        service.UpdateOrder(newOrder);

        try
        {
            service.UpdateOrder(new Order("O999", c1));
            Console.WriteLine("更新不存在的订单测试失败");
        }
        catch (ArgumentException e)
        {
            Console.WriteLine($"更新订单测试通过: {e.Message}");
        }
    }

    public void TestQueryMethods()
    {
        Console.WriteLine("\n按订单号查询:");
        service.QueryByOrderId("O00").ForEach(Console.WriteLine);

        Console.WriteLine("\n按商品名称查询:");
        service.QueryByProductName("手机").ForEach(Console.WriteLine);

        Console.WriteLine("\n按客户查询:");
        service.QueryByCustomer("张三").ForEach(Console.WriteLine);

        Console.WriteLine("\n按金额范围查询:");
        service.QueryByAmountRange(10000, 20000).ForEach(Console.WriteLine);
    }

    public void RunAllTests()
    {
        TestAddOrder();
        TestAddDuplicateOrder();
        TestRemoveOrder();
        TestUpdateOrder();
        TestQueryMethods();
    }
}

// 主程序
class Program
{
    static void Main(string[] args)
    {
        // 运行测试
        var tester = new OrderServiceTests();
        tester.RunAllTests();

        // 创建订单服务实例
        var orderService = new OrderService();

        // 添加一些示例数据
        var p1 = new Product("P001", "笔记本电脑", 5999m);
        var p2 = new Product("P002", "手机", 3999m);
        var p3 = new Product("P003", "耳机", 599m);

        var c1 = new Customer("C001", "张三", "13800138000");
        var c2 = new Customer("C002", "李四", "13900139000");

        var o1 = new Order("O001", c1);
        o1.AddDetail(new OrderDetail(p1, 1));
        o1.AddDetail(new OrderDetail(p2, 2));

        var o2 = new Order("O002", c2);
        o2.AddDetail(new OrderDetail(p1, 2));

        var o3 = new Order("O003", c1);
        o3.AddDetail(new OrderDetail(p2, 3));
        o3.AddDetail(new OrderDetail(p3, 5));

        try
        {
            orderService.AddOrder(o1);
            orderService.AddOrder(o2);
            orderService.AddOrder(o3);
        }
        catch (Exception e)
        {
            Console.WriteLine($"添加订单时出错: {e.Message}");
        }

        // 主菜单
        while (true)
        {
            Console.WriteLine("\n订单管理系统");
            Console.WriteLine("1. 添加订单");
            Console.WriteLine("2. 删除订单");
            Console.WriteLine("3. 修改订单");
            Console.WriteLine("4. 查询订单");
            Console.WriteLine("5. 显示所有订单");
            Console.WriteLine("6. 排序订单");
            Console.WriteLine("7. 导出订单");
            Console.WriteLine("8. 退出");
            Console.Write("请选择操作: ");

            if (!int.TryParse(Console.ReadLine(), out int choice))
            {
                Console.WriteLine("无效输入，请重新选择!");
                continue;
            }

            try
            {
                switch (choice)
                {
                    case 1: // 添加订单
                        AddOrder(orderService);
                        break;
                    case 2: // 删除订单
                        DeleteOrder(orderService);
                        break;
                    case 3: // 修改订单
                        UpdateOrder(orderService);
                        break;
                    case 4: // 查询订单
                        QueryOrders(orderService);
                        break;
                    case 5: // 显示所有订单
                        DisplayAllOrders(orderService);
                        break;
                    case 6: // 排序订单
                        SortOrders(orderService);
                        break;
                    case 7: // 导出订单
                        ExportOrders(orderService);
                        break;
                    case 8: // 退出
                        return;
                    default:
                        Console.WriteLine("无效选择，请重新输入!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"操作出错: {e.Message}");
            }
        }
    }

    static void AddOrder(OrderService service)
    {
        Console.Write("输入订单号: ");
        var orderId = Console.ReadLine();

        Console.Write("输入客户ID: ");
        var customerId = Console.ReadLine();
        Console.Write("输入客户姓名: ");
        var customerName = Console.ReadLine();
        Console.Write("输入客户联系方式: ");
        var contact = Console.ReadLine();

        var customer = new Customer(customerId, customerName, contact);
        var order = new Order(orderId, customer);

        while (true)
        {
            Console.Write("输入商品ID(输入空行结束): ");
            var productId = Console.ReadLine();
            if (string.IsNullOrEmpty(productId)) break;

            Console.Write("输入商品名称: ");
            var productName = Console.ReadLine();
            Console.Write("输入商品价格: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("输入商品数量: ");
            int quantity = int.Parse(Console.ReadLine());

            var product = new Product(productId, productName, price);
            var detail = new OrderDetail(product, quantity);

            try
            {
                order.AddDetail(detail);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"添加明细失败: {e.Message}");
            }
        }

        service.AddOrder(order);
        Console.WriteLine("订单添加成功!");
    }

    static void DeleteOrder(OrderService service)
    {
        Console.Write("输入要删除的订单号: ");
        var orderId = Console.ReadLine();

        service.RemoveOrder(orderId);
        Console.WriteLine("订单删除成功!");
    }

    static void UpdateOrder(OrderService service)
    {
        Console.Write("输入要修改的订单号: ");
        var orderId = Console.ReadLine();

        // 查找现有订单
        var existingOrders = service.QueryByOrderId(orderId);
        if (existingOrders.Count == 0)
        {
            Console.WriteLine("订单不存在!");
            return;
        }

        var existingOrder = existingOrders[0];
        Console.WriteLine("现有订单信息:");
        Console.WriteLine(existingOrder);

        Console.Write("输入新客户ID: ");
        var customerId = Console.ReadLine();
        Console.Write("输入新客户姓名: ");
        var customerName = Console.ReadLine();
        Console.Write("输入新客户联系方式: ");
        var contact = Console.ReadLine();

        var customer = new Customer(customerId, customerName, contact);
        var newOrder = new Order(orderId, customer);

        Console.WriteLine("重新输入订单明细:");
        while (true)
        {
            Console.Write("输入商品ID(输入空行结束): ");
            var productId = Console.ReadLine();
            if (string.IsNullOrEmpty(productId)) break;

            Console.Write("输入商品名称: ");
            var productName = Console.ReadLine();
            Console.Write("输入商品价格: ");
            decimal price = decimal.Parse(Console.ReadLine());
            Console.Write("输入商品数量: ");
            int quantity = int.Parse(Console.ReadLine());

            var product = new Product(productId, productName, price);
            var detail = new OrderDetail(product, quantity);

            try
            {
                newOrder.AddDetail(detail);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"添加明细失败: {e.Message}");
            }
        }

        service.UpdateOrder(newOrder);
        Console.WriteLine("订单修改成功!");
    }

    static void QueryOrders(OrderService service)
    {
        Console.WriteLine("查询选项:");
        Console.WriteLine("1. 按订单号查询");
        Console.WriteLine("2. 按商品名称查询");
        Console.WriteLine("3. 按客户查询");
        Console.WriteLine("4. 按金额范围查询");
        Console.Write("请选择查询方式: ");

        int choice = int.Parse(Console.ReadLine());
        List<Order> results = new List<Order>();

        switch (choice)
        {
            case 1:
                Console.Write("输入订单号(或部分): ");
                var orderId = Console.ReadLine();
                results = service.QueryByOrderId(orderId);
                break;
            case 2:
                Console.Write("输入商品名称(或部分): ");
                var productName = Console.ReadLine();
                results = service.QueryByProductName(productName);
                break;
            case 3:
                Console.Write("输入客户姓名(或部分): ");
                var customerName = Console.ReadLine();
                results = service.QueryByCustomer(customerName);
                break;
            case 4:
                Console.Write("输入最小金额: ");
                decimal min = decimal.Parse(Console.ReadLine());
                Console.Write("输入最大金额: ");
                decimal max = decimal.Parse(Console.ReadLine());
                results = service.QueryByAmountRange(min, max);
                break;
            default:
                Console.WriteLine("无效选择!");
                return;
        }

        if (results.Count == 0)
        {
            Console.WriteLine("没有找到匹配的订单!");
        }
        else
        {
            Console.WriteLine($"找到 {results.Count} 个订单:");
            foreach (var order in results)
            {
                Console.WriteLine(order);
                Console.WriteLine("---------------------");
            }
        }
    }

    static void DisplayAllOrders(OrderService service)
    {
        var orders = service.GetAllOrders();
        if (orders.Count == 0)
        {
            Console.WriteLine("没有订单!");
            return;
        }

        Console.WriteLine($"共有 {orders.Count} 个订单:");
        foreach (var order in orders)
        {
            Console.WriteLine(order);
            Console.WriteLine("---------------------");
        }
    }

    static void SortOrders(OrderService service)
    {
        Console.WriteLine("排序选项:");
        Console.WriteLine("1. 按订单号排序(默认)");
        Console.WriteLine("2. 按总金额排序");
        Console.WriteLine("3. 按下单时间排序");
        Console.Write("请选择排序方式: ");

        int choice = int.Parse(Console.ReadLine());

        switch (choice)
        {
            case 1:
                service.SortOrders();
                Console.WriteLine("已按订单号排序");
                break;
            case 2:
                service.SortOrders((x, y) => x.TotalAmount.CompareTo(y.TotalAmount));
                Console.WriteLine("已按总金额排序");
                break;
            case 3:
                service.SortOrders((x, y) => x.OrderTime.CompareTo(y.OrderTime));
                Console.WriteLine("已按下单时间排序");
                break;
            default:
                Console.WriteLine("无效选择，使用默认排序");
                service.SortOrders();
                break;
        }
    }

    static void ExportOrders(OrderService service)
    {
        Console.Write("输入导出文件名: ");
        var fileName = Console.ReadLine();

        service.Export(fileName);
        Console.WriteLine("订单导出成功!");
    }
}