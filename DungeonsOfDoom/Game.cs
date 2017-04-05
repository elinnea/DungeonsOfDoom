using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Game
    {
        Player player;
        Room[,] world;
        Random random = new Random(); //Använd samma instans av random för att slippa att alltid få samma slumptal, pga random baseras på tidsstämpel
        string latestEvent;
        int newX = 0, newY = 0, oldX = 0, oldY = 0, oldPlayerX = 0;

        public void Play()
        {
            player = Player.CreatePlayer();
            CreateWorld();
            Console.Clear();
            DisplayWorld();

            do
            {
                AskForMovement();
                DisplayStats();
                //CheckRoom();

            } while (player.Health > 0);

            GameOver();
        }

        private void CheckRoom()
        {
            Room tempRoom = world[player.X, player.Y];
            if (tempRoom.Monster != null)
            {
                Monster monster = tempRoom.Monster;
                latestEvent = "";
                Battle(monster);
                if (monster.Inventory.Count > 0)
                {
                    Item it = monster.Inventory.First();
                    latestEvent += $"\nThe monster dropped something... \nYou found: {it.Name}! Wohoo!"; // Inte så dry om flera items...
                    if (player.Weight + it.Weight <= player.MaxWeight)
                    {
                        player.Inventory.Add(it);
                        player.Weight += it.Weight;
                        latestEvent += $"\nYou picked the {it.Name}.";
                    }
                    else
                    {
                        latestEvent += $"\nYour inventory is full and you couldn't pick up the {it.Name}.";
                        tempRoom.Item = it;
                    }
                }
                tempRoom.Monster = null;


            }
            if (tempRoom.Item != null && (player.Weight + tempRoom.Item.Weight) <= player.MaxWeight)
            {
                player.Inventory.Add(tempRoom.Item);
                if (tempRoom.Item is Weapon)
                {
                    player.Strength += tempRoom.Item.Power;
                }
                player.Weight += tempRoom.Item.Weight;
                latestEvent = $"Item picked up: {tempRoom.Item.Name}\nItem power: {tempRoom.Item.Power}";
                tempRoom.Item = null;
            }
        }

        private void Battle(Monster monster)
        {
            int playerHealth = player.Health, monsterHealth = monster.Health;
            do
            {
                if (random.Next(0, 10) % 2 == 0)
                {
                    //player.Health -= monster.Strength;
                    latestEvent += monster.Attack(player);
                    if (player.IsAlive)
                    {
                        //monster.Health -= player.Strength;
                        latestEvent += player.Attack(monster);
                    }
                }
                else
                {
                    //monster.Health -= player.Strength;
                    latestEvent += player.Attack(monster);
                    if (monster.IsAlive)
                    {
                        //player.Health -= monster.Strength;
                        latestEvent += monster.Attack(player);

                    }
                }

            } while (monster.IsAlive && player.IsAlive);
            if (player.IsAlive)
            {
                latestEvent += $"\nYou beat the monster! You suffered {playerHealth - player.Health} damage and dealt {monsterHealth - monster.Health} in return!";
            }

        }

        private void UpdateWorld(ConsoleKeyInfo keyInfo)
        {
            int x = player.X;
            int y = player.Y;

            newX = x == 0 ? 0 : 0 + x * 3;
            newY = y;

            //Update new position
            Console.SetCursorPosition(newX, newY);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.Write(" P ");

            //Update old position
            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow:
                    oldX = x == 1 ? 0 : (0 + (x - 1) * 3);
                    oldPlayerX = x - 1;
                    oldY = y;
                    break;
                case ConsoleKey.LeftArrow:
                    oldX = 0 + (x + 1) * 3;
                    oldPlayerX = x + 1;
                    oldY = y;
                    break;
                case ConsoleKey.UpArrow:
                    oldY = y + 1;
                    oldX = newX;
                    oldPlayerX = x;
                    break;
                case ConsoleKey.DownArrow:
                    oldY = y - 1;
                    oldX = newX;
                    oldPlayerX = x;
                    break;
            }
            string tmp = "";
            if (world[oldPlayerX, oldY].Monster != null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                tmp = " M ";
            }
            else if (world[oldPlayerX, oldY].Item != null)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                tmp = " ? ";
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.White;
                tmp = " . ";
            }
            Console.SetCursorPosition(oldX, oldY);
            Console.Write(tmp);
        }

        private void ClearLog()
        {
            for (int i = 11; i < 26; i++)
            {
                Console.SetCursorPosition(0, i);
                Console.WriteLine("                                                                                                                                 ");
            }
        }

        private void DisplayStats()
        {
            ClearLog();
            Console.SetCursorPosition(0, 11);
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine($"{player.Name}: Health: {player.Health} Attack: {player.Strength}\nWeight/Max weight : {player.Weight}/{player.MaxWeight}");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(latestEvent);
        }

        private void AskForMovement()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey(true);
            int newX = player.X;
            int newY = player.Y;
            bool isValidMove = true;

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
                case ConsoleKey.Spacebar: Eat(); isValidMove = false; break;
                case ConsoleKey.I: ShowInventory(); isValidMove = false; break;
                default: isValidMove = false; break;
            }
            if (isValidMove &&
                newX >= 0 && newX < world.GetLength(0) &&
                newY >= 0 && newY < world.GetLength(1))
            {
                player.X = newX;
                player.Y = newY;

                player.Health--;
                CheckRoom();
                UpdateWorld(keyInfo);
            }
        }

        private void ShowInventory()
        {
            Console.Clear();
            int ind = 0;
            foreach (var item in player.Inventory)
            {
                Console.WriteLine($"{ind++}: {item.ToString()}");
            }
            Console.ReadKey(true);
            Console.Clear();
            DisplayWorld();
        }

        private void Eat()
        {
            foreach (Item item in player.Inventory)
            {
                if (item is Consumable)
                {
                    player.Health += item.Power;
                    player.Inventory.Remove(item);
                    player.Weight -= item.Weight;
                    break;
                }

            }
        }

        private void DisplayWorld()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];

                    if (player.X == x && player.Y == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write($" {player.Icon} ");
                    }
                    else if (room.Monster != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write($" {room.Monster.Icon} ");
                    }
                    else if (room.Item != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write($" {room.Item.Icon} ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" . ");
                    }
                }
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
            }

        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.WriteLine("Play again? Y/N");
           

            while (true)
            {
                ConsoleKeyInfo input = Console.ReadKey(true);

                if (input.Key == ConsoleKey.Y)
                {
                    Play();
                }
                else if (input.Key == ConsoleKey.N)
                {
                    Environment.Exit(0);
                }
            }

        }

        private void CreateWorld()
        {
            world = new Room[30, 10];

            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    world[x, y] = new Room();

                    if (player.X != x || player.Y != y)
                    {

                        if (random.Next(0, 100) < 10)
                        {
                            world[x, y].Monster = Monster.GenerateMonster();
                        }

                        if (random.Next(0, 100) < 10)
                        {
                            if (world[x, y].Monster != null)
                            {
                                world[x, y].Monster.Inventory.Add(Item.GenerateItem());
                            }
                            else
                            {
                                world[x, y].Item = Item.GenerateItem();
                            }
                        }
                    }
                }
            }
        }

    }
}
