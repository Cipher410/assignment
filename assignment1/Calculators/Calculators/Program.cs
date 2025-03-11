using System;
class Calculator
{
    static void Main()
    {
        // 提示用户输入第一个数字
        Console.Write("请输入第一个数字: ");
        double num1 = Convert.ToDouble(Console.ReadLine());

        // 提示用户输入第二个数字
        Console.Write("请输入第二个数字: ");
        double num2 = Convert.ToDouble(Console.ReadLine());

        // 提示用户输入运算符
        Console.Write("请输入运算符 (+, -, *, /): ");
        string operatorChoice = Console.ReadLine();

        double result = 0;
        bool validOperator = true;

        // 根据运算符执行相应的计算
        switch (operatorChoice)
        {
            case "+":
                result = num1 + num2;
                break;

            case "-":
                result = num1 - num2;
                break;

            case "*":
                result = num1 * num2;
                break;

            case "/":
                if (num2 == 0)
                {
                    Console.WriteLine("除数不能为零！");
                    validOperator = false;
                }
                else
                {
                    result = num1 / num2;
                }
                break;

            default:
                Console.WriteLine("无效的运算符！");
                validOperator = false;
                break;
        }

        // 输出计算结果
        if (validOperator)
        {
            Console.WriteLine($"结果: {num1} {operatorChoice} {num2} = {result}");
        }
    }
}