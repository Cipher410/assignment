using System;

class Program
{
    static void Main(string[] args)
    {
        int[,] matrix = {
            {1, 2, 3, 4},
            {5, 1, 2, 3},
            {9, 5, 1, 2}
        };

        bool isToeplitz = IsToeplitzMatrix(matrix);
        Console.WriteLine("该矩阵是否是托普利茨矩阵: " + isToeplitz);
    }

    static bool IsToeplitzMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0); // 获取矩阵的行数
        int cols = matrix.GetLength(1); // 获取矩阵的列数

        // 检查每条对角线
        for (int i = 1; i < rows; i++)
        {
            for (int j = 1; j < cols; j++)
            {
                // 如果当前元素不等于左上角的元素，则不是托普利茨矩阵
                if (matrix[i, j] != matrix[i - 1, j - 1])
                {
                    return false;
                }
            }
        }

        // 如果所有对角线都满足条件，则是托普利茨矩阵
        return true;
    }
}