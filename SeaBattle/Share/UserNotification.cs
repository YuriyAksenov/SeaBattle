using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeaBattle.Game
{
    public static class UserNotification
    {
        public static void Message(string message, string additionalInformation = "")
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message, additionalInformation);
            Console.ForegroundColor = ConsoleColor.Cyan;

        }

        public static void ImportantMessage(string message, string additionalInformation = "")
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(message, additionalInformation);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public static void OKMessage(string message, string additionalInformation = "")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message,additionalInformation);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

        public static void ErrorMessage(string message, Exception e, string additionalInformation = "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message, e.Message, additionalInformation);
            Console.ForegroundColor = ConsoleColor.Cyan;
        }

       
    }
}
