using System;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using Hw3;
using Newtonsoft.Json;

namespace Hw7
{
    public class Note
    {
        public DateTime CreationDate { get; set; } = DateTime.Today;
        
        public string Subject { get; set; } = "<NA>";
       
        public string Description { get; set; } = "<NA>";
        public DateTime RemindMe { get; set; } = DateTime.MaxValue;
        public string Phone { get; set; } = "<NA>";
        
       

        /// <summary>
        /// Возвращаем по имени свойства значение
        /// Значение возвращается всегда object
        /// </summary>
        /// <param name="propertyName">Имя свойства объекта</param>
        public object? this[string propertyName]
        {
            get
            {
                PropertyInfo? info = this.GetType().GetProperty(propertyName);
                if (info is not null) return info.GetValue(this, null);
                else return null;
            } set
            {
                PropertyInfo? info = this.GetType().GetProperty(propertyName);
                if(info is not null) info.SetValue(this, value, null);
            }
        }

        public override string ToString()
        {
            return $" +++ Subject '{Subject}' Description '{Description}' Creation date '{CreationDate}'" +
                   $"Phone '{Phone}' Reminder set to '{RemindMe.ToString()}' +++";
            
        }

      
        /// <summary>
        /// Сохраняет значение записи в файл
        /// </summary>
        /// <param name="stream">Инициализированный поток для записи</param>
        public void Save(TextWriter stream)
        {
            var contentsToWriteToFile = JsonConvert.SerializeObject(this, Formatting.None);
            stream.WriteLine(contentsToWriteToFile);
        }
        

        void GetDefaultResultFromConsole(string FieldName, string Presentation)
        {
            string res = "";
            Console.WriteLine($"Введите {Presentation.ToLower()}. Если вы хотите отсавить значение {this[FieldName]} нажмите Enter");
            if (!(res = Console.ReadLine()).Equals("")) this[FieldName] = res;
        }
        
        public void Edit()
        {
            GetDefaultResultFromConsole("Subject", "тема");
            GetDefaultResultFromConsole("Description", "заметка");
            GetDefaultResultFromConsole("Phone", "телефон"); 
            this.RemindMe = Utils.InputValue<DateTime>("Требуется ввести дату. Дата должны быть больше.", x => x > DateTime.Now, "Введите дату напоминания");
        }
    }
}