namespace Hw2
{
    public class Employee
    {
        public string Name { get; set; }
        
        //Возраст и рост будем брать дробный
        public float Age { get; set; }
        public float Height { get; set; }
        //Возьмем целочисленный тип, как самый маленький для оценок
        public byte RussianPoints { get; set; }
        public byte HistoryPoints { get; set; }
        public byte MathPoints { get; set; }

        
        public float AveragePoints =>  ((float) RussianPoints + (float) HistoryPoints + (float) MathPoints) / 3F;
        
        public override string ToString() => $"------------------------------ \n" +
                                             $"Имя {Name} \n" +
                                             $"Возраст {Age} \n" +
                                             $"Рост {Height} \n " +
                                             $"Оценки: \n " +
                                             $"русский язык: {RussianPoints} \n" +
                                             $"История {HistoryPoints} \n" +
                                             $"Математика {MathPoints} \n" +
                                             $"Средняя оценка {AveragePoints, -7:F3} \n" +
                                             $"------------------------------ \n";
                                           
    }


}