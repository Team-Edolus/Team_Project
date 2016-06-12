using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_AdvancedCS_May.Graphics;
using RPG_AdvancedCS_May.Interfaces;

namespace RPG_AdvancedCS_May.Structure
{
    class EnemyNPCUnit : Unit //TO DO
    {
        public EnemyNPCUnit(int sizeX, int sizeY, int x, int y, int currentHp, int maxHp, 
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(sizeX, sizeY, x, y, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {

        }
    }
}
