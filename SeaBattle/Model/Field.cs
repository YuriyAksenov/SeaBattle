using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model
{
    public class Field
    {
        public Cell[,] Cells { get; set; } = new Cell[10, 10];
        public Ship[] Ships { get; set; } = new Ship[0];

        public Field()
        {
           Cells = new Cell[10, 10];
            for (int i = 0; i < Cells.GetLength(1); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i, j] = new Cell();
                    Cells[i, j].IsEmpty = true;
                    Cells[i, j].IsHitted = false;
                }
            }
        }

        public bool IsPossibleToSetShip(Ship ship, int horizontalSettedCell, int verticalSettedCell)
        {
            if ((ship.Direction == Direction.Horizontal && (ship.Length + horizontalSettedCell) > 10) || (ship.Direction == Direction.Vertical && (ship.Length + verticalSettedCell) > 10))return false;
            int requiredNumberOfEmptyCells = ship.Length + (ship.Length * 2) + 2 + (2 * 2); // The length of the ship and the number of necessary cells around.
            int countedNumberOfEmptyCellsInCheckedCells=0;
            

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

            int horizontalCheckEmptyCellsLength = (ship.Direction == Direction.Horizontal ? ship.Length : 1)+2;
            int verticalCheckEmptyCellsLength = (ship.Direction == Direction.Vertical ? ship.Length : 1)+2;
            //Console.WriteLine(horizontalCheckEmptyCellsLength+"  "+verticalCheckEmptyCellsLength);

            for (int i = horizontalSettedCell; i < horizontalSettedCell+horizontalCheckEmptyCellsLength; i++)
            {
                for (int j = verticalSettedCell; j < verticalSettedCell+verticalCheckEmptyCellsLength; j++)
                {
                    if (checkedField[i,j]) { countedNumberOfEmptyCellsInCheckedCells++;  }
                }
                
                
            }
            if (requiredNumberOfEmptyCells == countedNumberOfEmptyCellsInCheckedCells) return true; else return false;

        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sb.Append(((Cells[j,i].IsEmpty ? 0: 1).ToString() + ' '));
                }
                sb.AppendLine();

            }
            return sb.ToString();
        }

    }


    enum FieldCell : byte
    {
        Empty = 0,
        Full = 1,
        Hit = 2,
        Past = 3
    }
}
