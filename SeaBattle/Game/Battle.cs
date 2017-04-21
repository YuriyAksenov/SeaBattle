using System;
using SeaBattle.Model.Field;
using SeaBattle.Game;
using SeaBattle.Model.Game;

namespace SeaBattle.Share
{
    /// <summary>
    /// Provides the instance of the battle class.
    /// </summary>
    public class Battle
    {
        private HumanPlayer playerOneHuman;
        private AIPlayer playerTwoAI;

        /// <summary>
        /// Run all games chain.
        /// </summary>
        public void Run()
        {

            playerTwoAI = new AIPlayer();
            playerTwoAI.SetAllShips();

            playerOneHuman = new HumanPlayer();
            playerOneHuman.SetAllShips();

            playerTwoAI.SetEnemyField(playerOneHuman.HomeField);
            playerOneHuman.SetEnemyField(playerTwoAI.HomeField);


            Console.WriteLine("Корабли противника");
            PrintHomeField(playerTwoAI.HomeField);
            Console.WriteLine("\n\n");
           
            Console.WriteLine("Корабли ВАши");
            PrintHomeField(playerOneHuman.HomeField);

            int turnShooting = 1;
            while(!playerOneHuman.IsAllShipsHitted() || !playerTwoAI.IsAllShipsHitted())
            {
                int horizontalCoordinateShootingCell = 0;
                int verticalCoordinateShootingCell = 0;

                if (turnShooting == 1)
                {
                    PrintEnemyField(playerOneHuman.EnemyField);
                    Console.WriteLine("Ваш ход. Формат ввода 1А");
                    char[] humanShootingCell = Console.ReadLine().Trim().ToCharArray();

                    horizontalCoordinateShootingCell = (Convert.ToInt32(humanShootingCell[1])) - 1;
                    switch (humanShootingCell[1])
                    {
                        case 'А': verticalCoordinateShootingCell = 0; break;
                        case 'Б': verticalCoordinateShootingCell = 1; break;
                        case 'В': verticalCoordinateShootingCell = 2; break;
                        case 'Г': verticalCoordinateShootingCell = 3; break;
                        case 'Д': verticalCoordinateShootingCell = 4; break;
                        case 'Е': verticalCoordinateShootingCell = 5; break;
                        case 'Ж': verticalCoordinateShootingCell = 6; break;
                        case 'З': verticalCoordinateShootingCell = 7; break;
                        case 'И': verticalCoordinateShootingCell = 8; break;
                        case 'К': verticalCoordinateShootingCell = 9; break;
                        default:
                            break;
                    }
                    if (playerOneHuman.ShootCell(horizontalCoordinateShootingCell, verticalCoordinateShootingCell))
                    {
                        Console.WriteLine("Вы попали, следующий ход опять ваш.");
                        turnShooting = 1;
                    }
                    else
                    {
                        Console.WriteLine("Увы, Вы не попали, следующий ход противника.");
                        turnShooting = 1;
                    }
                    
                }
                else
                {
                    if (playerTwoAI.ShootCell(horizontalCoordinateShootingCell, verticalCoordinateShootingCell))
                    {

                        turnShooting = 1;
                    }
                    else
                    {
                        Console.WriteLine("Увы, Вы не попали, следующий ход противника.");
                        turnShooting = 2;
                    }
                }
            }

        }

        /// <summary>
        /// Prints a field in a home way view.
        /// </summary>
        public void PrintHomeField(IHomeField homeField)
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
                    if (homeField.Cells[j, i].IsHitted)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(homeField.Cells[j, i].ToString());
                        Console.ForegroundColor = ConsoleColor.Gray;
                    }
                    else
                    {
                        if(homeField.Cells[j, i].ToString() == "0")
                        {
                            Console.ForegroundColor = ConsoleColor.Gray;
                            Console.Write(homeField.Cells[j, i].ToString());
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(homeField.Cells[j, i].ToString());
                            Console.ForegroundColor = ConsoleColor.Gray;
                        }
                    }
                    Console.Write(" |");
                }
                Console.WriteLine();
            }
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Prints a field in a home way view.
        /// </summary>
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
