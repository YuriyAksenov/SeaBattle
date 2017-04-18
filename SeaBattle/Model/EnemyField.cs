using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model
{
    public class EnemyField : BaseField, IEnemyField
    {
        public EnemyField() : base() { }

        /// <summary>
        /// Gets a value indicating whether hitting the cell is successful.
        /// </summary>
        /// <param name="shootedHorizontalCell"></param>
        /// <param name="shootedVerticalCell"></param>
        /// <returns>bool</returns>
        public bool IsHittedCell(int shootedHorizontalCell, int shootedVerticalCell)
        {
            if (!Cells[shootedHorizontalCell, shootedVerticalCell].IsEmpty && !Cells[shootedHorizontalCell, shootedVerticalCell].IsHitted)
            {
                Cells[shootedHorizontalCell, shootedVerticalCell].IsHitted = true;
                return true;
            }
            return false;
        }
    }
}
