namespace Hw7
{
    public enum Command
    {
        /// <summary>
        /// Показывает список записей в дневнике
        /// </summary>
        ListNotes ,

        /// <summary>
        /// Добавляет новую запись в дневник
        /// </summary>
        Insert ,
        /// <summary>
        /// Редактирует записи в дневнике
        /// </summary>
        Edit,

        /// <summary>
        /// Удаляет запись в дневник по индексу
        /// </summary>
        DeleteByIndex ,

        /// <summary>
        /// Удаляет записи в дневнике по шаблону 
        /// </summary>
        DeleteByField ,

  

        /// <summary>
        /// Сохраняет записи в файл
        /// </summary>
        Save,
        
        /// <summary>
        /// Сохраняет записи в файл с указанием имени файла
        /// </summary>
        SaveAs,

        /// <summary>
        /// Загружает записи из файла
        /// </summary>
        Load,

        /// <summary>
        /// Загружает записи из файла по диапазону дат
        /// </summary>
        LoadByDate,
        
        Exit

    }

}