using System;

namespace RPG_GameLogic.Interfaces
{
    internal interface IUnit
    {
        string Name { get; }
        string Description { get; }
        int MaxHealth { get; }
        int CurrentHealth {  get; }
        void Attack(IUnit target, IWeapon weapon, int damage);
        void Move();
        void TakeDamage(int damage);
        void Die();
    }
}
