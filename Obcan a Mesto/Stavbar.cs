using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obcan_a_Mesto
{
    public class Stavbar : Obcan
    {
        public string programovacijazyk;
       public Stavbar(string meno, int Vek, string programovacijazyk): base (meno, Vek)
        {
            this.programovacijazyk = programovacijazyk;
        }
        public override void VypisInfo()
        {
            Console.WriteLine("Meno: " + Meno + " Vek: " + Vek + " programuje s " + programovacijazyk + "!");
        }
    }
}
