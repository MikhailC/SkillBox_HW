using System;

namespace Hw4_3
{
    public static class Utils
    {
        public static  int [,] MultiplyMatrixByNumber(int[,] matrix, int number)
        {
            int[,] result = new int[matrix.GetLength(0), matrix.GetLength(1)];
            
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    result[i, j] = matrix[i,j] * number;
                }
            }
           

            return result;
        }

        public static int[,] MatrixMultiple(int[,] a, int[,] b)
        {
        
            if (a.GetLength(1) != b.GetLength(0))
            {
                throw new ArgumentException(
                    $"Две матрицы можно перемножить если количество столбцов первой матрицы равно количеству строк второй матрицы.");
            }
            
            int m = a.GetLength(0);
            int n = a.GetLength(1);
            int k = b.GetLength(1);
            
            int[,] c = new int[m, k];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < k; j++)
                {
                    c[i, j] = 0;
                    for (int x = 0; x < n; x++)
                    {
                        c[i,j] += a[i, x] * b[x, j];
                    }
                 
                }
            }

            return c;
        }
        
        public static  int[,] MatrixAdd(int[,] a, int[,] b) => MatrixAddSub(a, b, 1);

        public static int[,] MatrixSub(int[,] a, int[,] b) => MatrixAddSub(a, b, -1);
        
        
        private static int[,] MatrixAddSub(int[,] a, int[,] b, int negative)
        {
            if (a.GetLength(0) != b.GetLength(0) || a.GetLength(1) != b.GetLength(1))
            {
                throw new ArgumentException("Матрицы должны быть равны");
            }

            int[,] c = new int[a.GetLength(0), a.GetLength(1)];
            for (int i = 0; i < a.GetLength(0); i++)
            {
                for (int j = 0; j < a.GetLength(1); j++)
                {
                    c[i, j] = a[i, j] + b[i, j]*negative;
                }
            }

            return c;
        }
    }
}