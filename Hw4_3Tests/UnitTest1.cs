using System;
using Hw4_3;
using Xunit;

namespace Hw4_3Tests
{
    public class UnitTest1
    {
        [Fact]
        public void Test_MatrixMultiple_MatrixARowCountIfNotEqulMatrixBRowCountThrowsException()
        {
         
            
            int[,] a=new int[2,3];
            int[,] b=new int[4,2];

            Assert.Throws<ArgumentException>(()=>Utils.MatrixMultiple(a, b));
        }

        [Fact]
        public void Test_MatrixMultiplication()
        {
            int[,] a = new int[2, 3] {{1, 2, 3}, 
                                      {4, 5, 6}};

            int[,] b = new int[3, 4]
            {
                {7, 8, 9, 10},
                {11, 12, 13, 14},
                {15, 16, 17, 18}
            };

            int[,] c = new int[2, 4]
            {
                {74, 80, 86, 92},
                {173, 188, 203, 218}
            };
            
           

            Assert.Equal(Utils.MatrixMultiple(a,b),c);

        }
        
        [Fact]
        public void Test_EveryCellInMatrixShouldBeMultipled()
        {
            int[,] src = new int[3, 3] {{1, 1, 1}, {1, 1, 1}, {1, 1, 1}};
            int[,] tgt = new int[3, 3] {{2, 2, 2}, {2, 2, 2}, {2, 2, 2}};
            
            Utils.MultiplyMatrixByNumber(src,2);


            Assert.Equal(src, tgt);
        }

        [Fact]
        public void Test_AddMatrixShouldRiseExceptionIfMatrixDoesntEqual()
        {
            int[,] src = new int[3, 3] {{1, 1, 1}, {1, 1, 1}, {1, 1, 1}};
            int[,] tgt = new int[2, 3] {{2, 2, 2}, {2, 2, 2}};

            Assert.Throws<ArgumentException>(()=>Utils.MatrixAdd(src, tgt));
        }

        [Fact]
        public void Test_AddMatrixShouldReturnMatrixWithCellsWithSumsFirstAndSecondMatrix()
        {
            int[,] First = new int[3, 3] {{1, 1, 1}, {1, 1, 1}, {1, 1, 1}};
            int[,] Second = new int[3, 3] {{2, 2, 2}, {2, 2, 2}, {2, 2, 2}};
            int[,] AddedMatrix = new int[3, 3] {{3, 3, 3}, {3, 3, 3}, {3, 3, 3}};

            var result = Utils.MatrixAdd(First, Second);
            
            Assert.Equal(result, AddedMatrix);
            
        }
        
        [Fact]
        public void Test_SubstractedMatrixShouldReturnMatrixWithCellsWithDeltaBetweenFirstAndSecondMatrix()
        {
            int[,] Second = new int[3, 3] {{1, 1, 1}, {1, 1, 1}, {1, 1, 1}};
            int[,] ResultMatrix = new int[3, 3] {{2, 2, 2}, {2, 2, 2}, {2, 2, 2}};
            int[,] First = new int[3, 3] {{3, 3, 3}, {3, 3, 3}, {3, 3, 3}};

            var result = Utils.MatrixSub(First, Second);
            
            Assert.Equal(result, ResultMatrix);
            
        }
    }
}