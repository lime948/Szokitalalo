using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

#nullable disable
namespace Szokitalalo
{
    internal class Program
    {
        static int hp = 10;
        static string[] szavak = { "első", "alma", "vizibicikli", "kukac" };
        static Random rnd = new Random();
        static string randomszo = szavak[rnd.Next(szavak.Length)];
        static int szoHossz = randomszo.Length;
        static void Main(string[] args)
        {
            Jatek();
        }
        static void Jatek()
        {
            Console.WriteLine("--- SZÓKITALÁLÓ ---");
            do
            {
                for (int i = 0; i < szoHossz; i++)
                {
                    Console.Write("_ ");
                }
                Console.WriteLine("Tippelj egy betűt! (Maradék életed: " + hp + " )");
                string betu = Console.ReadLine().ToLower();

                if (!randomszo.Contains(betu))
                {
                    Console.WriteLine("Nem talált!");
                    hp--;
                }
                if (betu.Length > 1)
                {
                    Console.WriteLine("Csak egy betűt írj be!");
                    hp++;
                    continue;

                }
                if (betu == "")
                {
                    Console.WriteLine("Nem írtál be semmit!");
                    continue;
                }
                if (randomszo.Contains(betu))
                {
                    Console.WriteLine("Talált!");

                    if (randomszo == betu)
                    {
                        Console.WriteLine("Nyertél! A szó: " + randomszo);
                        break;
                    }
                }
                if (hp == 0)
                {
                    Console.WriteLine("Vesztettél! A szó: " + randomszo);
                }
            } while (hp > 0);
        }
    }
}