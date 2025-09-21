using System;
using System.Collections.Generic;
using System.Linq;

#nullable disable
class Szokitalalo
{
    static string[] Szavak = { "programozás", "alma", "iskola", "magyarország", "barát", "autóbusz", "távirányitó", "egészség", "sport", "zene", "film", "kávé", "matek" };

    static void Main()
    {
        var rnd = new Random();

        Console.WriteLine("=== Szókitaláló ===");
        bool ujra = true;
        while (ujra)
        {
            string cel = Szavak[rnd.Next(Szavak.Length)].ToLower();
            PlayGame(cel);
            Console.Write("\nSzeretnél még játszani? (i/n): ");
            string v = Console.ReadLine().ToLower();
            if (v == "i")
                ujra = true;
            else if (v == "n")
            {
                ujra = false;
                Console.WriteLine("Köszi, hogy játszottál! Viszlát!");
            }
        }
    }

    static void PlayGame(string cel)
    {
        int hp = 10;
        var kitalaltBetuk = new HashSet<char>();
        var hibasBetuk = new HashSet<char>();

        while (true)
        {
            Console.WriteLine("\n-----");
            Console.WriteLine($"Hátralévő életek: {hp}");
            Console.Write("Szó: ");
            bool teljes = true;
            foreach (char c in cel)
            {
                if (c == ' ')
                {
                    Console.Write(" ");
                    continue;
                }
                if (kitalaltBetuk.Contains(c))
                {
                    Console.Write(c);
                }
                else
                {
                    Console.Write("_");
                    teljes = false;
                }
                Console.Write(" ");
            }
            Console.WriteLine();

            if (teljes)
            {
                Console.WriteLine("\nGratulálok — kitaláltad a szót: " + cel);
                return;
            }

            Console.Write("Tipp (betű vagy szó): ");
            string bemenet = Console.ReadLine().ToLower() ?? "";
            if (bemenet == "")
            {
                Console.WriteLine("Nem adtál meg semmit, próbáld újra.");
                continue;
            }

            if (bemenet.Length > 1)
            {
                if (bemenet == cel)
                {
                    Console.WriteLine("\nHelyes! Teljes szó kitalálva: " + cel);
                    return;
                }
                else
                {
                    hp--;
                    Console.WriteLine("Rossz találat.");
                }
            }
            else
            {
                char betu = bemenet[0];

                if (kitalaltBetuk.Contains(betu) || hibasBetuk.Contains(betu))
                {
                    Console.WriteLine("Ezt a betűt már próbáltad: " + betu);
                    continue;
                }

                if (cel.Contains(betu))
                {
                    kitalaltBetuk.Add(betu);
                    Console.WriteLine("Talált!");
                }
                else
                {
                    hibasBetuk.Add(betu);
                    hp--;
                    Console.WriteLine("Nincs ilyen betű a szóban.");
                }
            }

            if (hibasBetuk.Count > 0)
            {
                Console.Write("Hibás betűk: ");
                Console.WriteLine(string.Join(", ", hibasBetuk));
            }

            if (hp == 0)
            {
                Console.WriteLine("\nVesztettél. A szó: " + cel);
                return;
            }
        }
    }
}
