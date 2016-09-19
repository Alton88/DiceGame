using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    class Game
    {
        List<HumanPlayer> players;
        Monster monster;
        List<Die> firePowerLevel;
        int numberOfPlayers;
        Random shotPercentage;
        public Game() {
            CreateDice();
            shotPercentage = new Random();
            players = new List<HumanPlayer>();
            monster = new Monster("Monster");
        }
        public void StartGame() {
            numberOfPlayers = Menu.GameMenu();
            CreatePlayers(numberOfPlayers);
            Battle(numberOfPlayers);
        }
        public void CreatePlayers(int numberOfPlayers) {
            Console.Write("Player1 please enter your name: ");
            players.Add(new HumanPlayer(Convert.ToString(Console.ReadLine()), 50, firePowerLevel[0]));

            if (numberOfPlayers == 2)
            {
                Console.Write("Player2 please enter your name: ");
                players.Add(new HumanPlayer(Convert.ToString(Console.ReadLine()), 50, firePowerLevel[0]));
                monster.SetHealth(20);
            }  
        }
        public void CreateDice() {
            firePowerLevel = new List<Die>();
            firePowerLevel.Add(new Die(4));
            firePowerLevel.Add(new Die(6));
            firePowerLevel.Add(new Die(8));
            firePowerLevel.Add(new Die(10));
            firePowerLevel.Add(new Die(12));
            firePowerLevel.Add(new Die(20)); 
        }
        public void Battle(int numberOfPlayers) {
            for (int i = 0; i < numberOfPlayers; ++i) {
                ChooseWeapon(players[i]);
            }
            while (monster.GetHealth() > 0 ) {
                for (int i = 0; i < numberOfPlayers; ++i) {
                    if (players[i].GetHealth() > 0 && CheckIfPlayersAreAlive(numberOfPlayers))
                    {
                        TakeTurn(players[i]);
                    }
                    else if(!CheckIfPlayersAreAlive(numberOfPlayers) && monster.GetHealth() > 0) {
                        Console.WriteLine("\nYou Lose!!!");
                        monster.SetHealth(0);
                    }
                }//End of for
            }//End of while
            for (int i = 0; i < numberOfPlayers; ++i)
            {
                if (players[i].GetHealth() > 0) {
                    Console.WriteLine("\nCongratulations {0} on beating the monster!", players[i].GetName());
                    Console.WriteLine("Your reward is 100 Gold!");
                    players[i].SetMoney(100);
                }
                
            }
            monster.SetHealth(numberOfPlayers * 10);
            for (int i = 0; i < numberOfPlayers; ++i)
            {
                players[i].SetHealth(10);               
                Console.WriteLine("{0}'s money is now {1} ", players[i].GetName(), players[i].GetMoney());
            }
            
            ChooseToPlayAgain(numberOfPlayers);
        }
        public bool CheckIfPlayersAreAlive(int numberOfPlayers) {
            bool areAlive = false;
            for (int i = 0; i < numberOfPlayers; ++i) {
                areAlive = players[i].GetHealth() > 0 ? true : false;
            }
            return areAlive;
        }
        public void TakeTurn(HumanPlayer player){
            if (player.GetHealth() > 0)
            {             
                Console.WriteLine("\n{0} you are being attacked by a monster, you pick up your gun. ", player.GetName());
                Console.WriteLine("Please press \"Enter\" to attack the monster.\n");
                Console.ReadKey();
                if (TakeShot(player))
                {
                    Console.WriteLine("{0} shot has hit the monster!", player.GetName());
                    Console.WriteLine(player.Attack(monster));//Change from string to int!!!
                }
                else
                    Console.WriteLine("Sorry, your shot missed.");

                if (monster.GetHealth() > 0)
                {
                    Console.WriteLine("\nThe {0} is now attacking you! ", monster.GetName());
                    Console.WriteLine(monster.Attack(player));
                }
                Console.WriteLine("\n{0}'s health is now {1} and the {2}'s health is now {3}!", player.GetName(), player.GetHealth() > 0 ? player.GetHealth() : 0, monster.GetName(), monster.GetHealth() > 0 ? monster.GetHealth() : 0);
            }
        }
        public void ChooseToPlayAgain(int numberOfPlayers){
            Console.Write("\nWould you like to play again? y/n ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine("\n");
                this.Battle(numberOfPlayers);
            }
            else {
                Console.WriteLine("Stats will be saved to file, GOOD BYE!!!");
                SaveStatsToFile(numberOfPlayers);
            }
        }
        public void ChooseWeapon(HumanPlayer player) {
            Console.WriteLine("\n{0} choose a weapon to fight the monster with.", player.GetName());
            Console.WriteLine("The more powerful the weapon, the less accuracy you will have.  So choose wisely!");
            Console.WriteLine("You can choose between six different weapons.");
            Console.WriteLine("Enter \"1\" for a level 1 weapon with 100% accuracy.");
            Console.WriteLine("Enter \"2\" for a level 2 weapon with 90% accuracy.");
            Console.WriteLine("Enter \"3\" for a level 3 weapon with 80% accuracy.");
            Console.WriteLine("Enter \"4\" for a level 4 weapon with 70% accuracy.");
            Console.WriteLine("Enter \"5\" for a level 5 weapon with 60% accuracy.");
            Console.WriteLine("Enter \"6\" for a level 6 weapon with 50% accuracy.");

            int playerChoice = Convert.ToInt32(Console.ReadLine());
            
            player.UpgradeWeapon(firePowerLevel[playerChoice - 1], playerChoice);
        }
        public bool TakeShot(HumanPlayer player) {      
            int[] chance = new int[6] {100, 90, 80, 70, 60, 50};
            if (shotPercentage.Next(100) < chance[player.GetWeapon().GetWeaponLevel() - 1]) {
                return true;
            }
            return false;
        }
        public void SaveStatsToFile(int numberOfPlayers) {
            System.IO.StreamWriter file = new System.IO.StreamWriter("GameStats.txt", true);

            for (int i = 0; i < numberOfPlayers; ++i)
            {
                file.WriteLine("{0}'s gold is now {1}", players[i].GetName(), players[i].GetMoney());
            }
            file.WriteLine();

            file.Close();
        }
    }//End of class
}
