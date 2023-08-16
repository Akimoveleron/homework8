using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework_8
{
    internal class FileManager
    {
        public static async Task CreateRandomTextFilesAsync(int countFiles, string path)
        {
            const string chars = "AB CD EF GH IJ K LM NO PQ RS TU VW XYZ 0123 45 67 89";
            Random random = new Random();
            List<Task> tasks = new List<Task>();
            Directory.SetCurrentDirectory(path);

            for (int i = 0; i < countFiles; i++)
            {
                int minTextLength = 100000;
                int maxTextLength = 10000000;
                int textLength = random.Next(minTextLength, maxTextLength);

                string fileContent = new string(Enumerable.Repeat(chars, textLength)
                .Select(s => s[random.Next(s.Length)]).ToArray());
                
                string fileName = "File" + i + ".txt";

                tasks.Add(File.WriteAllTextAsync(fileName, fileContent));

                
            }
           await Task.WhenAll(tasks);

            Console.WriteLine($"Create {countFiles} files ");

        }

        public static async Task CountSpaceInFilesAsync(string path)
        {
            if (Directory.Exists(path))
            {
            List<Task> tasks = new List<Task>();
            Directory.SetCurrentDirectory(path);

                foreach (var file in Directory.GetFiles(path))
                {
                    tasks.Add(Task.Run(()=>CountSpace(file)));
                }
                await Task.WhenAll( tasks);
            }
            else
            {
                Console.WriteLine("Не верная директория");
            }


        }

        private static  void CountSpace(string file)
        {
            var fileContent = File.ReadAllText(file);
            var spaceCount = fileContent.Count(item => item ==' ');
            //Console.WriteLine($"File{file}contains {spaceCount} spaces");

        }
        public static void CountSpaceInFiles(string path)
        {
            if (Directory.Exists(path))
            {
                List<Task> tasks = new List<Task>();
                Directory.SetCurrentDirectory(path);

                foreach (var file in Directory.GetFiles(path))
                {
                    CountSpace(file);
                }
               
            }
            else
            {
                Console.WriteLine("Не верная директория");
            }


        }



    }
}
