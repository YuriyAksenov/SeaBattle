using SeaBattle.Model.Ship;
using System.Text;

namespace SeaBattle.Model.Field
{
    /// <summary>
    /// Provides the instance of base field class with IHomrField interface.
    /// </summary>
    public partial class BaseField : IHomeField
    {

        /// <summary>
        /// Gets a value indicating whether setting the ship in cell is possible.
        /// </summary>
        /// <param name="baseShip"></param>
        /// <param name="horizontalSettedCell"></param>
        /// <param name="verticalSettedCell"></param>
        /// <returns>bool</returns>
        public bool IsPossibleToSetShip(BaseShip baseShip)
        {
            int horizontalSettedCell = baseShip.HorizontalCoordinateStartCell;
            int verticalSettedCell = baseShip.VerticalCoordinateStartCell;


            if ((baseShip.Direction == Direction.Horizontal && (baseShip.Length + horizontalSettedCell) > 10) ||
                (baseShip.Direction == Direction.Vertical && (baseShip.Length + verticalSettedCell) > 10)) return false;


            int requiredNumberOfEmptyCells = baseShip.Length + (baseShip.Length * 2) + 2 + (2 * 2); // The length of the ship and the number of necessary cells around.
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

            int horizontalCheckEmptyCellsLength = (baseShip.Direction == Direction.Horizontal ? baseShip.Length : 1) + 2;
            int verticalCheckEmptyCellsLength = (baseShip.Direction == Direction.Vertical ? baseShip.Length : 1) + 2;


            for (int i = horizontalSettedCell; i < horizontalSettedCell + horizontalCheckEmptyCellsLength; i++)
            {
                for (int j = verticalSettedCell; j < verticalSettedCell + verticalCheckEmptyCellsLength; j++)
                {
                    if (checkedField[i, j]) { countedNumberOfEmptyCellsInCheckedCells++; }
                }
            }
            if (requiredNumberOfEmptyCells == countedNumberOfEmptyCellsInCheckedCells) return true; else return false;

        }

        /// <summary>
        /// Set values to the horizontal and vertical start ship cells. Returns a value indicating whether setting the ship in field is successful.
        /// </summary>
        /// <param name="baseShip"></param>
        /// <param name="settedHorizontalStartCell"></param>
        /// <param name="settedVerticalStartCell"></param>
        /// <returns>bool</returns>
        public bool SetShip(BaseShip baseShip)
        {
            int settedHorizontalStartCell = baseShip.HorizontalCoordinateStartCell;
            int settedVerticalStartCell = baseShip.VerticalCoordinateStartCell;
            if (this.IsPossibleToSetShip(baseShip))
            {
                if (baseShip.Direction == Direction.Horizontal)
                {
                    for (int i = 0; i < baseShip.Length; i++)
                    {
                        this.Cells[settedHorizontalStartCell + i, settedVerticalStartCell].CellType = baseShip.ShipType;
                    }
                }
                if (baseShip.Direction == Direction.Vertical)
                {
                    for (int i = 0; i < baseShip.Length; i++)
                    {
                        this.Cells[settedHorizontalStartCell, settedVerticalStartCell + i].CellType = baseShip.ShipType;
                    }
                }
                //baseShip.SetCoordinatesStartCell(settedHorizontalStartCell, settedVerticalStartCell);
                return true;
            }
            return false;
        }

        /// <summary>
        /// Sets the specified patterned field that is transmitted into method or determined in the method.
        /// </summary>
        /// <param name="patternField"></param>
        public void SetPatternField(int[,] patternField = null)
        {
            if (patternField == null)
            {
                patternField = new int[10, 10]
                {
                    { 2, 2, 0, 3, 0, 0, 4, 4, 4, 4},
                    { 0, 0, 0, 3, 0, 0, 0, 0, 0, 0},
                    { 0, 0, 0, 3, 0, 0, 0, 0, 0, 2},
                    { 0, 5, 0, 0, 0, 0, 0, 0, 0, 2},
                    { 0, 5, 0, 0, 0, 0, 0, 0, 0, 0},
                    { 0, 5, 0, 0, 0, 0, 0, 1, 0, 0},
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                    { 0, 0, 0, 1, 0, 1, 0, 0, 2, 0},
                    { 1, 0, 0, 0, 0, 0, 0, 0, 2, 0},
                };
            }
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    Cells[j, i].IsHitted = false;
                    switch (patternField[i, j])
                    {
                        case 1:
                            Cells[j, i].CellType = ShipType.One;
                            break;
                        case 2:
                            Cells[j, i].CellType = ShipType.Two;
                            break;
                        case 3:
                            Cells[j, i].CellType = ShipType.Three;
                            break;
                        case 4:
                            Cells[j, i].CellType = ShipType.Four;
                            break;
                        default:
                            Cells[j, i].CellType = ShipType.Empty;
                            break;
                    }

                }
            }
        }

        /// <summary>
        /// Returns a string representations as home field view of this field;
        /// </summary>
        /// <returns>string</returns>
        public string PrintHomeField()
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

                    sb.Append(" " + ((Cells[j, i].IsHitted ? "1" : "0") + " |"));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}
