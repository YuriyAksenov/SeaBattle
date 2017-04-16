using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model
{
    public class Field
    {
        public Cell[,] Cells { get; set; }

    }


    enum FieldCell : byte
    {
        Empty = 0,
        Full = 1,
        Hit = 2,
        Past = 3
    }
}
