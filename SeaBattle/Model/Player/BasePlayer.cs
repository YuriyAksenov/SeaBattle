using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model
{
    public class BasePlayer 
    {
        public IHomeField HomeField { get; }
        public IEnemyField EnemyField { get; private set; }
        public List<Ship> ships { get; set; } 

        public BasePlayer()
        {
            HomeField = new HomeField();
            ships = new List<Ship>();
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
        /// Set values to the horizontal and vertical start ship cells. Returns a value indicating whether setting the ship in field is successful.
        /// </summary>
        /// <param name="ship"></param>
        /// <param name="settedHorizontalStartCell"></param>
        /// <param name="settedVerticalStartCell"></param>
        /// <returns>bool</returns>
        public bool SetShip(Ship ship, int settedHorizontalStartCell, int settedVerticalStartCell)
        {
            if (HomeField.IsPossibleToSetShip(ship, settedHorizontalStartCell, settedVerticalStartCell))
            {
                if(ship.Direction == Direction.Horizontal)
                {
                    for (int i = 0; i < ship.Length; i++)
                    {
                        HomeField.Cells[settedHorizontalStartCell + i, settedVerticalStartCell].CellType = ship.ShipType;
                    }
                }
                if (ship.Direction == Direction.Vertical)
                {
                    for (int i = 0; i < ship.Length; i++)
                    {
                        HomeField.Cells[settedHorizontalStartCell, settedVerticalStartCell+i].CellType = ship.ShipType;
                    }
                }
                ship.SetCoordinatesStartCell(settedHorizontalStartCell, settedVerticalStartCell);
                return true;
            }
            return false;
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
