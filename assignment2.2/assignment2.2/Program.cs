using System;
using System.Linq;

class Program
{
    static void Main(string[] args)
    {
        // 示例数组
        int[] numbers = { 12, 45, 67, 23, 9, 54, 32 };

        // 计算最大值、最小值、平均值和总和
        int max = numbers.Max();
        int min = numbers.Min();
        double average = numbers.Average();
        int sum = numbers.Sum();

        // 输出结果
        Console.WriteLine($"数组: [{string.Join(", ", numbers)}]");
        Console.WriteLine($"最大值: {max}");
        Console.WriteLine($"最小值: {min}");
        Console.WriteLine($"平均值: {average:F2}");
        Console.WriteLine($"总和: {sum}");
    }
}