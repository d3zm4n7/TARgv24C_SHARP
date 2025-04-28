using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static TARgv24C_SHARP._5._Kollektsioonid.Ylesanned;

namespace TARgv24C_SHARP._5._Kollektsioonid
{
    internal class Ylesanned
    {
        public static double[] Tekstist_arvud(string tekst)
        {
            string[] osad = tekst.Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries);
            double[] arvud = new double[osad.Length];

            for (int i = 0; i < osad.Length; i++)
            {
                while (!double.TryParse(osad[i], out arvud[i]))
                {
                    Console.WriteLine($"Viga! '{osad[i]}' ei ole korrektne arv.");
                    Console.Write($"Sisesta korrektne arv asemele '{osad[i]}': ");
                    osad[i] = Console.ReadLine(); // даём пользователю ввести новое значение
                }
            }

            return arvud;
        }

        public static void ArvudeStatistika(double[] arvud)
        {
            double max = arvud[0];
            double min = arvud[0];
            double summa = 0;

            foreach (double arv in arvud)
            {
                if (arv > max) max = arv;
                if (arv < min) min = arv;
                summa += arv;
            }

            double keskmine = summa / arvud.Length;


            Console.WriteLine($"Miinimum: {min}");
            Console.WriteLine($"Keskmine: {keskmine}");
            Console.WriteLine($"Maksimum: {max}");
            Console.WriteLine($"Summa: {summa}");

            // BONUS
            Array.Sort(arvud);
            Console.WriteLine("Sorteeritud arvud: " + string.Join(", ", arvud));
        }



        public static void LemmikloomadeRegister()
        {
            List<Lemmikloom> loomad = new List<Lemmikloom>();

            Console.WriteLine("Vali režiim:");
            Console.WriteLine("1 - Sisesta loomad käsitsi");
            Console.WriteLine("2 - Loo loomad automaatselt");
            Console.Write("Sinu valik: ");
            string valik = Console.ReadLine();

            if (valik == "1")
            {
                // Ручной ввод
                for (int i = 0; i < 5; i++)
                {
                    Console.WriteLine($"Lemmikloom #{i + 1}:");
                    Console.Write("Nimi: ");
                    string nimi = Console.ReadLine();
                    Console.Write("Liik (kass või koer): ");
                    string liik = Console.ReadLine();

                    int vanus;
                    while (true)
                    {
                        Console.Write("Vanus: ");
                        if (int.TryParse(Console.ReadLine(), out vanus))
                        {
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Viga! Palun sisesta korrektne täisarv.");
                        }
                    }

                    loomad.Add(new Lemmikloom(nimi, liik, vanus));
                }
            }
            else if (valik == "2")
            {
                // Автоматическое создание
                Random rnd = new Random();
                string[] nimed = { "Muri", "Miisu", "Pontu", "Leo", "Bella", "Nora", "Miki", "Simba", "Oscar", "Luna" };
                string[] liigid = { "kass", "koer" };

                for (int i = 0; i < 5; i++)
                {
                    string nimi = nimed[rnd.Next(nimed.Length)];
                    string liik = liigid[rnd.Next(liigid.Length)];
                    int vanus = rnd.Next(1, 15); // возраст от 1 до 14

                    loomad.Add(new Lemmikloom(nimi, liik, vanus));
                }

                Console.WriteLine("\nLoomad loodud automaatselt!");
            }
            else
            {
                Console.WriteLine("Vale valik. Programm lõpetab töö.");
                return;
            }

            Console.WriteLine("\n------------------ Kõik kassid ------------------");
            foreach (var kass in loomad.Where(l => l.Liik.ToLower() == "kass"))
            {
                Console.WriteLine($"Nimi: {kass.Nimi,-10} | Liik: {kass.Liik,-5} | Vanus: {kass.Vanus} a"); /*выравнивает красиво вывод информации*/ /*Console.WriteLine($"{kass.Nimi} ({kass.Vanus} a) – {kass.Liik}");*/
            }

            double keskmineVanus = loomad.Average(l => l.Vanus);
            Console.WriteLine($"\nKeskmine vanus: {keskmineVanus:F2}");

            var vanim = loomad.OrderByDescending(l => l.Vanus).First();
            Console.WriteLine($"\nVanim loom: {vanim.Nimi}, {vanim.Liik}, {vanim.Vanus} a");

            // BONUS – Поиск по имени
            Console.Write("\nSisesta looma nimi otsinguks: ");
            string otsi = Console.ReadLine();
            var leitud = loomad.FirstOrDefault(l => l.Nimi.Equals(otsi, StringComparison.OrdinalIgnoreCase));
            if (leitud != null)
                Console.WriteLine($"Leitud: {leitud.Nimi}, {leitud.Liik}, {leitud.Vanus} a");
            else
                Console.WriteLine("Looma ei leitud.");

            Console.ReadLine(); // Чтобы окно не закрылось
        }

        public static void ValuutaKalkulaator()
        {
            // Добавляем валюты в словарь
            Dictionary<string, Valuutta> valuutad = new Dictionary<string, Valuutta>()
            {
                { "USD", new Valuutta("USD", 1.08) }, // 1 EUR = 1.08 USD
                { "GBP", new Valuutta("GBP", 0.86) }  // 1 EUR = 0.86 GBP
            };

            double summa;
            while (true)
            {
                Console.Write("\nSisesta summa: ");
                if (double.TryParse(Console.ReadLine(), out summa))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Viga! Palun sisesta korrektne summa.");
                }
            }

            Console.Write("Sisesta valuutanimi (nt USD, GBP): ");
            string sisendValuuta = Console.ReadLine().ToUpper();

            if (!valuutad.ContainsKey(sisendValuuta))
            {
                Console.WriteLine("Sellist valuutat ei leitud.");
                return;
            }

            Valuutta v = valuutad[sisendValuuta];

            // Перевод в EUR
            double eurodes = summa / v.KurssEurSuhte;
            Console.WriteLine($"{summa} {v.Nimetus} = {eurodes:F2} EUR");

            // Найти другую валюту
            string teineValuuta = valuutad.Keys.FirstOrDefault(k => k != sisendValuuta);

            if (teineValuuta != null)
            {
                Valuutta teine = valuutad[teineValuuta];
                double teisendatud = eurodes * teine.KurssEurSuhte;
                Console.WriteLine($"{eurodes:F2} EUR = {teisendatud:F2} {teine.Nimetus}");
            }
            else
            {
                Console.WriteLine("Teist valuutat teisendamiseks ei leitud.");
            }

            Console.ReadLine();
        }

        class Lemmikloom
    {
        public string Nimi { get; set; }
        public string Liik { get; set; }
        public int Vanus { get; set; }

        public Lemmikloom(string nimi, string liik, int vanus)
        {
            Nimi = nimi;
            Liik = liik;
            Vanus = vanus;
        }
    }

        public class Valuutta
        {
            public string Nimetus { get; set; }
            public double KurssEurSuhte { get; set; }

            public Valuutta(string nimetus, double kurssEurSuhte)
            {
                Nimetus = nimetus;
                KurssEurSuhte = kurssEurSuhte;
            }
        }
    }

}

