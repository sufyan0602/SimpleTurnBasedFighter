using System;
using System.Threading;

namespace TurnBasedFighter
{
    public class Hero
    {
        public string Name;
        public string Power;

        private int _Health;
        public int Health
        {
            get { return _Health; }
            set { _Health = Math.Max(0, value); }
        }

        public Hero(string name, string power, int health)
        {
            Name = name;

            Power = power;
            Health = health;
        }
        public void Stats()
        {
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine("Hero Stats:");
            Console.WriteLine("Name: " + Name);
            Console.WriteLine("Power: " + Power);
            Console.WriteLine("Health: " + Health);
        }
        public void Attack(Hero target, int damage)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"\n{Name} attacks with {Power} and deals {damage} damage! ");
        }
        public void TakeDamage(int damage)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Health -= damage;
            Console.WriteLine($"\n{Name} has taken {damage} damage and has {Health} health left");
        }

        public bool IsAlive()
        {
            return Health > 0;
        }
    }
    public class Program
    {
        public static void Main(string[] args)
        {
            Random rnd = new Random();
            Hero hero1 = new Hero("Superman", "Flight", 100);
            Hero hero2 = new Hero("Batman", "Intellect", 100);
            Hero hero3 = new Hero("Flash", "Dash", 100);
            Hero hero4 = new Hero("Spiderman", "Web-Shot", 100);

            Hero? playerhero = null;
            Hero? enemyHero = null;

            //Player Chooser
            bool chosen = true;

            while (chosen == true)
            {
                Console.WriteLine("Choose Your Charcter");
                Console.WriteLine($"{hero1.Name} 1.");
                Console.WriteLine($"{hero2.Name} 2.");
                Console.WriteLine($"{hero3.Name} 3.");
                Console.WriteLine($"{hero4.Name} 4.");
                int choice = int.Parse(Console.ReadLine());
                switch (choice)
                {
                    case 1:
                        Console.WriteLine("You are Superman! ");
                        playerhero = hero1;
                        chosen = false;
                        break;
                    case 2:
                        Console.WriteLine("You are batman");
                        playerhero = hero2;
                        chosen = false;
                        break;
                    case 3:
                        Console.WriteLine("You are the flash");
                        playerhero = hero3;
                        chosen = false;
                        break;
                    case 4:
                        Console.WriteLine("You are Spiderman");
                        playerhero = hero4;
                        chosen = false;
                        break;
                    default:
                        Console.WriteLine("You must choose from 1-4");
                        break;
                }
            }

            bool enemyChosen = true;
            while (enemyChosen)
            {
                Console.WriteLine("Choose your oponent");
                if (playerhero != hero1) Console.WriteLine($"{hero1.Name} 1.");
                if (playerhero != hero2) Console.WriteLine($"{hero2.Name} 2.");
                if (playerhero != hero3) Console.WriteLine($"{hero3.Name} 3.");
                if (playerhero != hero4) Console.WriteLine($"{hero4.Name} 4.");

                int enenemyChoice = int.Parse(Console.ReadLine());
                switch (enenemyChoice)
                {
                    case 1:
                        if (playerhero == hero1)
                        {
                            Console.WriteLine("You can't fight yourself. Pick someone else.");
                        }
                        else
                        {
                            enemyHero = hero1;
                            Console.WriteLine("You will fight Superman!");
                            enemyChosen = false;
                        }
                        break;
                    case 2:
                        if (playerhero == hero2)
                        {
                            Console.WriteLine("You can't fight yourself. Pick someone else.");
                        }
                        else
                        {
                            enemyHero = hero2;
                            Console.WriteLine("You will fight Batman!");
                            enemyChosen = false;
                        }
                        break;
                    case 3:
                        if (playerhero == hero3)
                        {
                            Console.WriteLine("You can't fight yourself. Pick someone else.");
                        }
                        else
                        {
                            enemyHero = hero3;
                            Console.WriteLine("You will fight Flash!");
                            enemyChosen = false;
                        }
                        break;
                    case 4:
                        if (playerhero == hero4)
                        {
                            Console.WriteLine("You can't fight yourself. Pick someone else");
                        }
                        else
                        {
                            enemyHero = hero4;
                            Console.WriteLine("You will fight Spiderman!");
                            enemyChosen = false;
                        }
                        break;
                    default:
                        Console.WriteLine("Choose a valid enemy from 1 to 4.");
                        break;
                }
            }
            Console.WriteLine("Battle Start!");
            while (playerhero.IsAlive() && enemyHero.IsAlive())
            {
                int damage = rnd.Next(1, 50);
                playerhero.Attack(enemyHero, damage);
                enemyHero.TakeDamage(damage);
                Thread.Sleep(1000); // Pause after enemy's attack
                if (enemyHero.Health <= 0)
                {
                    Console.WriteLine(enemyHero.Name + " has been defeated!");
                    break;
                }
                int damage2 = rnd.Next(1, 50);
                enemyHero.Attack(playerhero, damage2);
                playerhero.TakeDamage(damage2);
                Thread.Sleep(1000); // Pause after enemy's attack
                if (playerhero.Health <= 0)
                {
                    Console.WriteLine(playerhero.Name + " has been defeated!");
                    break;
                }
            }
            Console.WriteLine(" ");
            playerhero.Stats();
            Console.WriteLine(" ");
            enemyHero.Stats();
            Console.WriteLine("Do you want to play again enter y or press any button to quit! ");

            string again = Console.ReadLine();
            if (again.ToLower() == "y")
            {
                Console.Clear();
                Main(null);
            }
            else
            { 
                Console.WriteLine("Thanks For Playing!");
            }
        }
    }
}