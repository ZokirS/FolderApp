using System;
using System.IO;

namespace FolderApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Show path: ");
           
            var path = Console.ReadLine();
            Console.WriteLine("Please, write file extension to filter: ");
            var fileExt = Console.ReadLine();
            FileSystemVisitor fileSystemVisitor = new FileSystemVisitor(path, fileExt);
            fileSystemVisitor.Notify +=DisplayMessage;
            foreach (var item in fileSystemVisitor)
            {
                Console.WriteLine(item);
            }
            Console.ReadKey();
        }
        /*public static void ListFileDirectory(string path)
        {
            string[] folders = Directory.GetDirectories(path);
            for (int i=0; i<folders.Length;i++)
            {
                Console.WriteLine(folders[i]);
                string[] files = Directory.GetFiles(folders[i]);
                for (int j = 0; j < files.Length; j++)
                {
                    Console.WriteLine("     "+files[j]);
                }
            }
        }*/

        public static void DisplayMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
