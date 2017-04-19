using SeaBattle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace SeaBattle.Game
{
    class HumanPlayer : BasePlayer
    {
        public HumanPlayer():base()
        {
            SetAllShips();
            
        }


        public void SetAllShips()
        {
            int settedShips = 0;
            Console.WriteLine("Процесс заполнения кораблями поля");
            PrintHomeField(HomeField);

            Ship shipFour = new Ship();
            Console.WriteLine("Установка четырех палубного");
            Console.WriteLine("Введите направление: 1 - по горизонтали; 2 - по вертикали");
            try
            {
                shipFour.SetLength(Console.Read());
            }
            catch (Exception e)
            {

                Console.WriteLine("Ввод был неправелен.", e.Message);
            }

            Console.WriteLine("Введите координату начальной клетке: сначала букву, через пробел цифру");



            Console.WriteLine("Установка четырех палубного");
                Console.WriteLine("Введите направление: 1 - по горизонтали; 2 - по вертикали");
            
            Console.WriteLine("Введите координату начальной клетке: сначала букву, через пробел цифру");

            
        }

        private bool SetFourShip()
        {
            try { 
            Direction shipDirection = Direction.Horizontal;
                string startCellLineFromConsole = "";


            PrintHomeField(HomeField);
            Console.WriteLine("Установка четырех палубного");
            Console.WriteLine("Введите направление: 1 - по горизонтали; 2 - по вертикали");

            shipDirection = (Console.Read() == 1 ? Direction.Horizontal : Direction.Vertical); ; //добавить проверку
            Console.WriteLine("Введите координату начальной клетке: сначала букву, через пробел цифру");
            string startCellLine = Console.ReadLine();

             return true;
            } catch (Exception e)
            {
                UserNotification.ErrorMessage("При установке корабля произошла ошибка, придется повторить попытку", e);
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
