using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Obcan_a_Mesto
{
    internal class Mesto
    {
        public string NazovMesta { get; set; }
        public List<Obcan> obcania { get; set; }
        public List<Lekar> lekari { get; set; }
        public List<Stavbar> stavbari { get; set; }
        public List<Ucitel> ucitelia { get; set; }

        public Mesto(string nazovMesta)
        {
            this.NazovMesta = nazovMesta;
            obcania = new List<Obcan>();
            lekari = new List<Lekar>();
            stavbari = new List<Stavbar>();
            ucitelia = new List<Ucitel>();
        }


        public void PridajUcitelaDoMesta(Ucitel ucitel)
        {
            ucitelia .Add(ucitel);
        }
        

        public void PridajStavbaraDoMesta(Stavbar stavbar)
        {
            stavbari.Add(stavbar);
        }
        


            public void PridajLekaraDoMesta(Lekar lekar)
        {
            lekari.Add(lekar);
        }
        


        public void PridajObcanaDoMesta(Obcan obcan)
        {
            obcania.Add(obcan);
        }
        public void VypisObcanov()
            {
                Console.WriteLine("Obcania mesta " + NazovMesta + ":");
                foreach (var obcan in obcania) 
                {
                    obcan.VypisInfo();
                }
                Console.WriteLine("\n");
            }
        }
    }

