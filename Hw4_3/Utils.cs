using System;

namespace Hw4_3
{
    public static class Utils
    {
        public static  void MultiplyMatrixByNumber(int[,] matrix, int number)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1); j++)
                {
                    matrix[i, j] *= number;
                }
            }
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