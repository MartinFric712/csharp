using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Obcan_a_Mesto
{
    public class Stavbar : Obcan
    {
        public string typTehli;
       public Stavbar(string Meno, int Vek, string typTehli): base (Meno, Vek)
        {
            this.typTehli=typTehli;
        }
        public new void VypisInfo()
        {
            Console.WriteLine("Meno: " + Meno + " Vek: " + Vek + " stava s " + typTehli + "!");
        }
    }
}
