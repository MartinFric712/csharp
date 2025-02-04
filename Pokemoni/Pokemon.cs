using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Game
{
    internal class Pokemon
    {
        public string Name { get; set; }
        public int Health { get; set; }

        public Pokemon(string name)
        {
            Name = name;
            Health = 100;
        }

        public int Attack1()
        {
            Random random = new Random();
            return random.Next(10, 91);
        }

        public int Attack2()
        {
            Random random = new Random();
            return random.Next(30, 71);
        }

        public int Attack3()
        {
            Random random = new Random();
            return random.Next(40, 61);
        }

        public int Heal()
        {
            Random random = new Random();
            int healValue = random.Next(20, 71);
            Health += healValue;
            if (Health > 100);
            {
                Health = 100;
            }
            return Health;

        }
    }
}

