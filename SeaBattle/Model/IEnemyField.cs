using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model
{
    public interface IEnemyField :IBaseField
    {
        bool IsHittedCell(int shootedHorizontalCell, int shootedVerticalCell);
    }
}
