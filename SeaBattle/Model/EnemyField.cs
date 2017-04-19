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

        public override string PrintField()
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
                    if(Cells[j, i].IsEmpty)
                    {
                        sb.Append(" " + ((Cells[j, i].IsHitted ? "0" : "○") + " |"));
                    }
                    if (!Cells[j, i].IsEmpty)
                    {
                        sb.Append(" " + ((Cells[j, i].IsHitted ? "X" : "○") + " |"));
                    }

                }
                sb.AppendLine();
            }
            return sb.ToString();
        }
    }
}

