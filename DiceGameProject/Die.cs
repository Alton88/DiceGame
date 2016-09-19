using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    class Die
    {
        int sides;
        Random RandomizeDie;
        public Die(int sides) {
            this.sides = sides;
            RandomizeDie = new Random();
        }
        public int GetSides() {
            return sides;
        }
        public int RollDie() {
            return RandomizeDie.Next(1, sides); 
        }
    }//End of class
}
