using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model
{
    class HomeField : BaseField, IHomeField
    {
        public HomeField() : base() { }

        /// <summary>
        /// Gets a value indicating whether setting the ship in cell is possible.
        /// </summary>
        /// <param name="ship"></param>
        /// <param name="horizontalSettedCell"></param>
        /// <param name="verticalSettedCell"></param>
        /// <returns>bool</returns>
        public bool IsPossibleToSetShip(Ship ship, int horizontalSettedCell, int verticalSettedCell)
        {
            if ((ship.Direction == Direction.Horizontal && (ship.Length + horizontalSettedCell) > 10) || (ship.Direction == Direction.Vertical && (ship.Length + verticalSettedCell) > 10)) return false;


            int requiredNumberOfEmptyCells = ship.Length + (ship.Length * 2) + 2 + (2 * 2); // The length of the ship and the number of necessary cells around.
            int countedNumberOfEmptyCellsInCheckedCells = 0;

            // Checking the conditions occurs through covering required space (ship surround) and accessed space(empty cells).

            bool[,] checkedField = new bool[12, 12];
            for (int i = 0; i < 12; i++)
            {
                for (int j = 0; j < 12; j++)
                {
                    checkedField[i, j] = true;
                }
            }
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    checkedField[i + 1, j + 1] = Cells[i, j].IsEmpty;
                }
            }

            int horizontalCheckEmptyCellsLength = (ship.Direction == Direction.Horizontal ? ship.Length : 1) + 2;
            int verticalCheckEmptyCellsLength = (ship.Direction == Direction.Vertical ? ship.Length : 1) + 2;


            for (int i = horizontalSettedCell; i < horizontalSettedCell + horizontalCheckEmptyCellsLength; i++)
            {
                for (int j = verticalSettedCell; j < verticalSettedCell + verticalCheckEmptyCellsLength; j++)
                {
                    if (checkedField[i, j]) { countedNumberOfEmptyCellsInCheckedCells++; }
                }
            }
            if (requiredNumberOfEmptyCells == countedNumberOfEmptyCellsInCheckedCells) return true; else return false;

        }

        public override string PrintField()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("    |_А_|_Б_|_В_|_Г_|_Д_|_Е_|_Ж_|_З_|_И_|_К_|");
            sb.AppendLine();

            for (int i = 0; i < 10; i++)
            {
                if ((i + 1) == 10) { sb.Append(" " + (i + 1).ToString() + " |"); }
                else { sb.Append("  " + (i + 1).ToString() + " |"); }

                for (int j = 0; j < 10; j++)
                {
                    sb.Append(" " + ((Cells[j, i].IsEmpty ? "0" : "1") + " |"));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
