using SeaBattle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle.Model;
using SeaBattle.Model.Player;
using SeaBattle.Model.Field;
using SeaBattle.Model.Ship;


namespace SeaBattle.Share
{
    class Battle
    {
        HumanPlayer playerOneHuman;
        AIPlayer playerTwoAI;

        public void Run()
        {

            playerOneHuman = new HumanPlayer();
            //playerTwoAI = new AIPlayer();

            //playerOneHuman.SetEnemyField(((BaseField)playerTwoAI.HomeField));
            //playerTwoAI.SetEnemyField(((BaseField)playerOneHuman.HomeField));
            PrintHomeField(playerOneHuman.HomeField);
            playerOneHuman.SetAllShips();
            PrintHomeField(playerOneHuman.HomeField);

        }

        public void PrintHomeField(IHomeField homeField)
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
                    if (homeField.Cells[j, i].IsHitted)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(homeField.Cells[j, i].ToString());
                        Console.ForegroundColor = ConsoleColor.White;
                    }
                    else
                    {
                        if(homeField.Cells[j, i].ToString() == "0")
                        {
                            Console.Write(homeField.Cells[j, i].ToString());
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(homeField.Cells[j, i].ToString());
                            Console.ForegroundColor = ConsoleColor.White;
                        }
                    }
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
