using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24C_SHARP._3._Kordused
{
    internal class ArvuTöötlus
    {
        public int[] GenereeriRuudud(int min, int max)
        {
            Random rnd = new Random();

            int N = rnd.Next(min, max + 1);  // juhuslik arv
            int M = rnd.Next(min, max + 1);  // juhuslik arv

            Console.WriteLine($"Genereeritud arvud: {N} ja {M}");

            int väiksem = Math.Min(N, M);
            int suurem = Math.Max(N, M);

            int suurus = suurem - väiksem + 1;
            int[] ruudud = new int[suurus];

            for (int i = 0; i < suurus; i++)
            {
                int arv = väiksem + i;
                ruudud[i] = arv * arv;
            }

            return ruudud;
        }
    }
}
