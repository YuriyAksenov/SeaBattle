using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model
{
    class Player : IPlayer
    {

        public Field OwnField;
        //Field EnemyField;
        public Ship ship { get; set; }
        public Player()
        {
            
            OwnField = new Field();
            Console.WriteLine("Helo");
        }

        public void SetShip(Ship ship, int settedHorizontalStartCell, int settedVerticalStartCell)
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
            }

            
        }

        public bool ShootCell(int shootedHorizontalCell, int shootedVerticalCell)
        {
            throw new NotImplementedException();
        }
    }
}
