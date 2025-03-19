using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        int limit = 100;
        List<int> primes = SieveOfEratosthenes(limit);

        Console.WriteLine($"2到{limit}以内的素数为:");
        Console.WriteLine(string.Join(", ", primes));
    }

    static List<int> SieveOfEratosthenes(int limit)
    {
        // 创建一个布尔数组，初始值为true，表示所有数都是素数
        bool[] isPrime = new bool[limit + 1];
        for (int i = 2; i <= limit; i++)
        {
            isPrime[i] = true;
        }

        // 埃氏筛法核心逻辑
        for (int p = 2; p * p <= limit; p++)
        {
            if (isPrime[p]) // 如果p是素数
            {
                // 将p的所有倍数标记为非素数
                for (int i = p * p; i <= limit; i += p)
                {
                    isPrime[i] = false;
                }
            }
        }

        // 收集所有素数
        List<int> primes = new List<int>();
        for (int i = 2; i <= limit; i++)
        {
            if (isPrime[i])
            {
                primes.Add(i);
            }
        }

        return primes;
    }
}