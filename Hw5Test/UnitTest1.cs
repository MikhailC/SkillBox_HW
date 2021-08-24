using System;
using System.Runtime.InteropServices;
using Xunit;
using Hw5 ;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using Program = Hw5.Program;

namespace Hw5Test
{
    public class UnitTest1
    {
        [Theory]
        [InlineData(2,3,9)]
        [InlineData(3,2,29)]
        [InlineData(3,3,61)]
        [InlineData(3,4,125)]
        public void AccermanTest(double m, double n, double res)
        {
            Assert.Equal(Hw5.Program.Accerman(m,n),res);
        }
        
        [Theory]
        [InlineData(new int[]{2,4,6,8,10,12},Hw5.ProgressionType.Arifmetic)]
        [InlineData(new int[]{2,4,8,16,32,64},Hw5.ProgressionType.Geometric)]
        [InlineData(new int[]{2,4,8,16,32,164},Hw5.ProgressionType.None)]
        public void ProgressionTest(int[] p, ProgressionType t)
        {
            Assert.Equal(Hw5.Program.DetectProgression(p), t);
        }

        [Fact]
        void Test_ShouldCheckStripTextFunc()
        {
            Assert.Equal(Hw5.Program.StripLine("Скккажжжииииккккка    дяядя ввввведддььь не ДДаром"),"Скажика дядя ведь не Даром");
        }

        [Theory]
        [InlineData("","")]
        [InlineData("rer","rer")]
        [InlineData("ghghghgh rer ter pert fortt","rer")]
        void Test_ReturnShortStringFromText(string inStr, string outStr)
        {
            Assert.Equal(Program.GetMinimalString(inStr), outStr);
        }
        
        [Theory]
        
        [InlineData("длина1 длина23 длина234 234длина длина32 32длина", new string[]{ "234длина","длина234"})]
       [InlineData("", new string[0])]
        void Test_MethodShouldReturnMaxWordsList(string inStr,  string[] outStr)
        {
            Assert.Equal(Program.GetAllMaxStrings(inStr), outStr);
        }
    }
}