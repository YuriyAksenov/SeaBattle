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
        public Direction Direction { get; }
        public int Length { get; }
        public bool IsDefeted { get; private set; }
        public bool[] Cells
        {
            get { return Cells; }
            set
            {
                if (this.Cells.Count(x => x) == Cells.Length) { this.IsDefeted = true; } else { this.IsDefeted = false; }
            }
        }

        public Ship( Direction shipDirection, int shipLength)
        {
            //this.HorizontalStartCell = horizontalStartCell;
            //this.VerticalStartCell = verticalStartCell;
            this.Direction = shipDirection;
            this.Length = shipLength;
        }

        public void SetCoordinatesStartCell(int horizontalCoordinateStartCell, int verticalCoordinateStartCell)
        {
            this.HorizontalCoordinateStartCell = horizontalCoordinateStartCell;
            this.VerticalCoordinateStartCell = verticalCoordinateStartCell;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Length: "+Length.ToString() + '\n');
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
