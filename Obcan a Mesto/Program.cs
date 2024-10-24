namespace Obcan_a_Mesto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Vytvorenie mesta
            Mesto Zilina = new Mesto("Zilina");
            Mesto Martin = new Mesto("Martin");
             
            //Vytvorenie obcanov
            Obcan obcan1 = new Obcan("Jozko Mrkvicka, ", 24);
            Obcan obcan2 = new Obcan("Fero zbesily, ", 28);
            Obcan obcan3 = new Obcan("Martin Nemec, ", 35);
            Obcan obcan4 = new Obcan("Jakub Trieska, ", 26);

            //Vytvorenie lekarov
            Lekar lekar1 = new Lekar("Adrian Hoferica, ", 45);
            Lekar lekar2 = new Lekar("Jakub Svelka, ", 28);

            //Vytvorenie stavbarov
            Stavbar stavbar1 = new Stavbar("Majko Vajko, ", 85);
            Stavbar stavbar2 = new Stavbar("Oliver Pohorecky, ", 54);

            //Vytvorenie ucitelov 
            Ucitel ucitel1 = new Ucitel("Mariana Kyzekova, ", 38);
            Ucitel ucitel2 = new Ucitel("Lenka Narodna, ", 25);

            //Pridanie obcanov do Ziliny
            Zilina.PridajObcanaDoMesta(obcan3);
            Zilina.PridajObcanaDoMesta(obcan4);

            //Pridanie obcanov do Martina
            Martin.PridajObcanaDoMesta(obcan1);
            Martin.PridajObcanaDoMesta(obcan2);

            //Pridanie lekarov do Ziliny
            Zilina.PridajLekaraDoMesta(lekar1);
            
            //Pridanie lekarov do Martina
            Zilina.PridajLekaraDoMesta(lekar2);

            //Pridanie stavbarov do Ziliny
            Zilina.PridajStavbaraDoMesta(stavbar1);

            // Pridanie stavbarov do Martina
            Martin.PridajStavbaraDoMesta(stavbar2);

            //Pridanie ucitelov do Ziliny
            Zilina.PridajUcitelaDoMesta(ucitel1);

            //Pridanie ucitelov do Martina
            Martin.PridajUcitelaDoMesta(ucitel2);

            //Vypis obcanov v Ziline
            Zilina.VypisObcanov();

            //Vypis obcanov v Martine
            Martin.VypisObcanov();

            
        }
    }
}