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
    public class Ship
    {
        public int HorizontalCoordinateStartCell { get; private set; }
        public int VerticalCoordinateStartCell { get; private set; }
        public Direction Direction { get; private set; }
        public int Length { get; private set; }
        public SihpType ShipType { get; }
        public bool IsDefeted { get; private set; }
        public bool[] Cells
        {
            get { return Cells; }
            set
            {
                if (this.Cells.Count(x => x) == Cells.Length) { this.IsDefeted = true; } else { this.IsDefeted = false; }
            }
        }

        public Ship() : this(Direction.Horizontal, 0)
        {
        }

        public Ship(Direction shipDirection, int shipLength)
        {
     
            this.Direction = shipDirection;
            switch (shipLength)
            {
                case 4:
                    this.ShipType = SihpType.Four;
                    break;
                case 3:
                    this.ShipType = SihpType.Three;
                    break;
                case 2:
                    this.ShipType = SihpType.Two;
                    break;
                case 1:
                    this.ShipType = SihpType.One;
                    break;
                default:
                    this.ShipType = SihpType.Empty;
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
