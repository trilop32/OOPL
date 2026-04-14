using System;
using System.IO;
using System.Text.RegularExpressions;
class Program {
    static void Main() {
        string inputFile = "input.txt";
        string outputFile = "output.txt";
        if (!File.Exists(inputFile)) {
            Console.WriteLine("Файл input.txt не найден!");
            return;
        }
        string text = File.ReadAllText(inputFile);
        Console.WriteLine("Текст из файла:\n");
        Console.WriteLine(text);
        Console.Write("\nВведите слово: ");
        string word = Console.ReadLine().ToLower();
        string[] sentences = Regex.Split(text, @"(?<=[.!?])");
        using (StreamWriter writer = new StreamWriter(outputFile)) {
            Console.WriteLine("\nПодходящие предложения:\n");
            foreach (string sentence in sentences) {
                string trimmed = sentence.Trim();
                if (trimmed.ToLower().EndsWith(word + ".") ||
                    trimmed.ToLower().EndsWith(word + "!") ||
                    trimmed.ToLower().EndsWith(word + "?")) {
                    Console.WriteLine(trimmed);
                    writer.WriteLine(trimmed);
                }
            }
        }
        Console.WriteLine($"\nРезультат записан в файл {outputFile}");
        Console.ReadKey();
    }
}