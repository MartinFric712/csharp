namespace Obcan_a_Mesto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Vytvorenie mesta
            Mesto Zilina = new Mesto(nazovMesta: "Zilina");

            // Vytvorenie a zaradenie obcanov
            /*while (Zilina.obcania.Count < 31)
            {
                Obcan obcan = GeneratorObcanov.GenreujObcana();
                Zilina.PridajObcanaDoMesta(obcan);
            }*/

            for (int i = 0; i < 31; i++) 
            {
                Stavbar obcan = GeneratorObcanov.GenerujJazyk();
                Zilina.PridajObcanaDoMesta(obcan);
            }

            //Vypis obcanov Ziliny
            Zilina.VypisObcanov();
        }
    }
}