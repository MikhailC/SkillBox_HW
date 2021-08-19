using System;
using System.Data;

namespace Hw4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            var pl = new ProfitAndLost[12];
            Random rnd = new Random();
       
            for(int i=1;i<=12;i++)
            {
                pl[i-1] = new ProfitAndLost() {Income = rnd.Next(1000), Outcome = rnd.Next(1000), MonthNumber = i};
                Console.WriteLine(pl[i-1].ToString());
            }
            
            Array.Sort(pl, (x,y)=>x.Profit.CompareTo(y.Profit));
            
            Console.WriteLine("Worse months");
            var worseprofit = pl[0];
            Console.WriteLine(worseprofit);
            int totalmontsout = 1;
            for (int i = 1; i < 12; i++)
            {
               Console.WriteLine(pl[i]);
               if (worseprofit.Profit != pl[i].Profit)
               {
                   worseprofit = pl[i];
                   totalmontsout++;
               }
               if(totalmontsout==3) break; 
               
            }
            
            Console.WriteLine("Best months");
            Array.Reverse(pl);
            for(int i = 0;i<3;i++) Console.WriteLine($"{pl[i]}");
        }
    }
}