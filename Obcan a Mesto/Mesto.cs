using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Obcan_a_Mesto
{
     class Mesto
    {
        public string nazovMesta;
        public List<Obcan> obcania = new List<Obcan>();
    

        public Mesto(string nazovMesta)
        {
            this.nazovMesta = nazovMesta;
            obcania = new List<Obcan>();
            
        }


        
        public void PridajObcanaDoMesta(Obcan obcan)
        {
            obcania.Add(obcan);
        }
        public void VypisObcanov()
        { 
            Console.WriteLine("Obcania mesta " + nazovMesta + ":");
            foreach (var obcan in obcania)
            {
                obcan.VypisInfo();
            }
        }
    }
}

