using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Hw3;
using Newtonsoft.Json;

namespace Hw7
{
      class Diary
    {
        private static readonly List<Note> MyDiary=new List<Note>();

        public static readonly Dictionary<Command, Action> Actions = new Dictionary<Command, Action>()
        {
            {Command.ListNotes, PrintDiaryNotes},//+
            {Command.Insert, InsertDiaryNote},//+
            {Command.Edit, EditDiaryNote},//+
            {Command.DeleteByField, DeleteByField},
            {Command.DeleteByIndex, DeleteByIndex},//+
            {Command.Save, DiarySaveToDefinedFile},
            {Command.SaveAs, DiarySaveAs},
            {Command.Load, DiaryLoadFromFile},
            {Command.LoadByDate, DiaryLoadByPeriod},
            {Command.SortByField, DiarySortByField}
        };

        private static void DiarySortByField()
        {
            Console.WriteLine("Укажите название поля, по которому будем сортировать (введите английский идентификатор с учетом регистра):\n" +
                              "Subject - Заголовок\n" +
                              "Description - Описание\n" +
                              "CreationDate - Дата создания \n" +
                              "RemindMe - текстовой представление даты напоминания (см. сначала в список)" +
                              "Phone - телефон");
            string fieldName = Console.ReadLine();
            MyDiary.Sort((x,y)=>(((IComparable)x[fieldName]).CompareTo(y[fieldName])));
        }

        public static string FileName = "Diary.txt";

        private static void EditDiaryNote()
        {
            int index = Utils.InputValue<int>($"Номер записи должен быть не больше чем {MyDiary.Count}",
                x => x <= MyDiary.Count&&x>=0, "Введите номер записи. Для отмены напишите 0");
            
            if(index ==0) return;

            MyDiary[index-1].Edit();
            


        }

        private static void DeleteByField()
        {
            Console.WriteLine("Укажите название поля, по которому будем удалять (введите английский идентификатор с учетом регистра):\n" +
                              "Subject - Заголовок\n" +
                              "Description - Описание\n" +
                              "CreationDate - Дата создания \n" +
                              "RemindMe - текстовой представление даты напоминания (см. сначала в список)" +
                              "Phone - телефон");
            string fieldName = Console.ReadLine();
            Console.WriteLine("Подстрока (Enter- отмена)");
            string subString = Console.ReadLine();

            try
            {
                MyDiary.RemoveAll(x => x[fieldName].ToString()!.IndexOf(subString, StringComparison.Ordinal) >= 0);

            }
            catch (Exception e)
            {
                Console.WriteLine("Неверно задали поле. Попробуйте снова...");
                Console.Error.WriteLine(e.Message);
            }

           
        }

        private static void DeleteByIndex()
        {
            int index = Utils.InputValue<int>($"Номер записи для удаления должен быть не больше чем {MyDiary.Count}",
                x => x <= MyDiary.Count&&x>=0, "Введите номер записи. Для отмены напишите 0");
            MyDiary.RemoveAt(index-1);
        }

        private static void DiarySaveToDefinedFile()
        {

            string tempFileName = Path.GetTempFileName();
            
            using (StreamWriter fs = new StreamWriter(File.Create(tempFileName)))
            {
                try
                {
                    MyDiary.ForEach(x => x.Save(stream: fs));
                }catch (Exception e)
                {
                    Console.WriteLine($"Что то пошло не так.... Текст ошибки {e.Message}");
                }
            };

            try
            {
                if (File.Exists(FileName))
                {
                    File.Replace(tempFileName, FileName, FileName + ".bak");
                }
                else
                {
                    File.Move(tempFileName, FileName);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Что то не так пошло.... {e.Message}");
            }
            



        }

        private static void DiarySaveAs()
        {
            Console.WriteLine("Новое имя файла?");
            string newFileName = Console.ReadLine();
            if (File.Exists(newFileName))
            {
                Console.WriteLine($"Файл {newFileName} будет перезаписан");
                File.Move(newFileName, newFileName+".bak");
            }

            //

            FileName = newFileName;
            DiarySaveToDefinedFile();

        }

        private static void DiaryLoadFromFile()
        {
            Console.WriteLine($"Загрузить дневник из файла {FileName}? (Введите новое имя или нажмите Enter");
            string newFileName = Console.ReadLine()??"";
            if (!newFileName.Equals(String.Empty)) 
                FileName = newFileName;
            
            if (File.Exists(FileName))
            {
                MyDiary.Clear();
                using var fs = new StreamReader(File.Open(FileName, FileMode.Open));
                
                foreach (var note in ReadObject(fs))
                {
                    MyDiary.Add(note);
                }
            }
        }

        private static void DiaryLoadByPeriod()
        {
            Console.WriteLine($"Загрузить дневник из файла {FileName}? (Введите новое имя или нажмите Enter");
            string newFileName = Console.ReadLine()??"";
            DatePeriod period = new DatePeriod();
            period.StartDate = Utils.InputValue<DateTime>("Нужно ввести дату начала периода", null, "Введите дату начала периода");
            period.EndDate = Utils.InputValue<DateTime>("Нужно ввести дату конца периода. Дата должна быть больше чем дата начала", x=>x>=period.StartDate, "Введите дату конца периода");

            if (!newFileName.Equals(String.Empty)) 
                FileName = newFileName;
            
            if (File.Exists(FileName))
            {
                MyDiary.Clear();
                using var fs = new StreamReader(File.Open(FileName, FileMode.Open));
                foreach (var note in Enumerable.Where<Note>(ReadObject(fs), note => note.CreationDate >= period.StartDate &&
                                                                                        note.CreationDate <= period.EndDate))
                {
                    MyDiary.Add(note);
                }
                
            }
        }

        private static void InsertDiaryNote()
        {
            Note n = new Note();
            n.Edit();
            MyDiary.Add(n);
        }

        private static void PrintDiaryNotes()
        {
            Console.WriteLine($"Ежедневник сейчас содержит {MyDiary.Count} записей");
            for (int i = 0; i < MyDiary.Count; i++)
            {
                Console.WriteLine($@"#{i+1} - {MyDiary[i]}");
            }
        }

        private static IEnumerable<Note> ReadObject(StreamReader streamReader)
        {
            while (!streamReader.EndOfStream)
            {
                Note? note=JsonConvert.DeserializeObject<Note>(streamReader.ReadLine() ?? string.Empty);
                if (note is not null) yield return note;
            }
        }
    }
}