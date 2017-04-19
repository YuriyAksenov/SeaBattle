using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model.Ship
{
    /// <summary>
    /// Provides the instance of main unit
    /// </summary>
    public class BaseShip
    {
        public int HorizontalCoordinateStartCell { get; private set; }
        public int VerticalCoordinateStartCell { get; private set; }
        public Direction Direction { get; private set; }
        public int Length { get; private set; }
        public ShipType ShipType { get; }
        public bool IsDefeted { get; private set; }
        public bool[] Cells
        {
            get { return Cells; }
            set
            {
                if (this.Cells.Count(x => x) == Cells.Length) { this.IsDefeted = true; } else { this.IsDefeted = false; }
            }
        }

        public BaseShip() : this(Direction.Horizontal, 0)
        {
        }
        public BaseShip(Direction shipDirection, int shipLength):this(shipDirection,shipLength,0,0)
        {
     
            
        }
        public BaseShip(Direction shipDirection, int shipLength, int horizontalCoordinateStartCell, int verticalCoordinateStartCell)
        {
            this.HorizontalCoordinateStartCell = horizontalCoordinateStartCell;
            this.VerticalCoordinateStartCell = verticalCoordinateStartCell;

            this.Direction = shipDirection;
            switch (shipLength)
            {
                case 4:
                    this.ShipType = ShipType.Four;
                    break;
                case 3:
                    this.ShipType = ShipType.Three;
                    break;
                case 2:
                    this.ShipType = ShipType.Two;
                    break;
                case 1:
                    this.ShipType = ShipType.One;
                    break;
                default:
                    this.ShipType = ShipType.Empty;
                    break;
            }
            this.Length = shipLength;
        }


        public void SetDirection(Direction direction)
        {
            this.Direction = direction;   
        }

        public void SetLength(int length)
        {
            this.Length = length;
        }

        public void SetCoordinatesStartCell(int horizontalCoordinateStartCell, int verticalCoordinateStartCell)
        {
            this.HorizontalCoordinateStartCell = horizontalCoordinateStartCell;
            this.VerticalCoordinateStartCell = verticalCoordinateStartCell;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Length: " + Length.ToString() + '\n');
            sb.Append("Direction: " + Direction.ToString() + '\n');
            return sb.ToString();
        }
    }

    public enum Direction : byte
    {
        Horizontal = 0,
        Vertical = 1
    }
}
