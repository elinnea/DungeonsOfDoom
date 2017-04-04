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

            } while (player.Health > 0);

            GameOver();
        }

        private void DisplayStats()
        {
            Console.WriteLine($"Health: {player.Health}");
        }

        private void AskForMovement()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            int newX = player.X;
            int newY = player.Y;
            bool isValidMove = true;

            switch (keyInfo.Key)
            {
                case ConsoleKey.RightArrow: newX++; break;
                case ConsoleKey.LeftArrow: newX--; break;
                case ConsoleKey.UpArrow: newY--; break;
                case ConsoleKey.DownArrow: newY++; break;
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

        private void DisplayWord()
        {
            for (int y = 0; y < world.GetLength(1); y++)
            {
                for (int x = 0; x < world.GetLength(0); x++)
                {
                    Room room = world[x, y];

                    if (player.X == x && player.Y == y)
                    {
                        Console.Write("P");
                    }
                    else if (room.Monster != null)
                    {
                        Console.Write("M");
                    }
                    else if (room.Item != null)
                    {
                        Console.Write("I");
                    }
                    else
                    {
                        Console.Write(".");
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
                            world[x, y].Item = new Item("Sword");
                        }
                    }
                }
            }
        }

        private void CreatePLayer()
        {
            player = new Player(100, 0, 0);
        }
    }
}
