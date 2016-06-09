using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_AdvancedCS_May.GameEngine;

namespace RPG_AdvancedCS_May.Structure
{
    class CharacterUnit : Unit
    {
        public CharacterUnit(int sizeX, int sizeY, int x, int y, int attackPoints, int currentHp, 
            int defensePoints, int maxHp, Direction direction, int movementSpeed) 
            : base(sizeX, sizeY, x, y, attackPoints, currentHp, defensePoints, maxHp, direction, movementSpeed)
        {

        }
    }
}
