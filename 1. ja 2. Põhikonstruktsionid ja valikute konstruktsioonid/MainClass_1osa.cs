using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TARgv24C_SHARP._3._Kordused;

namespace TARgv24C_SHARP._1._Põhikonstruktsionid
{
    internal class MainClass_1osa
    {
        public static void Main(string[] args)
        {
            // I. osa Andmetüübid, If, Case, Random, Alamfunktsioonid

            Console.BackgroundColor = ConsoleColor.Green;
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Hello World! Привет! Tere päevast!");

            int a = 0;
            string tekst = "Python";
            char taht = 'A';
            double arv = 5.45435333353;
            float arv1 = 2;
            Console.Write("Mis on sinu nimi? ");
            tekst = Console.ReadLine();
            Console.WriteLine("Tere!\n" + tekst);
            Console.WriteLine("\nTere {0}!", tekst);

            // II. osa C# Valikute konstruktsionid
            if (tekst.ToLower() == "juku")
            {
                Console.WriteLine("Lähme kinno!");
                try
                {
                    Console.WriteLine("{0}\n Kui vana sa oled?", tekst);
                    int vanus = int.Parse(Console.ReadLine());
                    string pilet_vastus = FunktsioonideClass_1osa.VanusePilet(vanus);
                    Console.WriteLine(pilet_vastus);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("Olen hõivatud");
            }

            Console.WriteLine("Arv 2: ");
            int arv2 = int.Parse(Console.ReadLine());
            // Console.WriteLine("Arvude {0} ja {1} korrutis võrdub {2}", arv1, arv2, arv1 * arv2);
            arv1 = FunktsioonideClass_1osa.Kalkulaator(a, arv2);
            Console.WriteLine(arv1);

            Console.WriteLine("Switch'i kasutamine");
            Random rnd = new Random();
            a = rnd.Next(1, 7);
            Console.WriteLine(a);

            tekst = FunktsioonideClass_1osa.switchKasuta(a);
            Console.WriteLine(tekst);

            Console.ReadKey();


            // Küsi kahe inimese nimed ning teata, et nad on täna pinginaabrid
            Console.Write("Sisesta esimene nimi:");
            string nimi1 = Console.ReadLine();
            Console.Write("Sisesta teine nimi:");
            string nimi2 = Console.ReadLine();
            string nimi_vastus = FunktsioonideClass_1osa.Pinginaabrid(nimi1, nimi2);
            Console.WriteLine(nimi_vastus);


            // Küsi ristkülikukujulise toa seinte pikkused ning arvuta põranda pindala.
            // Küsi kasutajalt remondi tegemise soov, kui ta on positiivne, siis küsi kui palju maksab ruutmeeter ja leia põranda vahetamise hind
            double c = 0, d = 0;
            try
            {
                Console.Write("Sisestage esimese seina pikkus:");
                c = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            try
            {
                Console.Write("Sisestage teise seina pikkus:");
                d = Convert.ToDouble(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            double vastus = FunktsioonideClass_1osa.Korrutamine(c, d);
            Console.WriteLine("Põranda pindala on " + vastus);
            Console.Write("Kas soovite remodi teha?");
            string vastus2 = Console.ReadLine();
            if (vastus2.ToLower() == "jah")
            {
                try
                {
                    Console.Write("Sisestage kui palju maksab ruutmeeter:");
                    double hind = Convert.ToDouble(Console.ReadLine());
                    double vastus3 = FunktsioonideClass_1osa.Korrutamine(hind, vastus);
                    Console.WriteLine("Põranda vahetamise hind on " + vastus3);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }
            else
            {
                Console.WriteLine("Aitäh! Head aega!");
            }


            // Leia 30% hinnasoodustusega hinna põhjal alghind
            try
            {
                Console.Write("Sisestage alghind: ");
                double alghind = Convert.ToDouble(Console.ReadLine());
                vastus = FunktsioonideClass_1osa.Hinnasoodustus(alghind);
                Console.WriteLine("Soodustusega 30% lõpphind on " + vastus);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            // Küsi temperatuur ning teata, kas see on üle kaheksateistkümne kraadi (soovitav toasoojus talvel)
            try
            {
                Console.Write("Sisestage toa temperatuur: ");
                int temp = int.Parse(Console.ReadLine());
                vastus2 = FunktsioonideClass_1osa.Temperatuur(temp);
                Console.WriteLine(vastus2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            // Küsi inimese pikkus ning teata, kas ta on lühike, keskmine või pikk (piirid pane ise paika)
            int pikkus = 0;
            try
            {
                Console.Write("Sisestage oma pikkus: ");
                pikkus = int.Parse(Console.ReadLine());
                vastus2 = FunktsioonideClass_1osa.Pikkus(pikkus);
                Console.WriteLine(vastus2);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }


            // Küsi inimeselt pikkus ja sugu ning teata, kas ta on lühike, keskmine või pikk (mitu tingimusplokki võib olla üksteise sees).
            try
            {
                Console.Write("Sisestage oma pikkus: ");
                pikkus = int.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            Console.Write("Sisestage oma sugu: ");
            string sugu = Console.ReadLine();
            vastus2 = FunktsioonideClass_1osa.PikkusSugu(pikkus, sugu);
            Console.WriteLine(vastus2);


            // Küsi inimeselt poes eraldi kas ta soovib osta piima, saia, leiba.
            // Löö hinnad kokku ning teata, mis kõik ostetud kraam maksma läheb.
            Console.Write("Kas te soovite osta piima? (jah/ei): ");
            string piim_vastus = Console.ReadLine();
            int piim_kogus = 0;
            if (piim_vastus.ToLower() == "jah")
            {
                try
                {
                    Console.Write("Kui palju piima soovite osta? ");
                    piim_kogus = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            Console.Write("Kas te soovite osta saia?(jah/ei): ");
            string sai_vastus = Console.ReadLine();
            int sai_kogus = 0;
            if (sai_vastus.ToLower() == "jah")
            {
                try
                {
                    Console.Write("Kui palju saia soovite osta? ");
                    sai_kogus = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            Console.Write("Kas te soovite osta leiba?(jah/ei): ");
            string leib_vastus = Console.ReadLine();
            int leib_kogus = 0;
            if (leib_vastus.ToLower() == "jah")
            {
                try
                {
                    Console.Write("Kui palju saia soovite osta? ");
                    leib_kogus = int.Parse(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                }
            }

            string ostutsekk = FunktsioonideClass_1osa.Ostukorv(piim_kogus, sai_kogus, leib_kogus);
            Console.WriteLine("\n" + ostutsekk);

            Console.ReadLine();
        }

    }
}
