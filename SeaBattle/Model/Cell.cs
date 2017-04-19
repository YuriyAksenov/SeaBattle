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

        public bool IsEmpty
        {
            get
            {
                return CellType == SihpType.Empty ? true : false;
            }
        }
        public bool IsHitted { get; set; } = false;
        public SihpType CellType { get; set; } = SihpType.Empty;

        public override string ToString()
        {
            switch (CellType)
            {
                case SihpType.Empty:
                    return "0";
                case SihpType.One:
                    return "1";
                case SihpType.Two:
                    return "2";
                case SihpType.Three:
                    return "3";
                case SihpType.Four:
                    return "4";
                default:
                    return "0";
            }
        }
    }

    public enum SihpType : byte
    {
        Empty = 0,
        One = 1,
        Two = 2,
        Three = 3,
        Four = 4
    }
}
