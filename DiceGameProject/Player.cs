using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    abstract class Player
    {
        protected string name;
        protected int health;

        public Player(string name) {
            this.name = name;

            this.health = 10;    
        }
        public virtual int GetHealth() {
            return health;
        }
        public virtual void SetHealth(int health) {
            this.health = health;
        }
        public virtual string Attack(Player opponent)
        {           
            return ("Your health is " + opponent.GetHealth());
        }
        public virtual string GetName() {
            return name;
        }
        public virtual void SetName(string name) {
            this.name = name;
        }
    }//End of class
}
