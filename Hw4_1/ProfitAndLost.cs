namespace Hw4_1
{
    public class ProfitAndLost
    {
        public float Income { get; set; }
        public float Outcome { get; set; }
        
        public int MonthNumber { get; set; }
        public float Profit => this.Income - this.Outcome;

        public override string ToString()
        {
            return $"{MonthNumber} - Income {Income} Outcome {Outcome} Profit {Profit}";
        }
    }
}