using System.Text;

namespace SeaBattle.Model.Field
{
    /// <summary>
    /// Provides the instance of base field class with IBaseField interface.
    /// </summary>
    public partial class BaseField : IBaseField
    {
        /// <summary>
        /// Gets and sets the array of the field cells.
        /// </summary>
        public Cell[,] Cells { get; set; }

        /// <summary>
        /// Initialzes the instance of the base field class.
        /// </summary>
        public BaseField()
        {
            Cells = new Cell[10, 10];
            for (int i = 0; i < Cells.GetLength(1); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i, j] = new Cell();
                    Cells[i, j].CellType = ShipType.Empty;
                    Cells[i, j].IsHitted = false;
                }
            }
        }

        /// <summary>
        /// Clears the cells of the instance field. Makes them empty type and unhitted.
        /// </summary>
        public void ClearField()
        {
            for (int i = 0; i < Cells.GetLength(1); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i, j].CellType = ShipType.Empty;
                    Cells[i, j].IsHitted = false;
                }
            }
        }

        /// <summary>
        /// Returns a string representations in base way view of this field.
        /// </summary>
        /// <returns>string</returns>
        public string PrintField()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    sb.Append(((Cells[j, i].IsEmpty ? 0 : 1).ToString() + ' '));
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}
