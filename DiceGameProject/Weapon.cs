using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiceGameProject
{
    class Weapon
    {
        Die firePowerLevel;
        int level;
        public Weapon(Die firePowerLevel) {
            this.firePowerLevel = firePowerLevel;
            level = 1;
        }
        public Die GetFirePowerLevel() {
            return firePowerLevel;
        }
        public int GetWeaponLevel() {
            return level;
        }
        public void SetFirePower(Die newFirePowerLevel, int newLevel) {
            firePowerLevel = newFirePowerLevel;
            level = newLevel;
        }
    }
}
