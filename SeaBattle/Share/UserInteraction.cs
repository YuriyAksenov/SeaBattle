﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Share
{
    public static class UserInteraction
    {
        public static void Message(string message, string additionalInformation = "")
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message, additionalInformation);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
        

        public static void ImportantMessage(string message, string additionalInformation = "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message, additionalInformation);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void OKMessage(string message, string additionalInformation = "")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message,additionalInformation);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        public static void ErrorMessage(string message, Exception e, string additionalInformation = "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message, e.Message, additionalInformation);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        

        public static string ReadLine()
        {
            return Console.ReadLine();
        }

       
    }
}
