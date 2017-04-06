using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectsOfDoom
{
    public class Player : Organism
    {
        //TODO max health? 
        
        public Player(string name, char icon, int health, int attack, int x, int y, int maxWeight) : base(name, icon, health, attack, 0, 0) //Constructor sätter klassens state
        {
            X = x;
            Y = y;
            MaxWeight = maxWeight;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int MaxWeight { get; private set; }


        public static Player CreatePlayer()
        {
            return new Player("Liselotte", 'P', 1000, 5, 0, 0, 50);
        }
                
        public override string Attack(Organism opponent) 
        {
            opponent.Health -= Strength;
            return $"{Name} hit {opponent.Name} for {Strength} hp!\n";
        }

        public override string PickUp(Organism organism)
        {
            //TODO plocka upp inventoryn istället?
            organism.Weight += Weight;
            organism.Inventory.Add(this);
            return ($"Picked up the player named {Name}");
        }

        //TODO UseItem = Eat()? 
    }
}
