using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model
{
    public abstract class BaseField : IBaseField
    {
        public Cell[,] Cells { get; set; }

        public BaseField()
        {
            Cells = new Cell[10, 10];
            for (int i = 0; i < Cells.GetLength(1); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    Cells[i, j] = new Cell();
                    Cells[i, j].CellType = SihpType.Empty;
                    Cells[i, j].IsHitted = false;
                }
            }
        }

        public abstract string PrintField();

        public override string ToString()
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


    enum FieldCell : byte
    {
        Empty = 0,
        Full = 1,
        Hit = 2,
        Past = 3
    }
}
