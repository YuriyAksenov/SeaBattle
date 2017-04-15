using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model
{
    /// <summary>
    /// Provides the instance of main unit
    /// </summary>
    public abstract class BaseShip
    {
        public int HorizontalStartCell { get; }
        public int VerticalStartCell { get; }
        public Direction ShipDirection { get; }
        public int ShipLength { get; }
        public bool[] ShipCells { get; set; }

        public BaseShip(int horizontalStartCell, int verticalStartCell, Direction shipDirection, int shipLength)
        {
            this.HorizontalStartCell = horizontalStartCell;
            this.VerticalStartCell = verticalStartCell;
            this.ShipDirection = shipDirection;
            this.ShipLength = shipLength;
        }
    }

    public enum Direction : byte
    {
        Horizontal = 0,
        Vertical = 1
    }

}
