using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24C_SHARP._2._Kordused
{
    internal class FunktsioonideClass_2osa
    {
        public static List<string> Sõnad()
        {
            List<string> sonad = new List<string>();
            for (int j = 0; j < 5; j++)
            {
                Console.Write("Nimi: ");
                sonad.Add(Console.ReadLine());
            }
            return sonad;
        }

        public static Isik[] Isikud(int k, string[] nimed, string[] aadressid)
        {
            Isik[] isikud = new Isik[k];

            for (int i = 0; i < k; i++)
            {
                Console.WriteLine(i);
                //isikud[i] = new Isik();
                Console.Write("Isikukood: ");
                isikud[i] = new Isik
                {
                    Nimi = nimed[i],
                    Vanus = 50,
                    Isikukood = Console.ReadLine(),
                    Aadress = aadressid[i]
                };
            }
            return isikud;
        }
        public static List<Isik> Isikud2(int k, string[] nimed, string[] aadressid)
        {
            List<Isik> isikud2 = new List<Isik>();
            for (int j = 0; j > k; j++)
            {
                Console.WriteLine(j);
                Isik isik = new Isik
                {
                    Nimi = nimed[j],
                    Vanus = 50,
                    Isikukood = "111111111111",
                    Aadress = aadressid[j]
                };
                isikud2.Add(isik);
            }
            return isikud2;
        }
    }
}
