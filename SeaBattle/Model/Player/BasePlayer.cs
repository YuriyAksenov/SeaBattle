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
        public IHomeField HomeField { get; private set; }
        public IEnemyField EnemyField { get; set; }
        public List<BaseShip> Ships { get; set; }

        public BasePlayer()
        {
            HomeField = new HomeField();
            Ships = new List<BaseShip>();
        }

        public void SetEnemyField(BaseField enemyField)
        {
            this.EnemyField = enemyField as EnemyField;
            if (EnemyField == null)
            {
                throw new Exception("Неправильное приведение типов");
            }
        }

        public void SetHomeField(BaseField homeField)
        {
            this.HomeField = homeField as HomeField;
        }

        public bool IsAllShipsHitted()
        {
            return Ships.Any(x => !x.IsDefeted);
        }

        /// <summary>
        /// Shoot the cell. Returns a value indicating whether setting the ship in field is successful.
        /// </summary>
        /// <param name="shootedHorizontalCell"></param>
        /// <param name="shootedVerticalCell"></param>
        /// <returns>bool</returns>
        public bool ShootCell(int shootedHorizontalCell, int shootedVerticalCell)
        {
            if (EnemyField == null)
            {
                throw new Exception("Enemy is not setted");
            }
            if (!EnemyField.Cells[shootedHorizontalCell, shootedVerticalCell].IsEmpty && !EnemyField.Cells[shootedHorizontalCell, shootedVerticalCell].IsHitted)
            {
                EnemyField.Cells[shootedHorizontalCell, shootedVerticalCell].IsHitted = true;
                MarkDamagedUnitShip(shootedHorizontalCell,shootedVerticalCell);
                return true;
            }
            return false;
        }

        private void MarkDamagedUnitShip(int shootedHorizontalCell, int shootedVerticalCell)
        {
            for (int i = 0; i < Ships.Count; i++)
            {
                if (Ships[i].ShipType == EnemyField.Cells[shootedHorizontalCell, shootedVerticalCell].CellType)
                {
                    if (Ships[i].Direction == Direction.Horizontal)
                    {
                        if((shootedHorizontalCell >= Ships[i].HorizontalCoordinateStartCell) && (shootedHorizontalCell <= (Ships[i].HorizontalCoordinateStartCell + Ships[i].Length)))
                        {
                            Ships[i].CountDefetedUnits++;
                        }
                    }
                    if (Ships[i].Direction == Direction.Horizontal)
                    {
                        if ((shootedVerticalCell >= Ships[i].VerticalCoordinateStartCell) && (shootedVerticalCell <= (Ships[i].VerticalCoordinateStartCell + Ships[i].Length)))
                        {
                            Ships[i].CountDefetedUnits++;
                        }
                    }
                }
            }
        }
    }
}
