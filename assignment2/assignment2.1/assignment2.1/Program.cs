using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        Console.Write("请输入一个整数: ");
        if (int.TryParse(Console.ReadLine(), out int number) && number > 1)
        {
            List<int> primeFactors = GetPrimeFactors(number);
            Console.WriteLine($"{number} 的素数因子为: {string.Join(", ", primeFactors)}");
        }
        else
        {
            Console.WriteLine("请输入一个大于1的有效整数。");
        }
    }

    static List<int> GetPrimeFactors(int number)
    {
        List<int> primeFactors = new List<int>();

        // 处理2的因子
        while (number % 2 == 0)
        {
            primeFactors.Add(2);
            number /= 2;
        }

        // 处理奇数因子
        for (int i = 3; i <= Math.Sqrt(number); i += 2)
        {
            while (number % i == 0)
            {
                primeFactors.Add(i);
                number /= i;
            }
        }

        // 如果剩下的数是一个素数且大于2
        if (number > 2)
        {
            primeFactors.Add(number);
        }

        return primeFactors;
    }
}