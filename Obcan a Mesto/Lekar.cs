using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obcan_a_Mesto
{
    internal class Lekar
    {
        public string Meno { get; set; }
        public int Vek { get; set; }

        public Lekar(string name, int vek)
        {
            Meno = name;
            Vek = vek;
        }
        public void Liecenie()
        {
            Console.WriteLine("Meno: " + Meno + "Vek: " + Vek + " je lekar!");
        }
    }
}
