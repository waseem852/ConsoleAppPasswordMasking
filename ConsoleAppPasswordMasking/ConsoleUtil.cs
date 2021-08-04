using System;

namespace ConsoleAppPasswordMasking
{
    public static class ConsoleUtil
    {
        /// <summary>
        /// Read Password and Mask it with *
        /// </summary>
        /// <param name="maskCharacter">Mask Character to be shown. default * </param>
        /// <returns>Actual Password</returns>
        public static string ReadPassword(string maskCharacter = "*")
        {

            //Initially it will be blank
            var password = "";

            //Entered Key
            var theKey = Console.ReadKey(true);

            //Until the user Enter "Enter Key"
            while (theKey.Key != ConsoleKey.Enter)
            {
                //If the entered key is NOT backspace
                if (theKey.Key != ConsoleKey.Backspace)
                {
                    Console.Write(maskCharacter);
                    password += theKey.KeyChar;
                }
                else if (theKey.Key == ConsoleKey.Backspace)
                {
                    if (!string.IsNullOrEmpty(password))
                    {
                        //Remove the last character from the list of password characters
                        password = password.Substring(0, password.Length - 1);

                        //Get the location of the cursor
                        var position = Console.CursorLeft;
                        //Move the cursor to the left by one character
                        Console.SetCursorPosition(position - 1, Console.CursorTop);
                        //Replace it with space
                        Console.Write(" ");
                        //Move the cursor to the left by one character again
                        Console.SetCursorPosition(position - 1, Console.CursorTop);
                    }
                }
                theKey = Console.ReadKey(true);
            }
            //Writeline because user pressed enter in the end of the password entry
            Console.WriteLine();
            return password;
        }


    }
}
