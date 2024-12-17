using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projekt___polrok
{
    internal class Kniha
    {
        public string Názov { get; set; }
        public int Rok { get; set; }
        public string Žáner { get; set; }
        public string Autor { get; set; }

        public Kniha(string názov, int rok, string žáner, string autor)
        {
            Názov = názov;
            Rok = rok;
            Žáner = žáner;
            Autor = autor;
        }
    }
}
