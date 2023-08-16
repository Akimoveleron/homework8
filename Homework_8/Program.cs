using Homework_8;
using System.Diagnostics;

internal class Program
{
    private static async Task Main(string[] args)
    {
        await FileManager.CreateRandomTextFilesAsync(30, Directory.GetCurrentDirectory());
        var stopWatch = new Stopwatch();
        for (int i = 0; i < 10; i++)
        {

            stopWatch.Start();
            FileManager.CountSpaceInFiles(Directory.GetCurrentDirectory());
            stopWatch.Stop();
            Console.WriteLine($"Insync {stopWatch.ElapsedMilliseconds}");
            stopWatch.Restart();          
        }
        Console.WriteLine();
        for (int i = 0; i < 10; i++)
        {
            stopWatch.Start();
            await FileManager.CountSpaceInFilesAsync(Directory.GetCurrentDirectory());
            stopWatch.Stop();
            Console.WriteLine($"Async {stopWatch.ElapsedMilliseconds}");
            stopWatch.Restart();
        }

    }
}