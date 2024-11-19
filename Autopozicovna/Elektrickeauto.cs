﻿

namespace Autopozicovna
{
     class Elektrickeauto : Auto
    {
        public int KapacitaBaterie { get; set; }
        public int DojazdNaNabitie { get; set; }
        public Elektrickeauto(string znacka, string model, decimal cenaZaDen, int kapacitaBaterie, int dojazdNaNabitie) : base(znacka,model,cenaZaDen)
        {
            KapacitaBaterie = kapacitaBaterie;
            DojazdNaNabitie = dojazdNaNabitie;
        }
        public override void VypisInfo()
        {
            base.VypisInfo();
            Console.WriteLine($"Kapacita batérie: {KapacitaBaterie} kWh, Dojazd na nabitie: {DojazdNaNabitie} km");
        }
    }
}