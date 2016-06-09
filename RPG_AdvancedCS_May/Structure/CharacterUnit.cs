using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_AdvancedCS_May.GameEngine;
using RPG_AdvancedCS_May.Graphics;

namespace RPG_AdvancedCS_May.Structure
{
    class CharacterUnit : Unit
    {
        public CharacterUnit(int sizeX, int sizeY, int x, int y, int currentHp, int maxHp, int attackPoints,
            int defensePoints, int movementSpeed, SpriteType spriteType)
            : base(sizeX, sizeY, x, y, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {
        }
    }
}