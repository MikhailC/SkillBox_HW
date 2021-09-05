using System;
using System.Globalization;
using System.IO;
using System.IO.Compression;
using System.Net.Http.Headers;
using System.Text;
using static System.ConsoleKey;

namespace Hw6
{
    class Program
    {
        static int Main(string[] args)
        {
            Console.WriteLine("Enter file name with path which contains limit to the calculation");
            string fileName = Console.ReadLine()??"";
            int inNum = 0;

            try
            {
                using( var fs = new StreamReader(fileName))
                {
                   string stringToParse = fs.ReadLine();
                   inNum = int.Parse(stringToParse??"");
                }
                
                if (inNum > 1_000_000_000) throw new OverflowException("You should set number less than 1 billion");

            }
            catch (FileNotFoundException e)
            {
                Console.WriteLine($"ERROR: File {fileName} not found.");
                return 1;
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"ERROR:Number in file has incorrect format");
                return 2;
            }
            catch (OverflowException e)
            {
                Console.WriteLine($"ERROR: The number bigger than needed. {e.Message}");
                return 3;
            }

            ConsoleKeyInfo userChoose ;
            do
            {
                Console.WriteLine(
                    "Do you want to know how many groups do you have (press 1) or process groups to file (press 2): ");
                userChoose = Console.ReadKey();

            } while (userChoose.Key != Escape && userChoose.KeyChar != '1' && userChoose.KeyChar != '2');

            if (userChoose.Key == Escape) return 4;
            if (userChoose.KeyChar == '1')
            {
                Console.WriteLine($"There are {(int) Math.Log2(inNum)} groups will be");
                return (0);
            }

            #region Process a file with groups
            
            Console.WriteLine("Go to processing");
            DateTime CurTime = DateTime.Now;
            Console.WriteLine($"Start processing:{CurTime}");
            using (var fs = new StreamWriter(new FileStream("out.txt",FileMode.Create), Encoding.ASCII))
            {
                int groupNum = 1;

                for (int i = 1; i <= inNum; i++)
                {
                    if (Math.Log2(i) - (int) Math.Log2(i) == 0)
                    {
                        fs.Write($"\nGroup {groupNum++}:");
                    }
                    fs.Write($" {i}");
                    //Console.WriteLine(i%(inNum/100));
                    if(i%(inNum/10)==0) Console.WriteLine($"Progress:{i/(inNum/100)}% at {DateTime.Now}");
                }
               
            }
            
            Console.WriteLine($"End processing {DateTime.Now}");
            Console.WriteLine($"Total time { DateTime.Now-CurTime}");

            FileInfo fl = new FileInfo("out.txt");
            Console.WriteLine($"File length is {fl.Length}");
            #endregion Process a file with groups
            do
            {
                Console.WriteLine(
                    "Do you like compress? (Y/N)");
                userChoose = Console.ReadKey();

            } while (userChoose.KeyChar != 'Y' && userChoose.KeyChar != 'y'&& userChoose.KeyChar != 'N' && userChoose.KeyChar != 'n');

            Console.WriteLine("File is done. I've placed the file at the current dir. The file name is out.txt");
            if (userChoose.KeyChar == 'N' || userChoose.KeyChar == 'n')
            {
                return (0);
            }
            Console.WriteLine("Wait, please. I'm compressing file.");

            using (var fileStream = fl.OpenRead())
            {
                using (var compressedFileStream = File.Create(fl.FullName + ".gz"))
                {
                    using (var compressedStream = new GZipStream(compressedFileStream, CompressionLevel.Optimal))
                    {
                        fileStream.CopyTo(compressedStream);
                    }
                }
            }

            FileInfo compressedInfo = new FileInfo(fl.FullName + ".gz");
            Console.WriteLine($"Compressed file out.txt.gz size is {compressedInfo.Length}");
            Console.WriteLine($"Regular file out.txt size is {fl.Length}");

            return 0;
        }
    }
}