using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Szokitalalo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            string szo = "szó";
            Console.WriteLine(szo[1]);
            string[] szavak = { "első", "alma", "vizibicikli", "kukac"};
            Random rnd = new Random();
            Console.WriteLine(szavak[rnd.Next(szavak.Length)]);

        }

    }
}