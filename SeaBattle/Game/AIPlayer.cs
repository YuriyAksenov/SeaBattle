using SeaBattle.Model;
using SeaBattle.Model.Player;
using SeaBattle.Model.Ship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Model.Game
{
    public class AIPlayer : BasePlayer
    {
        
        public void SetAllShips()
        {


            int[,] patternField = new int[10,10]
            {
                { 2, 2, 0, 3, 0, 0, 4, 4, 4, 4},
                { 0, 0, 0, 3, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 3, 0, 0, 0, 0, 0, 2},
                { 0, 5, 0, 0, 0, 0, 0, 0, 0, 2},
                { 0, 5, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 5, 0, 0, 0, 0, 0, 1, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0},
                { 0, 0, 0, 1, 0, 1, 0, 0, 2, 0},
                { 1, 0, 0, 0, 0, 0, 0, 0, 2, 0},
            };

            HomeField.SetPatternField(patternField);
            //if(!IsShipSettedAndIterationsNotOverflow(ShipType.Four))
            //{
            //    SetAllShips();
            //    return;
            //}
            //PrintHomeField();
            //for (int i = 0; i < 2; i++)
            //{
            //    if (!IsShipSettedAndIterationsNotOverflow(ShipType.Three))
            //    {
            //        SetAllShips();
            //        return;
            //    }
            //}
            //PrintHomeField();
            //for (int i = 0; i < 3; i++)
            //{
            //    if (!IsShipSettedAndIterationsNotOverflow(ShipType.Two))
            //    {
            //        SetAllShips();
            //        return;
            //    }
            //}
            //PrintHomeField();
            //for (int i = 0; i < 2; i++)
            //{
            //    if (!IsShipSettedAndIterationsNotOverflow(ShipType.Four))
            //    {
            //        SetAllShips();
            //        return;
            //    }
            //}
            //PrintHomeField();

        }

        private bool IsShipSettedAndIterationsNotOverflow(ShipType shipType, int recommendedAmountIterations = 0)
        {
            int maxIterations = 0;
            int standartMaxIterations = 0;
            bool isSettedShip = false;

            switch (shipType)
            {
                case ShipType.One:
                    standartMaxIterations = 200;
                    break;
                case ShipType.Two:
                    standartMaxIterations = 200;
                    break;
                case ShipType.Three:
                    standartMaxIterations = 200;
                    break;
                case ShipType.Four:
                    standartMaxIterations = 200;
                    break;
            }

            switch (shipType)
            {
                case ShipType.One:
                    maxIterations = (recommendedAmountIterations > 50 ? recommendedAmountIterations : standartMaxIterations);
                    while (!isSettedShip)
                    {
                        isSettedShip = SetShip(ShipType.One);
                        if (maxIterations < 0)
                        {
                            HomeField.ClearField();
                            return false;
                        }
                        else maxIterations--;
                    }
                    break;

                case ShipType.Two:
                    maxIterations = (recommendedAmountIterations > 50 ? recommendedAmountIterations : standartMaxIterations);
                    while (!isSettedShip)
                    {
                        isSettedShip = SetShip(ShipType.Two);
                        if (maxIterations < 0)
                        {
                            HomeField.ClearField();
                            return false;
                        }
                        else maxIterations--;
                    }
                    break;

                case ShipType.Three:
                    maxIterations = (recommendedAmountIterations > 50 ? recommendedAmountIterations : standartMaxIterations);
                    while (!isSettedShip)
                    {
                        isSettedShip = SetShip(ShipType.Three);
                        if (maxIterations < 0)
                        {
                            HomeField.ClearField();
                            return false;
                        }
                        else maxIterations--;
                    }
                    break;

                case ShipType.Four:
                    maxIterations = (recommendedAmountIterations > 50 ? recommendedAmountIterations : standartMaxIterations);
                    while (!isSettedShip)
                    {
                        isSettedShip = SetShip(ShipType.Four);
                        if (maxIterations < 0)
                        {
                            HomeField.ClearField();
                            return false;
                        }
                        else maxIterations--;
                    }
                    break; 
            }
            return true;
        }

        private bool SetShip(ShipType shipType)
        {
            try
            {
                Direction shipDirection = Direction.Horizontal;
                int shipLength = 0;
                int horizontalCoordinateStartCell = 0;
                int verticalCoordinateStartCell = 0;

                switch (shipType)
                {

                    case ShipType.One:
                        shipLength = 1;
                        break;
                    case ShipType.Two:
                        shipLength = 2;
                        break;
                    case ShipType.Three:
                        shipLength = 3;
                        break;
                    case ShipType.Four:
                        shipLength = 4;
                        break;
                }
                var t = (new Random().Next(2));
                //Console.WriteLine(t);
                shipDirection = ((t == 1) ? Direction.Horizontal : Direction.Vertical);

                horizontalCoordinateStartCell = new Random().Next(10);
                verticalCoordinateStartCell = new Random().Next(10);

                BaseShip baseShip = new BaseShip(shipDirection, shipLength, verticalCoordinateStartCell, horizontalCoordinateStartCell);
                if (HomeField.IsPossibleToSetShip(baseShip))
                {
                    HomeField.SetShip(baseShip);

                    Ships.Add(baseShip);

                    return true;
                }
                return false;
            }
            catch (Exception e)
            {
            }
            return false;
        }

        public void PrintHomeField()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    |_А_|_Б_|_В_|_Г_|_Д_|_Е_|_Ж_|_З_|_И_|_К_|");

            for (int i = 0; i < 10; i++)
            {
                if ((i + 1) == 10) { Console.Write(" " + (i + 1).ToString() + " |"); }
                else { Console.Write("  " + (i + 1).ToString() + " |"); }

                for (int j = 0; j < 10; j++)
                {

                    Console.Write(" ");
                    if (HomeField.Cells[j, i].IsHitted)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(HomeField.Cells[j, i].ToString());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        if (HomeField.Cells[j, i].ToString() == "0")
                        {
                            Console.Write(HomeField.Cells[j, i].ToString());
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(HomeField.Cells[j, i].ToString());
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
                    Console.Write(" |");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
