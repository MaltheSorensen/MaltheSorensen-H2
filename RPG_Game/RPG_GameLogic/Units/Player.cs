using RPG_GameLogic.Interfaces;
using System;

namespace RPG_GameLogic.Units
{
    internal class Player : IUnit
    {
        private static readonly Random random = new Random();

        public string Name { get; set; }
        public string Description { get; set; }
        public int MaxHealth { get; set; }
        public int CurrentHealth { get; set; }

        public Player(string name, string description, int maxHealth)
        {
            Name = name;
            Description = description;
            MaxHealth = maxHealth;
            CurrentHealth = maxHealth;
        }

        public void Attack(IUnit target, IWeapon weapon, int damage)
        {
            Console.WriteLine($"{Name} attacks {target.Name} for {damage} damage!");
            target.TakeDamage(damage);
        }

        public void Die()
        {
            Console.WriteLine($"{Name} has been defeated!");
        }

        public void Move()
        {
            Console.WriteLine($"{Name} moves to a new location.");
        }

        public void TakeDamage(int damage)
        {
            CurrentHealth -= damage;
            if (CurrentHealth <= 0)
            {
                Die();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"Player current health: {CurrentHealth}");
                Console.ResetColor();
            }
        }
    }
}
