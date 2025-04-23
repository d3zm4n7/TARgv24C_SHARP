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
            int rohkem_kui_keskmine = 0;

            foreach (double arv in arvud)
            {
                if (arv > keskmine)
                    rohkem_kui_keskmine++;
            }

            Console.WriteLine($"Maksimum: {max}");
            Console.WriteLine($"Miinimum: {min}");
            Console.WriteLine($"Keskmine: {keskmine}");
            Console.WriteLine($"Summa: {summa}");
            Console.WriteLine($"Rohkem kui keskmine: {rohkem_kui_keskmine}");

            // BONUS
            Array.Sort(arvud);
            Console.WriteLine("Sorteeritud arvud: " + string.Join(", ", arvud));
        }
    }
}
