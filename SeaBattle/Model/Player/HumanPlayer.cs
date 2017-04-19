using SeaBattle.Model;
using SeaBattle.Model.Field;
using SeaBattle.Model.Ship;
using SeaBattle.Share;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UI = SeaBattle.Share.UserInteraction;


namespace SeaBattle.Model.Player
{
    class HumanPlayer : BasePlayer
    {
        public HumanPlayer() : base()
        {
            SetAllShips();

        }


        public void SetAllShips()
        {
            int settedShips = 0;
            UI.Message("Процесс заполнения кораблями поля");
            PrintHomeField(HomeField);

            BaseShip shipFour = new BaseShip();
            UI.Message("Установка четырех палубного");
            UI.Message("Введите направление: 1 - по горизонтали; 2 - по вертикали");
            try
            {
                shipFour.SetLength(UI.Read());
            }
            catch (Exception e)
            {
                UI.ErrorMessage("Ввод был неправелен.", e);
            }

            UI.Message("Введите координату начальной клетке: сначала букву, через пробел цифру");



            UI.Message("Установка четырех палубного");
            UI.Message("Введите направление: 1 - по горизонтали; 2 - по вертикали");

            UI.Message("Введите координату начальной клетке: сначала букву, через пробел цифру");


        }

        private bool SetShip(ShipType shipType)
        {
            try
            {
                Direction shipDirection = Direction.Horizontal;
                string[] startCellLineFromConsole;
                int horizontalCoordinateStartCell = 0;
                int verticalCoordinateStartCell = 0;


                PrintHomeField(HomeField);
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
                UI.Message("Установка четырех палубного");
                UI.Message("Введите направление: 1 - по горизонтали; 2 - по вертикали");

                shipDirection = (UI.Read() == 1 ? Direction.Horizontal : Direction.Vertical); ;
                UI.Message("Введите координату начальной клетке: сначала букву, через пробел цифру");
                startCellLineFromConsole = UI.ReadLine().Trim().Split(' ');
                horizontalCoordinateStartCell = Convert.ToInt32(startCellLineFromConsole.First())-1;

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

                BaseShip shipFour = new BaseShip(shipDirection, 4, horizontalCoordinateStartCell, verticalCoordinateStartCell);
                if (HomeField.IsPossibleToSetShip(shipFour))
                {
                    HomeField.SetShip(shipFour);
                    UI.OKMessage("Корабль установлен!");
                    return true;
                }
                else
                {
                    UI.ImportantMessage("Корабль невозможно установить в эти клетки");
                }

                return false;
            }
            catch (Exception e)
            {
                UI.ErrorMessage("При установке корабля произошла ошибка, придется повторить попытку", e);
            }
            return false;

        }


        public void PrintHomeField(IHomeField homeFiled)
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
                    if (homeFiled.Cells[j, i].IsHitted)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(homeFiled.Cells[j, i].ToString());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else { Console.Write(homeFiled.Cells[j, i].ToString()); }
                    Console.Write(" |");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public void PrintEnemyField(IEnemyField enemyFiled)
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
                    if (enemyFiled.Cells[j, i].IsHitted)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write((enemyFiled.Cells[j, i].IsEmpty) ? "0" : enemyFiled.Cells[j, i].ToString());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else { Console.Write("0"); }
                    Console.Write(" |");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
        }
    }
}
