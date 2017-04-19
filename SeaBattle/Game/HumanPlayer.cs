using SeaBattle.Model;
using SeaBattle.Model.Field;
using SeaBattle.Model.Player;
using SeaBattle.Model.Ship;
using SeaBattle.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI = SeaBattle.Share.UserInteraction;


namespace SeaBattle.Game
{
    class HumanPlayer : BasePlayer
    {
        public HumanPlayer() : base() {      }

        public void SetAllShips()
        {
            SetShip(ShipType.Four);
        }

        private bool SetShip(ShipType shipType)
        {
            try
            {
                Direction shipDirection = Direction.Horizontal;
                string[] startCellLineFromConsole;
                int horizontalCoordinateStartCell = 0;
                int verticalCoordinateStartCell = 0;

                switch (shipType)
                {

                    case ShipType.One:
                        UI.Message("Установка одно-палубного");
                        break;
                    case ShipType.Two:
                        UI.Message("Установка двух-палубного");
                        break;
                    case ShipType.Three:
                        UI.Message("Установка трех-палубного");
                        break;
                    case ShipType.Four:
                        UI.Message("Установка четырех-палубного");
                        break;
                }

                UI.Message("Введите направление: 1 - по горизонтали; 2 - по вертикали");
                shipDirection = ((Convert.ToInt32(UI.ReadLine().First().ToString()) == 1) ? Direction.Horizontal : Direction.Vertical);

                UI.Message("Введите координату начальной клетке: сначала букву, через пробел цифру");
                startCellLineFromConsole = UI.ReadLine().Trim().Split(' ');
                horizontalCoordinateStartCell = (Convert.ToInt32(startCellLineFromConsole.First().ToString()) - 1);

                switch (startCellLineFromConsole.Last()[0])
                {
                    case 'А': verticalCoordinateStartCell = 0; break;
                    case 'Б': verticalCoordinateStartCell = 1; break;
                    case 'В': verticalCoordinateStartCell = 2; break;
                    case 'Г': verticalCoordinateStartCell = 3; break;
                    case 'Д': verticalCoordinateStartCell = 4; break;
                    case 'Е': verticalCoordinateStartCell = 5; break;
                    case 'Ж': verticalCoordinateStartCell = 6; break;
                    case 'З': verticalCoordinateStartCell = 7; break;
                    case 'И': verticalCoordinateStartCell = 8; break;
                    case 'К': verticalCoordinateStartCell = 9; break;
                    default:
                        break;
                }

                BaseShip baseShip = new BaseShip(shipDirection, 4, verticalCoordinateStartCell, horizontalCoordinateStartCell);
                if (HomeField.IsPossibleToSetShip(baseShip))
                {
                    HomeField.SetShip(baseShip);

                    switch (shipType)
                    {
                        case ShipType.One:
                            UI.Message("Однопалубный корабль установлен!");
                            break;
                        case ShipType.Two:
                            UI.Message("Двупалубный корабль установлен!");
                            break;
                        case ShipType.Three:
                            UI.Message("Трех-палубный корабль установлен!");
                            break;
                        case ShipType.Four:
                            UI.Message("Четырех-палубный корабль установлен!");
                            break;
                    }
                    return true;
                }
                else
                {
                    UI.ErrorMessage("Корабль невозможно установить в эти клетки", new Exception());
                }
                return false;
            }
            catch (Exception e)
            {
                UI.ErrorMessage("При установке корабля произошла ошибка, придется повторить попытку", e);
            }
            return false;
        }

        //public void PrintHomeField()
        //{
        //    Console.ForegroundColor = ConsoleColor.White;
        //    Console.WriteLine("    |_А_|_Б_|_В_|_Г_|_Д_|_Е_|_Ж_|_З_|_И_|_К_|");

        //    for (int i = 0; i < 10; i++)
        //    {
        //        if ((i + 1) == 10) { Console.Write(" " + (i + 1).ToString() + " |"); }
        //        else { Console.Write("  " + (i + 1).ToString() + " |"); }

        //        for (int j = 0; j < 10; j++)
        //        {

        //            Console.Write(" ");
        //            if (HomeField.Cells[j, i].IsHitted)
        //            {
        //                Console.ForegroundColor = ConsoleColor.Red;
        //                Console.Write(HomeField.Cells[j, i].ToString());
        //                Console.ForegroundColor = ConsoleColor.White;
        //            }
        //            else { Console.Write(HomeField.Cells[j, i].ToString()); }
        //            Console.Write(" |");
        //        }
        //        Console.WriteLine();
        //    }
        //    Console.ForegroundColor = ConsoleColor.Cyan;
        //}

    }
}
