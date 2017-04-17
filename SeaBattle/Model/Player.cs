using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model
{
    class Player 
    {

        public BaseField OwnField;
        //Field EnemyField;
        public Ship ship { get; set; }
        public Player()
        {
            
            OwnField = new BaseField();
            Console.WriteLine("Helo");
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
            if (OwnField.IsPossibleToSetShip(ship, settedHorizontalStartCell, settedVerticalStartCell))
            {
                if(ship.Direction == Direction.Horizontal)
                {
                    for (int i = 0; i < ship.Length; i++)
                    {
                        OwnField.Cells[settedHorizontalStartCell + i, settedVerticalStartCell].IsEmpty = false;
                    }
                }
                if (ship.Direction == Direction.Vertical)
                {
                    for (int i = 0; i < ship.Length; i++)
                    {
                        OwnField.Cells[settedHorizontalStartCell, settedVerticalStartCell+i].IsEmpty = false;
                    }
                }
                ship.SetHorizontalVerticalStartCell(settedHorizontalStartCell, settedVerticalStartCell);
                return true;
            }
            return false;
            
        }

        public bool ShootCell(int shootedHorizontalCell, int shootedVerticalCell)
        {
            
            throw new NotImplementedException();
        }
    }
}
