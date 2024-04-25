using RPG_GameLogic.Interfaces;
using System;

namespace RPG_GameLogic.Items.Weapons
{
    internal class Axe : IWeapon
    {
        public int Damage { get; }

        public Axe(int damage)
        {
            Damage = damage;
        }

        public void Attack(IUnit attacker, IUnit target, int damage)
        {
            Console.WriteLine($"{attacker.Name} attacks {target.Name} with the axe for {damage} damage!");
            target.TakeDamage(damage);
        }
    }
}
