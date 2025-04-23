using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                arvud[i] = double.Parse(osad[i]);
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

            // Ввод данных от пользователя
            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine($"\nLemmikloom #{i + 1}:");
                Console.Write("Nimi: ");
                string nimi = Console.ReadLine();
                Console.Write("Liik (nt kass, koer): ");
                string liik = Console.ReadLine();
                Console.Write("Vanus: ");
                int vanus = int.Parse(Console.ReadLine());

                loomad.Add(new Lemmikloom(nimi, liik, vanus));
            }

            Console.WriteLine("\n--- Kõik kassid ---");
            foreach (var kass in loomad.Where(l => l.Liik.ToLower() == "kass"))
            {
                Console.WriteLine($"{kass.Nimi} ({kass.Vanus} a) – {kass.Liik}");
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
                Dictionary<string, Valuuta> valuutad = new Dictionary<string, Valuuta>()
                {
                    { "USD", new Valuuta("USD", 1.08) }, // 1 EUR = 1.08 USD
                    { "GBP", new Valuuta("GBP", 0.86) }, // 1 EUR = 0.86 GBP
                };

                Console.Write("Sisesta summa: ");
                double summa = double.Parse(Console.ReadLine());

                Console.Write("Sisesta valuutanimi (nt USD, GBP): ");
                string sisendValuuta = Console.ReadLine().ToUpper();

                if (!valuutad.ContainsKey(sisendValuuta))
                {
                    Console.WriteLine("Sellist valuutat ei leitud.");
                    return;
                }

                Valuuta v = valuutad[sisendValuuta];

                // Перевод в EUR
                double eurodes = summa / v.KurssEurSuhte;
                Console.WriteLine($"{summa} {v.Nimetus} = {eurodes:F2} EUR");

                // Перевод обратно из EUR
                double tagasi = eurodes * v.KurssEurSuhte;
                Console.WriteLine($"{eurodes:F2} EUR = {tagasi:F2} {v.Nimetus}");

                Console.ReadLine();
            }
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

    public class Valuuta
    {
        public string Nimetus { get; set; }           // например: USD, GBP, JPY
        public double KurssEurSuhte { get; set; }     // сколько 1 EUR стоит в этой валюте

        public Valuuta(string nimetus, double kurss)
        {
            Nimetus = nimetus.ToUpper();
            KurssEurSuhte = kurss;
        }
    }
}
