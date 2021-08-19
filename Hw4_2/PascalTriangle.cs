using System;
using System.ComponentModel;
using System.Diagnostics;

namespace Hw4_2
{
    public class PascalTriangle
    {
        public int Rows { get; }

        private int[][] Triangle;

        public PascalTriangle(int rows)
        {
            Rows = rows;

            Triangle = new int[rows][];

            for (int i = 0; i < rows; i++)
            {
                Triangle[i] = new int[i + 1];
                Triangle[i][0] = 1;
                Triangle[i][i] = 1;
                for (int j = 1; j < i; j++)
                {
                    Triangle[i][j] = Triangle[i - 1][j - 1] + Triangle[i - 1][j];
                }
            }
        }

        public override string ToString()
        {
            string[] lines = new string[Rows];

            for (int i = Rows - 1; i >= 0; i--)
            {

                for (int j = 0; j<Rows - Triangle[i].Length;j++)
                {
                    lines[i] += "  ";
                }
                for (int j = 0; j < Triangle[i].Length; j++)
                {
                    lines[i] += $"{Triangle[i][j]}  ";
                }
            }

            string result = "";
            foreach (var ln in lines)
            {
                result += ln + "\n";
            }

            return result;
        }
    
    }
}