using System;

namespace RPG_GameLogic.Interfaces
{
    internal interface IWeapon
    {
        int Damage { get; }
        void Attack(IUnit attacker, IUnit target, int damage);
    }
}
