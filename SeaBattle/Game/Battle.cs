using SeaBattle.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Game
{
    class Battle
    {
        Player playerOneHuman;
        Player playerTwoAI;


        public void Run()
        {
            playerOneHuman = new Player();
            playerTwoAI = new Player();

            playerOneHuman.SetEnemyField(((BaseField)playerTwoAI.HomeField));
            playerTwoAI.SetEnemyField(((BaseField)playerOneHuman.HomeField));

            SetAllShips();
            

        }

        public void SetAllShips()
        {
            int settedShips = 0;
            Console.WriteLine("Процесс заполнения кораблями поля");
            Console.WriteLine(playerOneHuman.HomeField.PrintField());
            while (settedShips != 10)
            {
                Console.WriteLine("Четырех палубный");
                Console.WriteLine("Введите направление: 1 - по горизонтали; ");

                settedShips++;

            }
        }

        
    }
}
