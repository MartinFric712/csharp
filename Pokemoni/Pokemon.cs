using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon_Game
{
    public class Pokemon
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

        public bool TakeDamage(int damage)
        {
            Health -= damage;
            if (Health <= 0)
            {
                Health = 0;
                return false;
            }
            return true;
        }

        public void TakeHeal(int heal)
        {
            Health += heal;
            if (Health >= 100)
            {
                Health = 100;
            }
        }

        public int Heal()
        {
            Random random = new Random();
            return random.Next(20, 71);
        }
    }
}

