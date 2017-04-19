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
        BasePlayer playerOneHuman;
        BasePlayer playerTwoAI;


        public void Run()
        {
            
            playerOneHuman = new BasePlayer();
            playerTwoAI = new BasePlayer();

            playerOneHuman.SetEnemyField(((BaseField)playerTwoAI.HomeField));
            playerTwoAI.SetEnemyField(((BaseField)playerOneHuman.HomeField));

 
            

        }

       




    }
}
