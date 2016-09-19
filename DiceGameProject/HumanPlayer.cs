using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    class HumanPlayer : Player
    {
        double money;
        Weapon weapon;
        public HumanPlayer(string name, double money, Die firePowerLevel) : base(name){
            this.money = money;
            weapon = new Weapon(firePowerLevel);
        }
        public double GetMoney()
        {
            return money;
        }
        public void SetMoney(double reward) {
            money += reward;
        }
        public override string Attack(Player opponent)
        {
            int damage = weapon.GetFirePowerLevel().RollDie();
            opponent.SetHealth(opponent.GetHealth() - damage);
            return ("You have done " + damage + " points of damage! ");
        }
        public void UpgradeWeapon(Die upgradeToFirePower, int level)
        {
            weapon.SetFirePower(upgradeToFirePower, level);
        }
        public int GetWeaponPowerLevel()
        {
            return weapon.GetFirePowerLevel().GetSides();
        }
        public Weapon GetWeapon() {
            return weapon;
        }
    }//End of class
}
