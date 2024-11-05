namespace Obcan_a_Mesto
{
    public static class GeneratorObcanov
    {
        public static string[] mena = { "Igor", "Anna", "Peter", "Jana", "Martin", "Lucia",
            "Tomáš", "Eva", "Michal", "Zuzana", "Marek", "Katarína", "Andrej", "Lenka", "Patrik",
            "Monika", "Filip", "Veronika", "Richard", "Simona", "Róbert", "Mária", "Jakub", "Barbora",
            "Adam", "Dominika", "Lukáš", "Daniela", "Vladimír", "Nikola" };
        public static string[] programovacieJazyky = { "C#", "C++","C","Python","Java" };
        public static Obcan GenreujObcana()
        {
            Random random = new Random();
            int pozicia = random.Next(mena.Length);
            string meno = mena[pozicia];
            int vek = random.Next(15, 116);
            Obcan obcan = new Obcan(meno, vek);
            return obcan;
            
        }
        public static Stavbar GenerujJazyk()
        {
            Random random2 = new Random();
            int pozicia = random2.Next(mena.Length);
            string meno = mena[pozicia];
            int vek = random2.Next(15, 116);
            int pozicia2 = random2.Next(programovacieJazyky.Length);
            string programovacijazyk = programovacieJazyky[pozicia2];
            Stavbar programator = new Stavbar(meno, vek, programovacijazyk);
            return programator;


        }
    }
}
