using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obcan_a_Mesto
{
    internal class Obcan
    {
        public string Meno { get; set; }
        public int Vek { get; set; }
        public Obcan(string meno, int vek)
        {
            Meno = meno;
            Vek = vek;
        }
        public void VypisInfo()
        {
            Console.WriteLine("Meno: " + Meno + "Vek: " + Vek);
        }
    }
}
