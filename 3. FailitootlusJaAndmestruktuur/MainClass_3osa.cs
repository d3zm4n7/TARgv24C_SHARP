using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24C_SHARP._3._FailitootlusJaAndmestruktuur
{
    internal class MainClass_3osa
    {
        public static void Main(string[] args)
        {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kuud.txt");

            try
            {
                Console.WriteLine("Sisesta mingi tekst: ");
                string lause = Console.ReadLine();

                using (StreamWriter sw = new StreamWriter(path, true)) // true = lisa lõppu
                {
                    sw.WriteLine("Midagi");
                    sw.WriteLine(lause); // можешь добавить строку, чтобы записывать введённый текст
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga");
            }

            try
            {
                StreamReader text = new StreamReader(path);
                string laused = text.ReadToEnd();
                text.Close();
                Console.WriteLine(laused);
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga, ei saa faili lugeda");
            }

            if (!File.Exists(path)) File.WriteAllLines(path, new string[] { "Jaanuar", "Veebruar", "Märts" });
            List<string> kuude_list = new List<string>();
            try
            {
                foreach (string rida in File.ReadAllLines(path))
                {
                    kuude_list.Add(rida);
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Viga failiga!");
            }

            foreach (string kuu in kuude_list)
            {
                Console.WriteLine(kuu);
            }

            // Eemalda "Juuni"
            kuude_list.Remove("Juuni");

            // Muuda esimest elementi
            if (kuude_list.Count > 0)
                kuude_list[0] = "Veeel kuuu";

            Console.WriteLine("--------------Kustutasime juuni-----------");

            foreach (string kuu in kuude_list)
            {
                Console.WriteLine(kuu);
            }

            Console.WriteLine("Sisesta kuu nimi, mida otsida:");
            string otsitav = Console.ReadLine();

            if (kuude_list.Contains(otsitav))
                Console.WriteLine("Kuu " + otsitav + " on olemas.");
            else
                Console.WriteLine("Sellist kuud pole.");

            File.WriteAllLines(path, kuude_list);
            Console.WriteLine("Andmed on salvestatud.");


        }
    }
}
