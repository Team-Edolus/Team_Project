using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_AdvancedCS_May.GameEngine;
using RPG_AdvancedCS_May.Graphics;
using RPG_AdvancedCS_May.Interfaces;

namespace RPG_AdvancedCS_May.Structure
{
    public abstract class Unit : GameObject, IUnit, IMoveable, IRenderable
    {
        public int AttackPoints { get; set; }

        public int CurrentHP { get; set; }

        public int DefensePoints { get; set; }

        public int MaxHP { get; set; }

        public Direction Direction { get; set; }

        public int MovementSpeed { get; set; }

        public SpriteType SpriteType { get; set; }

        protected Unit(int sizeX, int sizeY, int x, int y, int currentHp, int maxHp,
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(sizeX, sizeY, x, y)
        {
            this.AttackPoints = attackPoints;
            this.CurrentHP = currentHp;
            this.DefensePoints = defensePoints;
            this.MaxHP = maxHp;
            this.MovementSpeed = movementSpeed;
            this.SpriteType = spriteType;
        }

        public void Move()
        {
            this.X += this.MovementSpeed*this.Direction.DirX;
            this.Y += this.MovementSpeed*this.Direction.DirY; 
        }

    }
}
