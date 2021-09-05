// See https://aka.ms/new-console-template for more information

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Mime;
using ConsoleApp1;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


List<string> ff = new List<string>();
ff.RemoveAll()

var s = new Sample() {id = 5, description = "sample 5"};
var s1 = new Sample() {id = 6, description = "sample 6"};

TextWriter textWriter;

var contentsToWriteToFile = JsonConvert.SerializeObject(s, Formatting.None);
textWriter = new StreamWriter("sample.txt", true);
textWriter.WriteLine(contentsToWriteToFile);

 contentsToWriteToFile = JsonConvert.SerializeObject(s1, Formatting.None);
//textWriter = new StreamWriter("sample.txt", true);
textWriter.WriteLine(contentsToWriteToFile);

textWriter.Close();
StreamReader sr = new StreamReader("sample.txt");
string? res = "";

foreach (var v in ReadObject(sr).Where(i=>i.id==5))
{

        Console.WriteLine(v);

}
// while (!string.IsNullOrWhiteSpace(res = sr.ReadLine()))
// {
//     Sample sample = JsonConvert.DeserializeObject<Sample>(res);
//     Console.WriteLine(sample);
// }

Console.WriteLine("Kuku");
Console.ReadKey();

IEnumerable<Sample> ReadObject(TextReader streamReader)
{
    while (!sr.EndOfStream)
    {
        yield return JsonConvert.DeserializeObject<Sample>(streamReader.ReadLine());
    }
}