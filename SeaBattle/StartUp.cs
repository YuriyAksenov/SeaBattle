﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SeaBattle.Share;

namespace SeaBattle
{
    class Startup
    {
        /// <summary>
        /// Application Entry Point.
        /// </summary>
        //[System.STAThreadAttribute()]
        //[System.Diagnostics.DebuggerNonUserCodeAttribute()]
        //[System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public static void Main()
        {
            //SeaBattle.App app = new SeaBattle.App();
            //app.InitializeComponent();
            //app.Run();
            Battle battle = new Battle();
            battle.Run();

        }
    }
}
