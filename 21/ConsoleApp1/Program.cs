using System;
using System.Linq;
struct Student {
    public string fio;
    public double stipendiya;
    public string mesto;
}
class Program {
    static string FIO() {
        while (true) {
            Console.Write("ФИО: ");
            string input = Console.ReadLine();
            string[] parts = input.Split(' ', (char)StringSplitOptions.RemoveEmptyEntries);
            bool valid = (parts.Length == 2 || parts.Length == 3) && parts.All(word => word.All(char.IsLetter));
            if (valid)
                return input;
            Console.WriteLine("Ошибка. Введите ФИО (2 или 3 слова, только буквы)");
        }
    }
    static double IStipendiya() {
        while (true) {
            Console.Write("Размер стипендии: ");
            if (double.TryParse(Console.ReadLine(), out double stip) && stip >= 0)
                return stip;
            Console.WriteLine("Ошибка. Введите корректное число.");
        }
    }
    static string Mesto() {
        while (true) {
            Console.Write("Место жительства (1 - общежитие, 2 - дом): ");
            if (int.TryParse(Console.ReadLine(), out int choice)) {
                if (choice == 1)
                    return "общежитие";
                if (choice == 2)
                    return "дом";
            }
            Console.WriteLine("Ошибка. Введите 1 или 2.");
        }
    }
    static void Main() {
        const int n = 3;
        Student[] students = new Student[n];
        for (int i = 0; i < n; i++) {
            Console.WriteLine($"Студент #{i + 1}");
            students[i].fio = FIO();
            students[i].stipendiya = IStipendiya();
            students[i].mesto = Mesto();
            Console.WriteLine();
        }
        double minStip;
        while (true) {
            Console.Write("Введите минимальную стипендию: ");
            if (double.TryParse(Console.ReadLine(), out minStip))
                break;
            else
                Console.WriteLine("Ошибка. Введите число.");
        }
        Console.WriteLine("\nСтуденты из общежития со стипендией выше минимальной:");
        for (int i = 0; i < n; i++) {
            if (students[i].mesto == "общежитие" && students[i].stipendiya > minStip) {
                Console.WriteLine(students[i].fio +"  "+ students[i].stipendiya);
            }
        }
        Console.ReadKey();
    }
}