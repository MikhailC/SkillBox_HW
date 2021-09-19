

using System.IO;
using Newtonsoft.Json;

namespace Hw8
{
    public class SaveCorporationCommand:IMenuCommand
    {
        private readonly Corporation _corporation;
        public string Title => "Сохранить в файл corp.json";

        public void Execute()
        {
            using TextWriter writer = new StreamWriter("corp.json", false);
            writer.Write(JsonConvert.SerializeObject(_corporation.Departments,Formatting.Indented,
                new JsonSerializerSettings()
                {
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    PreserveReferencesHandling = PreserveReferencesHandling.Objects
                }));
            
            
        }

        public SaveCorporationCommand(Corporation corporation)
        {
            _corporation = corporation;

        }
    }
}