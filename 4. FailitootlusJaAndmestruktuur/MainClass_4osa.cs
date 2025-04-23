using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TARgv24C_SHARP._4._FailitootlusJaAndmestruktuur
{
    internal class MainClass_4osa
    {
        public static void Main(string[] args)
        {
            /*Объявляем файл для всего класса*/
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Kuud.txt");

            /*Добавляем в файл слово*/
            try
            {
                Console.WriteLine("Sisesta mingi tekst: ");
                string lause = Console.ReadLine();

                using (StreamWriter sw = new StreamWriter(path, true)) // true = lisa lõppu
                {
                    sw.WriteLine(lause); // можешь добавить строку, чтобы записывать введённый текст
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga");
            }

            /*Читаем из файла все слова*/
            try
            {
                StreamReader text = new StreamReader(path);
                string laused = text.ReadToEnd();
                text.Close();
                Console.WriteLine("\nSõnad salvestatud failis on:");
                Console.WriteLine(laused);
            }
            catch (Exception)
            {
                Console.WriteLine("Mingi viga failiga, ei saa faili lugeda");
            }


            /*Список работы*/
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
            Console.ReadLine();

        }
    }
}
