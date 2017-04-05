using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonsOfDoom
{
    class Weapon : Item
    {
        public Weapon(string name, char icon, int weight, int power) : base(name, icon, weight, power)
        {

        }

        //TODO skapa metod för WeaponDurability
        static public void WeaponDurability(Player player)
        {
            foreach (Item item in player.Inventory)
            {
                if (item is Weapon && item.Power > 0)
                {
                    
                }
            }
        }
    }
}
