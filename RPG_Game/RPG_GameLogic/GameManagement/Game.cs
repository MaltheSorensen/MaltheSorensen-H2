using RPG_GameLogic.Factories;
using RPG_GameLogic.Interfaces;
using RPG_GameLogic.Units;
using System.Threading.Tasks;
using System;
using System.Threading;

namespace RPG_GameLogic.GameManagement
{
    public class Game
    {
        private static readonly Random random = new Random();

        private void HandleAttack(IUnit attacker, IUnit target, IWeapon weapon)
        {
            int damage = random.Next(8, 14);
            attacker.Attack(target, weapon, damage);
        }

        public async Task Start()
        {
            IWeapon enemyWeapon;
            int enemyChoice = random.Next(1, 3);
            if (enemyChoice == 1)
            {
                enemyWeapon = WeaponFactory.CreateWeapon("sword");
                Console.WriteLine("Enemy has chosen Sword.");
            }
            else
            {
                enemyWeapon = WeaponFactory.CreateWeapon("axe");
                Console.WriteLine("Enemy has chosen Axe.");
            }

            Console.WriteLine("Pick your weapon of choice, press 1 for Sword or press 2 for Axe:");
            string playerChoice = Console.ReadLine();

            IWeapon playerWeapon;
            switch (playerChoice)
            {
                case "1":
                    playerWeapon = WeaponFactory.CreateWeapon("sword");
                    Console.WriteLine("You have chosen Sword.");
                    break;

                case "2":
                    playerWeapon = WeaponFactory.CreateWeapon("axe");
                    Console.WriteLine("You have chosen Axe.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Defaulting to Sword.");
                    playerWeapon = WeaponFactory.CreateWeapon("sword");
                    break;
            }

            Player player = new Player("Player", "The main character", 135);

            bool continueFighting = true;
            while (continueFighting)
            {
                Enemy enemy = new Enemy("Enemy", "A fearsome opponent", 80);

                // Start the turn-based combat loop
                while (player.CurrentHealth >= 0 && enemy.CurrentHealth >= 0)
                {
                    Task playerTurnTask = Task.Run(() => HandleAttack(player, enemy, playerWeapon));
                    playerTurnTask.Wait();
                    Thread.Sleep(500);

                    if (enemy.CurrentHealth <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Enemy defeated! You win!");
                        Console.ResetColor();

                        if (random.NextDouble() < 0.70)
                        {
                            int restoredHealth = player.MaxHealth / 2;
                            player.CurrentHealth = Math.Min(player.MaxHealth, player.CurrentHealth + restoredHealth);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine("You found a health potion and restored 50% health :)");
                            Console.ResetColor();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine($"Current health: {player.CurrentHealth}");
                            Console.ResetColor();
                        }
                        else
                        {
                            Console.ForegroundColor= ConsoleColor.Blue;
                            Console.WriteLine("You found a health potion, but it was empty :(");
                            Console.ResetColor();
                        }

                        break;
                    }

                    Task enemyTurnTask = Task.Run(() => HandleAttack(enemy, player, enemyWeapon));
                    enemyTurnTask.Wait();
                    Thread.Sleep(500);

                    if (player.CurrentHealth <= 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Player defeated! Game over.");
                        Console.ResetColor();
                        return;
                    }
                }

                Console.WriteLine("Another opponent appears in the distance! do you wish to challange him? (yes/no)");
                string input = Console.ReadLine();
                if (input.ToLower() != "yes")
                {
                    continueFighting = false;
                }
            }
        }
    }
}
