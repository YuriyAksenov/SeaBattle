using SeaBattle.Model;
using SeaBattle.Model.Field;
using SeaBattle.Model.Game;
using SeaBattle.Model.Player;
using SeaBattle.Model.Ship;
using System;
using System.Linq;


using UI = SeaBattle.Share.UserInteraction;


namespace SeaBattle.Game
{
    /// <summary>
    /// Provides the instance of the human player class.
    /// </summary>
    class HumanPlayer : BasePlayer
    {
        /// <summary>
        /// Initializes the instance of the human player class.
        /// </summary>
        public HumanPlayer() : base() { }

        /// <summary>
        /// Sets all ships on the field.
        /// </summary>
        public void SetAllShips()
        {
            UI.ImportantMessage("Начался процесс утсановки кораблей!");
            UI.Message("Заполнить поле автоматически, вручную или шаблоном? А - 'Автоматически'; Р  - 'Вручную'; Ш - 'Шаблон'");
            string filled = "Ш";
            filled = UI.ReadLine();
            if(String.IsNullOrEmpty(filled)) filled = "Ш";

            if (filled.Trim().First().ToString() == "А")
            {
                AIPlayer aiplayer = new AIPlayer();
                aiplayer.SetHomeField((BaseField)HomeField);
                aiplayer.SetAllShips();

                UI.OKMessage("Корабли утсановлены атвоматически!");
                return;
            }
            if (filled.Trim().First().ToString() == "Ш")
            {
                HomeField.SetPatternField();
                UI.OKMessage("Корабли утсановлены шаблоном!");
                return;
            }

            UI.OKMessage("Корабли утсанавливаются вручную!");

            PrintHomeField();
            bool isSettedShipFour = false;
            while (!isSettedShipFour) { isSettedShipFour=SetShip(ShipType.Four); }
            PrintHomeField();

            bool isSettedShipThree = false;
            while (!isSettedShipThree) { isSettedShipThree = SetShip(ShipType.Three); }
            PrintHomeField();
            isSettedShipThree = false;
            while (!isSettedShipThree) { isSettedShipThree = SetShip(ShipType.Three); }
            PrintHomeField();

            bool isSettedShipTwo = false;
            while (!isSettedShipTwo) { isSettedShipTwo = SetShip(ShipType.Two); }
            PrintHomeField();
            isSettedShipTwo = false;
            while (!isSettedShipTwo) { isSettedShipTwo = SetShip(ShipType.Two); }
            PrintHomeField();
            isSettedShipTwo = false;
            while (!isSettedShipTwo) { isSettedShipTwo = SetShip(ShipType.Two); }
            PrintHomeField();

            bool isSettedShipOne = false;
            while (!isSettedShipOne) { isSettedShipOne = SetShip(ShipType.One); }
            PrintHomeField();
            isSettedShipOne = false;
            while (!isSettedShipOne) { isSettedShipOne = SetShip(ShipType.One); }
            PrintHomeField();
            isSettedShipOne = false;
            while (!isSettedShipOne) { isSettedShipOne = SetShip(ShipType.One); }
            PrintHomeField();
            isSettedShipOne = false;
            while (!isSettedShipOne) { isSettedShipOne = SetShip(ShipType.One); }
            PrintHomeField();

        }

        /// <summary>
        /// Returns a value of indicating whether the AI set the ship.
        /// </summary>
        /// <param name="shipType"></param>
        /// <returns>bool</returns>
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
                        UI.Message("Установка одно-палубного");
                        shipLength = 1;
                        break;
                    case ShipType.Two:
                        UI.Message("Установка двух-палубного");
                        shipLength = 2;
                        break;
                    case ShipType.Three:
                        UI.Message("Установка трех-палубного");
                        shipLength = 3;
                        break;
                    case ShipType.Four:
                        UI.Message("Установка четырех-палубного");
                        shipLength = 4;
                        break;
                }

                UI.Message("Введите направление: 1 - по горизонтали; 2 - по вертикали");
                shipDirection = ((Convert.ToInt32(UI.ReadLine().First().ToString()) == 1) ? Direction.Horizontal : Direction.Vertical);

                UI.Message("Введите координату начальной клетке: сначала букву, через пробел цифру '1 A'");
                string[] startCellLineFromConsole = UI.ReadLine().Trim().Split(' ');
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

                BaseShip baseShip = new BaseShip(shipDirection, shipLength, verticalCoordinateStartCell, horizontalCoordinateStartCell);
                if (HomeField.IsPossibleToSetShip(baseShip))
                {
                    HomeField.SetShip(baseShip);

                    Ships.Add(baseShip);

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

        /// <summary>
        /// Prints a field in a home way view of the player.
        /// </summary>
        public void PrintHomeField()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("    |_А_|_Б_|_В_|_Г_|_Д_|_Е_|_Ж_|_З_|_И_|_К_|");
            Console.ForegroundColor = ConsoleColor.Gray;

            for (int i = 0; i < 10; i++)
            {
                Console.ForegroundColor = ConsoleColor.White;
                if ((i + 1) == 10) { Console.Write(" " + (i + 1).ToString() + " |"); }
                else { Console.Write("  " + (i + 1).ToString() + " |"); }
                Console.ForegroundColor = ConsoleColor.Gray;
                for (int j = 0; j < 10; j++)
                {

                    Console.Write(" ");
                    if (HomeField.Cells[j, i].IsHitted)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(HomeField.Cells[j, i].ToString());
                        Console.ForegroundColor = ConsoleColor.Gray;
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
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    Console.Write(" |");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

    }
}
