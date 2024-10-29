namespace Obcan_a_Mesto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vytvorenie mesta
            Mesto Zilina = new Mesto(nazovMesta: "Zilina");

            // Pridanie obcanov roznych typov
            Lekar lek = new Lekar(Meno: "Martin", Vek: 34);
            Stavbar stav = new Stavbar(Meno: "Alex", Vek: 38, typTehli: "Kamenne");
            SeniorStavbar senStav = new SeniorStavbar(Meno: "Igor", Vek: 45, typTehli: "Kamenne", pocetTehiel: 30);

            // Pridanie obcanov do mesta
            Zilina.PridajObcanaDoMesta(lek);
            Zilina.PridajObcanaDoMesta(stav);
            Zilina.PridajObcanaDoMesta(senStav);

            // Vypis vsetkych obcanov mesta
            Zilina.VypisObcanov();
        }
    }
}