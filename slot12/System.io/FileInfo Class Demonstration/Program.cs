using System;
using System.IO;

namespace FileInfo_Class_Demonstration
{
    class Program
    {
        static void Main(string[] args)
        {
            string Filename = @"MyFile.txt";
            Console.WriteLine("******Demo fileInfo Class*****\n");
            File.WriteAllText(Filename, "Hellp World.");
            Console.WriteLine("Read file:");
            string content = File.ReadAllText(Filename);
            Console.WriteLine(content);
            Console.WriteLine("File information: ");
            FileInfo testFile = new FileInfo(Filename);
            Console.WriteLine($"Name: {testFile.Name}");
            Console.WriteLine($"Creation time: {testFile.CreationTime}");
            Console.WriteLine($"Last Write time: {testFile.LastWriteTime}");
            Console.WriteLine($"Directory name: {testFile.DirectoryName}");
            Console.ReadLine();
        }
    }
}
