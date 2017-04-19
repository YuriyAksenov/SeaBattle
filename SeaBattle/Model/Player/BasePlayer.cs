using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle.Model.Field;
using SeaBattle.Model.Ship;

namespace SeaBattle.Model.Player
{
    public class BasePlayer 
    {
        public IHomeField HomeField { get; }
        public IEnemyField EnemyField { get; private set; }
        public List<BaseShip> ships { get; set; } 

        public BasePlayer()
        {
            HomeField = new HomeField();
            ships = new List<BaseShip>();
        }

        public void SetEnemyField(BaseField enemyField)
        {
            this.EnemyField = enemyField as EnemyField;
            if (EnemyField != null)
            {
                throw new Exception("Неправльное приведение типов");
            }
               
        }

        

        /// <summary>
        /// Shoot the cell. Returns a value indicating whether setting the ship in field is successful.
        /// </summary>
        /// <param name="shootedHorizontalCell"></param>
        /// <param name="shootedVerticalCell"></param>
        /// <returns>bool</returns>
        public bool ShootCell(int shootedHorizontalCell, int shootedVerticalCell)
        {
            if(EnemyField == null)
            {
                throw new Exception("Enemy is not setted");
            }
            if (!EnemyField.Cells[shootedHorizontalCell, shootedVerticalCell].IsEmpty && !EnemyField.Cells[shootedHorizontalCell, shootedVerticalCell].IsHitted)
            {
                EnemyField.Cells[shootedHorizontalCell, shootedVerticalCell].IsHitted = true;
                return true;
            }
            return false;
        }
    }
}
