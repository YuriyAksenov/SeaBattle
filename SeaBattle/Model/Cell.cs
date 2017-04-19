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
                return CellType == ShipType.Empty ? true : false;
            }
        }
        public bool IsHitted { get; set; } = false;
        public ShipType CellType { get; set; } = ShipType.Empty;

        public override string ToString()
        {
            switch (CellType)
            {
                case ShipType.Empty:
                    return "0";
                case ShipType.One:
                    return "1";
                case ShipType.Two:
                    return "2";
                case ShipType.Three:
                    return "3";
                case ShipType.Four:
                    return "4";
                default:
                    return "0";
            }
        }
    }

    
}
