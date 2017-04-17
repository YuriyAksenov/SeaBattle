using SeaBattle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle
{
    class StartUp
    {
        static void Main(string[] args)
        {
            Player player = new Player();
            player.ship = new Ship(Direction.Horizontal, 2);
            Console.WriteLine(player.ship.ToString());
            player.SetShip(player.ship, 6, 6);
            Console.Write(player.OwnField.ToString());

            Console.WriteLine("---------------------------------");

            player.ship = new Ship(Direction.Horizontal, 7);
            Console.WriteLine(player.ship.ToString());
            player.SetShip(player.ship, 0, 0);
            Console.Write(player.OwnField.ToString());

            Console.WriteLine("---------------------------------");

            player.ship = new Ship(Direction.Horizontal, 6);
            Console.WriteLine(player.ship.ToString());
            player.SetShip(player.ship, 5, 5);
            Console.Write(player.OwnField.ToString());

            Console.WriteLine("---------------------------------");

            player.ship = new Ship(Direction.Horizontal, 5);
            Console.WriteLine(player.ship.ToString());
            player.SetShip(player.ship, 9, 9);

            Console.WriteLine("---------------------------------");

            player.ship = new Ship(Direction.Horizontal, 1);
            Console.WriteLine(player.ship.ToString());
            player.SetShip(player.ship, 9, 9);

            Console.Write(player.OwnField.ToString());
        }
    }
}
