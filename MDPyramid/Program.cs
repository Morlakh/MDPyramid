using MDPyramid.Models;
using System;
using System.IO;

namespace MDPyramid
{
    class Program
    {
        public const string DataFolder = "Data";
        public const string Input1 = "Input1.txt";
        public const string Input2 = "Input2.txt";

        static void Main(string[] args)
        {
            var lines = GetPyramidLines(Input1);

            Console.WriteLine("Input: ");
            foreach (var line in lines)
            {
                Console.WriteLine(line);
            }

            var tree = new Pyramid(lines);

            tree.Calculate();

            Console.WriteLine(string.Empty);
            Console.WriteLine("Max sum: " + tree.Max);
            Console.WriteLine($"Path: {string.Join(", ", tree.MaxPath)}");

            Console.ReadKey();
        }

        public static string[] GetPyramidLines(string inputFile)
        {
            // Keep the read simple for now
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), DataFolder, inputFile);
            
            return File.ReadAllLines(filePath);
        }
    }
}
