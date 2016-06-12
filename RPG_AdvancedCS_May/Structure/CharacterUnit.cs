using System;
using System.CodeDom;
using System.Collections.Generic;

using RPG_AdvancedCS_May.Interfaces;
using RPG_AdvancedCS_May.GameEngine;
using RPG_AdvancedCS_May.Graphics;

namespace RPG_AdvancedCS_May.Structure
{
    public abstract class CharacterUnit : Unit
    {
        protected CharacterUnit(int sizeX, int sizeY, int x, int y, int currentHp, int maxHp, int attackPoints,
            int defensePoints, int movementSpeed, SpriteType spriteType)
            : base(sizeX, sizeY, x, y, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {

        }
    }
}