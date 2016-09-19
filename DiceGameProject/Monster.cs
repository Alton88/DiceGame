using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    class Monster : Player
    {
        Random chooseAttack;
        int[] attacks;
        public Monster(string name) : base(name){
            this.name = name;
            attacks = new int[] {3,5,7,9};
            chooseAttack = new Random();
         }
        public override string Attack(Player opponent)
        {
            Die attack = new Die(attacks[chooseAttack.Next(0,3)]);
            int damage = attack.RollDie();
            opponent.SetHealth(opponent.GetHealth() - damage);
            return ("The Monster has done " + damage + "points of damage! ");
        }
        public override void SetHealth(int health) {
            this.health = health;
        }
    }//End of class
}
