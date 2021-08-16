namespace Hw2
{
    public class StringInterpolationFormat:IStringFormat
    {
        public static string GetString(Employee emp)=> $"------------------------------ \n" +
                                                $"Имя {Name} \n" +
                                                $"Возраст {Age} \n" +
                                                $"Рост {Height} \n " +
                                                $"Оценки: \n " +
                                                $"русский язык: {RussianPoints} \n" +
                                                $"История {HistoryPoints} \n" +
                                                $"Математика {MathPoints} \n" +
                                                $"Средняя оценка {AveragePoints}" +
                                                $"------------------------------ \n";

    
    }
}