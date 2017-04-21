using System;

namespace SeaBattle.Share
{
    /// <summary>
    /// Represents input, output, and errors messages to communicate with users.
    /// </summary>
    public static class UserInteraction
    {
        /// <summary>
        /// Writes the specified string value, followed by the current line terminator.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="additionalInformation"></param>
        public static void Message(string message, string additionalInformation = "")
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(message, additionalInformation);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Writes the Important string value, followed by the current line terminator.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="additionalInformation"></param>
        public static void ImportantMessage(string message, string additionalInformation = "")
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message, additionalInformation);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        ///  Writes the string value means all is ok, followed by the current line terminator.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="additionalInformation"></param>
        public static void OKMessage(string message, string additionalInformation = "")
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(message,additionalInformation);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        ///  Writes the Error string value, followed by the current line terminator.
        /// </summary>
        /// <param name="message"></param>
        /// <param name="e"></param>
        /// <param name="additionalInformation"></param>
        public static void ErrorMessage(string message, Exception e, string additionalInformation = "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message, e.Message, additionalInformation);
            Console.ForegroundColor = ConsoleColor.Gray;
        }

        /// <summary>
        /// Reads the line of characters from input stream.
        /// </summary>
        /// <returns>string</returns>
        public static string ReadLine()
        {
            return Console.ReadLine();
        }
    }
}
