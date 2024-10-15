namespace Cvicenie_OOP_Hra
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Player kladnaPostava = new Player() { Name = "Witcher", AttackPower = 10, HP = 1000, Mana = 50 };
            Player zapornaPostava = new Player() { Name = "Magician", AttackPower = 500, HP = 200, Mana = 50 };


            /* Console.WriteLine("Zaporna postava HP:" + zapornaPostava.HP);
             kladnaPostava.DamagePlayer(zapornaPostava);
             Console.WriteLine("Zaporna postava HP:" + zapornaPostava.HP);*/


            while (true)
            {
                Console.WriteLine("Witcher :" + kladnaPostava.HP);
                Console.WriteLine("Magician :" + zapornaPostava.HP);
                kladnaPostava.DamagePlayer(zapornaPostava);
                zapornaPostava.DamagePlayer(kladnaPostava);

                if (kladnaPostava.HP < 0)
                   
                {
                    Console.WriteLine("Magician wins !");
                    break;
                }
                if (zapornaPostava.HP < 0)
                 
                {
                    Console.WriteLine("Witcher wins !");
                    break;
                }
            }
        }
    }
}