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

            /*Ylesanne5*/
            Console.Write("5.osa - Ylesanne 5. Arvuda massiivi statistika. \n");

            (int[] ruudud, int[] arvud) = ArvuTöötlus.GenereeriRuudud(-100, 100); // получаем два массива

            for (int i = 0; i < ruudud.Length; i++)
            {
                Console.WriteLine($"{arvud[i]} -> {ruudud[i]}");
            }

            Console.ReadKey();



        }
    }
}
