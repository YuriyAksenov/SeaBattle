using System;
using System.Collections.Generic;
using System.Linq;
using SeaBattle.Model.Field;
using SeaBattle.Model.Ship;

namespace SeaBattle.Model.Player
{
    /// <summary>
    /// Provides the instance of Base Player class.
    /// </summary>
    public class BasePlayer
    {
        /// <summary>
        /// Gets the instance if the home field of this player.
        /// </summary>
        public IHomeField HomeField { get; private set; }

        /// <summary>
        /// Gets the instance if the enemy field of this player.
        /// </summary>
        public IEnemyField EnemyField { get; private set; }

        /// <summary>
        /// Gets and Sets the list of the ships of this player.
        /// </summary>
        public List<BaseShip> Ships { get; set; }

        /// <summary>
        /// Initializes the instance of base player class.
        /// </summary>
        public BasePlayer()
        {
            HomeField = new BaseField();
            Ships = new List<BaseShip>();
        }

        /// <summary>
        /// Sets the Enemy Field, which needed for working of some methods.
        /// </summary>
        /// <param name="enemyField"></param>
        public void SetEnemyField(IBaseField enemyField)
        {
            this.EnemyField = (IEnemyField)enemyField;
        }

        /// <summary>
        /// Sets the Home field.
        /// </summary>
        /// <param name="homeField"></param>
        public void SetHomeField(IBaseField homeField)
        {
            this.HomeField = (IHomeField)homeField;
        }

        /// <summary>
        /// Returns a value of indicating wheter all ships are hitted.
        /// </summary>
        /// <returns>bool</returns>
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

        /// <summary>
        /// Mark the damaged unit of determined ships. 
        /// </summary>
        /// <param name="shootedHorizontalCell"></param>
        /// <param name="shootedVerticalCell"></param>
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
