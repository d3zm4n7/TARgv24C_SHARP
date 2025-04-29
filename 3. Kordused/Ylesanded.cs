using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24C_SHARP._3._Kordused
{
    internal class Ylesanded
    {
        public static void Main(string[] args)
        {
            /* Ylesanne 1 */
            Console.Write("\n1. Juhuslike arvude ruudud \n");

            ArvuTöötlus töötlus = new ArvuTöötlus();
            int[] tulemused = töötlus.GenereeriRuudud(-100, 100);

            int väiksem = 0;
            int suurem = 0;

            // Et näidata algväärtust, loeme need veel kord sisse
            Random rnd = new Random();
            int N = rnd.Next(-100, 101);
            int M = rnd.Next(-100, 101);
            väiksem = Math.Min(N, M);
            suurem = Math.Max(N, M);

            for (int i = 0; i < tulemused.Length; i++)
            {
                int arv = väiksem + i;
                Console.WriteLine($"{arv} >> {tulemused[i]}");
            }

            /* Ylesanne 2 */
            Console.WriteLine("\n2. Viie arvu analüüs\n");
            double[] arvud = Tekstist_arvud();
            var tulemus1 = AnalüüsiArve(arvud);   

            Console.WriteLine("\nTulemused:");
            Console.WriteLine($"Summa    : {tulemus1.Item1:F2}");
            Console.WriteLine($"Keskmine : {tulemus1.Item2:F2}");
            Console.WriteLine($"Korrutis : {tulemus1.Item3:F2}");

            /* Ylesanne 3 */
            Console.WriteLine("\n3. Nimed ja vanused");
            List<Inimene> inimesed = new List<Inimene>();

            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Sisesta nimi {i + 1}: ");
                string nimi = Console.ReadLine();

                Console.Write($"Sisesta vanus {i + 1}: ");
                int vanus = int.Parse(Console.ReadLine());

                inimesed.Add(new Inimene
                {
                    Nimi = nimi,
                    Vanus = vanus
                });
            }

            var tulemus2 = Statistika(inimesed);  

            Console.WriteLine($"\nVanuste summa   : {tulemus2.Item1}");
            Console.WriteLine($"Vanuste keskmine: {tulemus2.Item2:F2}");
            Console.WriteLine($"Vanim inimene   : {tulemus2.Item3.Nimi} ({tulemus2.Item3.Vanus} a)");
            Console.WriteLine($"Noorim inimene  : {tulemus2.Item4.Nimi} ({tulemus2.Item4.Vanus} a)");

            /* Ylesanne 4 */
            Console.WriteLine("\n4. Suurim neliarvuline arv\n");

            double[] sisend = new double[4];
            for (int i = 0; i < 4; i++)
            {
                Console.Write($"Sisesta ühekohaline arv {i + 1}: ");
                sisend[i] = double.Parse(Console.ReadLine());
            }

            try
            {
                int maxNeljarv = SuurimNeljarv(sisend);
                Console.WriteLine($"Suurim võimalik neljakohaline arv: {maxNeljarv}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Viga: " + ex.Message);
            }


            /* Ylesanne 5 */
            Console.WriteLine("\n5. Keskmisest suuremad\n");
            int[] arvud1 = new int[15];
            Random rnd1 = new Random();

            // 1. Genereeri juhuslikud arvud ja salvesta massiivi
            for (int i = 0; i < arvud1.Length; i++)
            {
                arvud1[i] = rnd1.Next(1, 101); // [1, 100]
            }
            Console.WriteLine("Genereeritud arvud:");
            Console.WriteLine(string.Join(", ", arvud1));

            // 2. Leia keskmine väärtus
            int summa = 0;
            foreach (int arv in arvud1)
            {
                summa += arv;
            }
            double keskmine = (double)summa / arvud.Length;
            Console.WriteLine($"\nKeskmine väärtus: {keskmine:F2}");

            // 3. Väljasta ainult need arvud, mis on suuremad kui keskmine
            Console.WriteLine("\nArvud, mis on suuremad kui keskmine:");
            foreach (int arv in arvud)
            {
                if (arv > keskmine)
                {
                    Console.Write(arv + " ");
                }
            }
            Console.WriteLine();

            // 4. do-while tsükkel kuni < 10
            Console.WriteLine("\nArvud kuni esimese väiksema kui 10:");
            int indeks = 0;
            do
            {
                Console.Write(arvud[indeks] + " ");
                indeks++;
            } while (indeks < arvud.Length && arvud[indeks - 1] >= 10);
            Console.ReadKey();
        }

        public static double[] Tekstist_arvud()
        {
            double[] arvud = new double[5];
            for (int i = 0; i < 5; i++)
            {
                Console.Write($"Sisesta arv {i + 1}: ");
                arvud[i] = double.Parse(Console.ReadLine());
            }
            return arvud;
        }

        public static Tuple<double, double, double> AnalüüsiArve(double[] arvud)
        {
            double summa = 0;
            double korrutis = 1;

            foreach (double arv in arvud)
            {
                summa += arv;
                korrutis *= arv;
            }

            double keskmine = summa / arvud.Length;
            return Tuple.Create(summa, keskmine, korrutis);
        }

        public static Tuple<int, double, Inimene, Inimene> Statistika(List<Inimene> inimesed)
        {
            int summa = 0;
            Inimene vanim = inimesed[0];
            Inimene noorim = inimesed[0];

            foreach (var inimene in inimesed)
            {
                summa += inimene.Vanus;

                if (inimene.Vanus > vanim.Vanus)
                    vanim = inimene;

                if (inimene.Vanus < noorim.Vanus)
                    noorim = inimene;
            }

            double keskmine = (double)summa / inimesed.Count;
            return Tuple.Create(summa, keskmine, vanim, noorim);
        }
   
        public static int SuurimNeljarv(double[] arvud)
            {
                List<int> numbrid = new List<int>();

                foreach (var arv in arvud)
                {
                    if (arv % 1 != 0 || arv < 0 || arv > 9)
                    {
                        throw new ArgumentException("Kõik arvud peavad olema ühekohalised täisarvud (0–9).");
                    }
                    numbrid.Add((int)arv);
                }

                // Sorteerime kahanevalt
                numbrid.Sort();
                numbrid.Reverse();

                // Loome täisarvu: nt [7, 5, 3, 1] -> 7531
                string maxNumberStr = string.Join("", numbrid);
                return int.Parse(maxNumberStr);
            }

        public class Inimene
        {
            public string Nimi;
            public int Vanus;
        }
    }
}
