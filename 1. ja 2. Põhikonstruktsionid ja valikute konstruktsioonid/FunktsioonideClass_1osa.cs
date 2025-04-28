using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24C_SHARP._1._Põhikonstruktsionid
{
    internal class FunktsioonideClass_1osa
    {
        public static float Kalkulaator(int arv1, int arv2)
        {
            float kalkulaator = 0;
            kalkulaator = arv1 * arv2;
            return kalkulaator;
        }

        public static string switchKasuta(int a)
        {
            string tekst;

            switch (a)
            {
                case 1: tekst = "Esmaspäev"; break;
                case 2: tekst = "Teisipäev"; break;
                case 3: tekst = "Kolmapäev"; break;
                case 4: tekst = "Neljapäev"; break;
                case 5: tekst = "Reede"; break;
                case 6: tekst = "Laupäev"; break;
                case 7: tekst = "Pühapäev"; break;

                default:
                    tekst = "Tundmatu";
                    break;
            }
            return tekst;
        }

        public static string VanusePilet(int vanus)
        {
            string vastus;

            if (vanus <= 0 || vanus > 100)  // && - and, || - or
            {
                vastus = "Viga!";
            }
            else if (vanus > 0 && vanus <= 6)
            {
                vastus = "Tasuta";
            }
            else if (vanus < 15)
            {
                vastus = "Lastepilet";
            }
            else if (vanus >= 15 && vanus < 65)
            {
                vastus = "Täispilet!";
            }
            else
            {
                vastus = "Sooduspilet!";
            }

            return vastus;
        }

        public static string Pinginaabrid(string a, string b)
        {
            string vastus;

            if (a.ToLower() == "kirill" && b.ToLower() == "gleb" || a.ToLower() == "gleb" && b.ToLower() == "kirill")
            {
                vastus = "Need inimesed on pinginaabrid!";
            }
            else
            {
                vastus = "Need inimesed ei ole pinginaabrid!";
            }
            return vastus;
        }

        public static double Korrutamine(double a, double b)
        {
            double vastus = a * b;
            return vastus;
        }

        public static double Hinnasoodustus(double a)
        {
            double vastus = a * 0.7;
            return vastus;
        }

        public static string Temperatuur(int a)
        {
            string vastus;
            if (a > 18)
            {
                vastus = "Temperatuur " + a + " on soovitav toasoojus talvel";
            }
            else
            {
                vastus = "Temperatuur ei ole soovitav talvel";
            }
            return vastus;
        }

        public static string Pikkus(int a)
        {
            string vastus;
            if (a < 160)
            {
                vastus = "Pikkus " + a + " cm, te olete lühikest kasvu";
            }
            else if (a >= 160 || a < 175)
            {
                vastus = "Pikkus " + a + " cm, te olete keskmist kasvu";
            }
            else
            {
                vastus = "Pikkus " + a + " cm, te olete pikka kasvu";
            }
            return vastus;
        }

        public static string PikkusSugu(int pikkus, string sugu)
        {
            string vastus;
            if (sugu.ToLower() == "mees")
            {
                if (pikkus < 160)
                {
                    vastus = "Pikkus " + pikkus + " cm, te olete lühikest kasvu meeste jaoks";
                }
                else if (pikkus >= 160 && pikkus < 175)
                {
                    vastus = "Pikkus " + pikkus + " cm, te olete keskmist kasvu meeste jaoks";
                }
                else
                {
                    vastus = "Pikkus " + pikkus + " cm, te olete pikka kasvu meeste jaoks";
                }
            }
            else if (sugu.ToLower() == "naine")
            {
                if (pikkus < 150)
                {
                    vastus = "Pikkus " + pikkus + " cm, te olete lühikest kasvu naiste jaoks";
                }
                else if (pikkus >= 150 && pikkus < 170)
                {
                    vastus = "Pikkus " + pikkus + " cm, te olete keskmist kasvu naiste jaoks";
                }
                else
                {
                    vastus = "Pikkus " + pikkus + " cm, te olete pikka kasvu naiste jaoks";
                }
            }
            else
            {
                vastus = "Tundmatu sugu!";
            }

            return vastus;
        }
        public static string Ostukorv(int piim_kogus, int sai_kogus, int leib_kogus)
        {
            Random rnd = new Random();
            double piim_hind = Math.Round(rnd.NextDouble() * 1.5 + 0.5, 2);
            double sai_hind = Math.Round(rnd.NextDouble() * 1.5 + 0.5, 2);
            double leib_hind = Math.Round(rnd.NextDouble() * 1.5 + 0.5, 2);

            double piim_summa = piim_kogus * piim_hind;
            double sai_summa = sai_kogus * sai_hind;
            double leib_summa = leib_kogus * leib_hind;
            double summa = piim_summa + sai_summa + leib_summa;

            if (summa == 0)
            {
                return "Te ei ostnud midagi. Head aega!";
            }

            string vastus = "Ostutšekk\n";
            if (piim_kogus > 0)
            {
                vastus += "Piim: " + piim_kogus + " tk - " + piim_summa + " €\n";
            }
            if (sai_kogus > 0)
            {
                vastus += "Sai: " + sai_kogus + " tk - " + sai_summa + " €\n";
            }

            if (leib_kogus > 0)
            {
                vastus += "Leib: " + leib_kogus + " tk - " + leib_summa + " €\n";
            }

            vastus += "Kokku: " + Math.Round(summa, 2) + " €";

            return vastus;
        }
    }
}
