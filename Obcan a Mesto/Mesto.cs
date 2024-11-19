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
        private string nazovMesta;
        private List<Obcan> obcania = new List<Obcan>();
  
        public string NazovMesta
        {
            get { return nazovMesta; }
            set { nazovMesta = value; }
        }
        public List<Obcan> Obcania
        {
            get { return obcania;  }
            set { obcania = value; }
        }
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

