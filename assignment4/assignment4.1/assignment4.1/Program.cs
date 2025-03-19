using System;

// 定义泛型链表节点类
class Node<T>
{
    public T Data { get; set; }
    public Node<T> Next { get; set; }

    public Node(T data)
    {
        Data = data;
        Next = null;
    }
}

// 定义泛型链表类
class GenericLinkedList<T>
{
    private Node<T> Head { get; set; }

    // 添加元素到链表
    public void Add(T data)
    {
        Node<T> newNode = new Node<T>(data);
        if (Head == null)
        {
            Head = newNode;
        }
        else
        {
            Node<T> current = Head;
            while (current.Next != null)
            {
                current = current.Next;
            }
            current.Next = newNode;
        }
    }

    // 实现 ForEach 方法
    public void ForEach(Action<T> action)
    {
        Node<T> current = Head;
        while (current != null)
        {
            action(current.Data); // 对每个元素执行传入的 action
            current = current.Next;
        }
    }
}

class Program
{
    static void Main(string[] args)
    {
        // 创建一个整数链表
        GenericLinkedList<int> list = new GenericLinkedList<int>();
        list.Add(10);
        list.Add(20);
        list.Add(30);
        list.Add(40);
        list.Add(50);

        // 打印链表元素
        Console.WriteLine("链表元素:");
        list.ForEach(x => Console.WriteLine(x));

        // 求最大值
        int max = int.MinValue;
        list.ForEach(x => { if (x > max) max = x; });
        Console.WriteLine($"最大值: {max}");

        // 求最小值
        int min = int.MaxValue;
        list.ForEach(x => { if (x < min) min = x; });
        Console.WriteLine($"最小值: {min}");

        // 求和
        int sum = 0;
        list.ForEach(x => sum += x);
        Console.WriteLine($"和: {sum}");
    }
}