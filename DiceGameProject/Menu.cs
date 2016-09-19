using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    static class Menu
    {
        public static int GameMenu()
        {
            int numberOfPlayers = 0;

            Console.WriteLine("Welcome To My Fighting Dice Game!");
            Console.WriteLine("---------------------------------\n");

            while (numberOfPlayers != 1 && numberOfPlayers != 2)
            {
                Console.Write("Please enter \"1\" to play the one player game or \"2\" to play the two player game ");
                try
                {
                    numberOfPlayers = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    Console.WriteLine("{0}\n\nYou did not enter a valid number. \nPlease try again!\n", e);
                }
            }
            return numberOfPlayers;
        }
    }
}
