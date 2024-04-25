using RPG_GameLogic.Interfaces;
using System;

namespace RPG_GameLogic.Items.Weapons
{
    internal class Sword : IWeapon
    {
        public int Damage { get; }

        public Sword(int damage)
        {
            Damage = damage;
        }

        public void Attack(IUnit attacker, IUnit target, int damage)
        {
            Console.WriteLine($"{attacker.Name} attacks {target.Name} with the sword for {damage} damage!");
            target.TakeDamage(damage);
        }
    }
}
