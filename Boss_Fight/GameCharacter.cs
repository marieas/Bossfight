using System;
using System.Collections.Generic;
using System.Text;

namespace Boss_Fight
{
    public class GameCharacter
    {
        public int Strength { get; private set; }
        public int Health { get; private set; }
        public int Stamina { get; private set; }
        public int MaxStamina { get; private set; }
        public int MaxHealth { get; private set; }
        
        public string Name { get; set; }
        private int _strengthOffset;
        public GameCharacter(int health,int strength, int stamina, string name)
        {
            Strength = strength;
            Stamina = stamina;
            MaxStamina = stamina;
            Health = health;
            MaxHealth = health;
            Name = name;
            _strengthOffset = 0;
        }
        public void Fight(GameCharacter opponent)
        {
            if(Stamina >= 10)
            {
                Console.WriteLine($"{Name} hit with {Strength} damage");
                opponent.TakeDamage(Strength + _strengthOffset,Name);
                Stamina = Stamina - 10;
            }
            else
            {
                Recharge();
            }

            _strengthOffset = 0;
        }
        public void Fight(GameCharacter opponent, int strength)
        {
            Strength = strength;
            Fight(opponent);
        }

        public void IncreaseHealth()
        {
            Health = MaxHealth;
        }

        public void IncreaseStrength()
        {
            _strengthOffset = 30;
        }
        public void IncreaseStamina()
        {
            Stamina = MaxStamina;
        }
        public void TakeDamage(int damage,string opponentName )
        {
            Health -= damage;
            Console.WriteLine(Health <= 0
                ? $"{Name} died, the winner is {opponentName}!"
                : $"{Name} lost {damage} health. Remaining health: {Health}");
        }
        public void Recharge()
        {
            Stamina = MaxStamina;
            Console.WriteLine($"{Name} is out of stamina, recharging");
        }
    }
}
