using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model
{
    public abstract class Enemy
    {
        public bool SetShip(BaseField field, Ship ship)
        {
            int neededEmptyCells = ship.ShipLength + (ship.ShipLength * 2) + 2 + (2 * 2);


        }
    }
}
