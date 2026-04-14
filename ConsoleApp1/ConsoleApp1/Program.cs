using System;
using System.Collections.Generic;
using System.Linq;

class Program {
    static void AnalyzeNumbers(params int[] numbers) {
        Dictionary<int, List<int>> divisorsMap = new Dictionary<int, List<int>>();
        Console.WriteLine("=== Делители для каждого числа ===");
        foreach (int num in numbers) {
            List<int> divs = GetDivisors(num);
            divisorsMap[num] = divs;
            Console.Write($"Число {num}: ");
            Console.WriteLine(string.Join(", ", divs));
        }
        Console.WriteLine("\n=== Поиск совпадающих делителей (пары чисел) ===");
        bool foundMatches = false;
        int[] keys = divisorsMap.Keys.ToArray();
        for (int i = 0; i < keys.Length; i++) {
            for (int j = i + 1; j < keys.Length; j++) {
                int num1 = keys[i];
                int num2 = keys[j];
                var commonDivisors = divisorsMap[num1].Intersect(divisorsMap[num2]).Where(d => d > 1).ToList();
                if (commonDivisors.Count > 0) {
                    Console.WriteLine($"Числа [{num1}] и [{num2}] имеют общие делители: {string.Join(", ", commonDivisors)}");
                    foundMatches = true;
                }
            }
        }
        if (!foundMatches) {
            Console.WriteLine("Совпадающих делителей (кроме 1) у пар чисел не найдено.");
        }
    }
    static List<int> GetDivisors(int number) {
        List<int> divisors = new List<int>();
        for (int i = 1; i <= number; i++) {
            if (number % i == 0) {
                divisors.Add(i);
            }
        }
        return divisors;
    }
    static void Main() {
        Console.WriteLine("=== Генерация 10 случайных чисел ===");
        int[] randomNumbers = new int[10];
        Random rand = new Random();
        for (int i = 0; i < 10; i++) {
            randomNumbers[i] = rand.Next(10, 50);
            Console.Write(randomNumbers[i] + " ");
        }
        Console.WriteLine("\n");
        AnalyzeNumbers(randomNumbers);
        Console.ReadKey();
    }
}