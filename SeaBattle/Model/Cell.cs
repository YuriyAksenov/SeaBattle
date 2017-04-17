using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model
{
    public class Cell
    {
        public Cell() { }
 
        public bool IsEmpty { get; set;  } = true;
        public bool IsHitted { get; set; } = false;
    }

    enum CellStatus : byte
    {
        Empty = 0,
        Full = 1,
        Hit = 2,
        Past = 3
    }
}
