using System;
using System.CodeDom;
using System.Collections.Generic;

using RPG_AdvancedCS_May.Interfaces;
using RPG_AdvancedCS_May.GameEngine;
using RPG_AdvancedCS_May.Graphics;
using RPG_AdvancedCS_May.GameEngine;

namespace RPG_AdvancedCS_May.Structure
{
    public abstract class CharacterUnit : Unit, IAbilityUseable
    {
        protected CharacterUnit(int sizeX, int sizeY, int x, int y, int currentHp, int maxHp, int attackPoints,
            int defensePoints, int movementSpeed, SpriteType spriteType)
            : base(sizeX, sizeY, x, y, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {

        }

        public DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY)
        {
            var centerX = this.X + this.SizeX/2;
            var centerY = this.Y + this.SizeY/2;
            var relativeX = mouseX - centerX;
            var relativeY = centerY - mouseY;
            var diagSum = relativeX + relativeY;
            if (relativeX > relativeY && diagSum > 0)
            {
                return DirectionEnum.East;
            }
            else if (relativeX >  relativeY && diagSum < 0)
            {
                return DirectionEnum.South;
            }
            else if (relativeX < relativeY && diagSum > 0)
            {
                return DirectionEnum.North;
            }
            else if (relativeX < relativeY && diagSum < 0)
            {
                return DirectionEnum.West;
            }
            else
            {
                return (relativeX > 0)? DirectionEnum.East : DirectionEnum.West;
            }
        }
    }
}