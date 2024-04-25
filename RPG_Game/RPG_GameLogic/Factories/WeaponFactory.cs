using RPG_GameLogic.Interfaces;
using RPG_GameLogic.Items.Weapons;
using System;

namespace RPG_GameLogic.Factories
{
    internal class WeaponFactory
    {
        private static readonly Random random = new Random();
        public static IWeapon CreateWeapon(string weaponType)
        {
            int damage = random.Next(8, 14);

            switch (weaponType.ToLower())
            {
                case "sword":
                    return new Sword(damage);
                case "axe":
                    return new Axe(damage);
                default:
                    throw new ArgumentException("Invalid weapon type specified.");
            }
        }
    }
}
