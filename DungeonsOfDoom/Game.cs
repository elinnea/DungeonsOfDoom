using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Game
    {
        Player player;
        Room[,] world;
        Random random = new Random(); //Använd samma instans av random för att slippa att alltid få samma slumptal, pga random baseras på tidsstämpel

        public void Play()
        {
            CreatePLayer();
            CreateWorld();
            do
            {
                Console.Clear();
                DisplayStats();
                DisplayWord();
                AskForMovement();
                CheckRoom();

            } while (player.Health > 0);

            GameOver();
        }

        private void CheckRoom()
        {
            Room tempRoom = world[player.X, player.Y];
            if (tempRoom.Monster != null)
            {
                Console.WriteLine("Det finns ett monster här!!");
            }
            if (tempRoom.Item != null && (player.Weight + tempRoom.Item.Weight) <= player.MaxWeight)
            {
                player.Inventory.Add(tempRoom.Item);
                player.Weight += tempRoom.Item.Weight;
                tempRoom.Item = null;
            }
        }

        private void DisplayStats()
        {
            Console.WriteLine($"Health: {player.Health}");
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
            }
        }

        private void ShowInventory()
        {
            int weaponCount = 0;
            int foodCount = 0;
            foreach (var item in player.Inventory)
            {
                if (item.Type == "food")
                {
                    foodCount++;
                }
                else
                {
                    weaponCount++;
                }
            }
            Console.WriteLine($"You have {foodCount} apples and {weaponCount} swords! ");
            Console.ReadKey(true);
        }

        private void Eat()
        {
            foreach (Item item in player.Inventory)
            {
                if (item.Type == "food")
                {
                    player.Health += 20;
                    player.Inventory.Remove(item);
                    break;
                }

            }
        }

        private void DisplayWord()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];

                    if (player.X == x && player.Y == y)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        Console.Write(" P ");
                    }
                    else if (room.Monster != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(" M ");
                    }
                    else if (room.Item != null)
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write(" I ");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write(" . ");
                    }

                }
                Console.WriteLine();
            }
        }

        private void GameOver()
        {
            Console.Clear();
            Console.WriteLine("Game over...");
            Console.ReadKey();
            Play();
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
                            world[x, y].Monster = new Monster(30);
                        }

                        if (random.Next(0, 100) < 10)
                        {
                            if (random.Next(0, 10) % 2 == 0)
                            {
                                world[x, y].Item = new Item("Sword", 10, "weapon");
                            }
                            else
                                world[x, y].Item = new Item("Apple", 2, "food");

                        }
                    }
                }
            }
        }

        private void CreatePLayer()
        {
            player = new Player(100, 0, 0, 50);
        }
    }
}
