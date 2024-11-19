using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obcan_a_Mesto
{
    internal class Ucitel
    {
        protected string Meno { get; set; }
        protected int Vek { get; set; }

        public Ucitel(string meno, int vek)
        {
            Meno = meno;
            Vek = vek;
        }
        public void Ucenie()
        {
            Console.WriteLine("Meno: " + Meno + " Vek: " + Vek + " je ucitel!");
        }
    }
}
