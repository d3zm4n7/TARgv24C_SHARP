using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24C_SHARP._4._FailitootlusJaAndmestruktuur
{
    internal class MainClass_4osa
    {
        public static void Main(string[] args)
        {
            string failinimi = "kuud.txt";

            // 1. Записываем 3 месяца в файл
            List<string> kuud = new List<string> { "Mai", "Juuni", "Juuli" };
            File.WriteAllLines(failinimi, kuud);
            Console.WriteLine("Файл записан: " + failinimi);

            // 2. Чтение месяцев из файла в List<string>
            kuud = new List<string>(File.ReadAllLines(failinimi));

            // 3. Удаляем "Juuni" и изменяем первый элемент
            kuud.Remove("Juuni");
            if (kuud.Count > 0)
                kuud[0] = "Aprill"; // изменяем первый месяц на "Aprill"

            // 4. Вывод всех месяцев
            Console.WriteLine("Текущий список месяцев:");
            foreach (string kuu in kuud)
            {
                Console.WriteLine(kuu);
            }

            // 5. Поиск месяца по имени
            Console.Write("\nВведите месяц для поиска: ");
            string otsitav = Console.ReadLine();
            if (kuud.Contains(otsitav))
                Console.WriteLine($"Месяц \"{otsitav}\" найден.");
            else
                Console.WriteLine($"Месяц \"{otsitav}\" не найден.");

            // 6. Сохраняем изменения обратно в файл
            File.WriteAllLines(failinimi, kuud);
            Console.WriteLine("\nИзменения сохранены в файл.");
        }
    }
}
