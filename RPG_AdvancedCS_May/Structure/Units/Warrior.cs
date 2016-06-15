using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using RPG_AdvancedCS_May.Graphics;
using RPG_AdvancedCS_May.Interfaces;

using System.Windows.Forms;
using RPG_AdvancedCS_May.GameEngine;

namespace RPG_AdvancedCS_May.Structure
{
    public class Warrior : CharacterUnit, IMeleeAttacking
    {
        //TO DO: Make constant fields for Warrior and reduce constructor arguments;
        public Warrior(int x, int y, int sizeX, int sizeY, int currentHp, int maxHp, 
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {
        }

        public MeleeAbility MeleeAttack(int mouseX, int mouseY)
        {
            //MessageBox.Show($"MeleeAttack: {mouseX}-{mouseY} \n {this.DetermineAbilityDirection(mouseX, mouseY).ToString()}");
            //TO DO: Check for active ability from action bar
            return this.UseBasicAttack(mouseX, mouseY);
        }

        private BasicAttack UseBasicAttack(int mouseX, int mouseY)
        {
            var direction = this.DetermineAbilityDirection(mouseX, mouseY);
            int abilityX;
            int abilityY;
            int abilitySizeX;
            int abilitySizeY;
            int abilityVisualX;
            int abilityVisualY;
            switch (direction)
            {
                case DirectionEnum.East:
                    abilityX = this.X + this.SizeX;
                    abilityY = this.Y - this.SizeY/4;
                    abilitySizeX = this.SizeX;
                    abilitySizeY = this.SizeY + this.SizeY/2;
                    abilityVisualX = this.X + this.SizeX;
                    abilityVisualY = this.Y + 7; //<--test out
                    break;
                case DirectionEnum.West:
                    abilityX = this.X - this.SizeX;
                    abilityY = this.Y - this.SizeY / 4;
                    abilitySizeX = this.SizeX;
                    abilitySizeY = this.SizeY + this.SizeY / 2;
                    abilityVisualX = this.X - this.SizeX + 10; //<-- test out
                    abilityVisualY = this.Y + 7;
                    break;
                case DirectionEnum.North:
                    abilityX = this.X - this.SizeX;
                    abilityY = this.Y - this.SizeX;
                    abilitySizeX = this.SizeX * 3;
                    abilitySizeY = this.SizeX;
                    abilityVisualX = this.X + 5; //<-- test out
                    abilityVisualY = this.Y - this.SizeX;
                    break;
                case DirectionEnum.South:
                    abilityX = this.X - this.SizeX;
                    abilityY = this.Y + this.SizeY;
                    abilitySizeX = this.SizeX * 3;
                    abilitySizeY = this.SizeX;
                    abilityVisualX = this.X + 5; //<-- test out
                    abilityVisualY = this.Y + this.SizeY;
                    break;
                default:
                    throw  new ArgumentException("Unexisting direction");
            }
            return new BasicAttack(abilityX, abilityY, abilitySizeX, abilitySizeY, abilityVisualX, abilityVisualY, this);
        }
    }
}
