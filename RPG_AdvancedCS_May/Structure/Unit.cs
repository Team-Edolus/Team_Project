using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_AdvancedCS_May.GameEngine;
using RPG_AdvancedCS_May.Interfaces;

namespace RPG_AdvancedCS_May.Structure
{
    public abstract class Unit : GameObject, IUnit, IMoveable
    {
        public int AttackPoints { get; set; }

        public int CurrentHP { get; set; }

        public int DefensePoints { get; set; }

        public int MaxHP { get; set; }

        protected Unit(int sizeX, int sizeY, int x, int y, int attackPoints, int currentHp, 
            int defensePoints, int maxHp, Direction direction, int movementSpeed) 
            : base(sizeX, sizeY, x, y)
        {
            AttackPoints = attackPoints;
            CurrentHP = currentHp;
            DefensePoints = defensePoints;
            MaxHP = maxHp;
            Direction = direction;
            MovementSpeed = movementSpeed;
        }

        public Direction Direction { get; set; }
        public int MovementSpeed { get; set; }
        public void Move()
        {
            this.X += this.MovementSpeed*this.Direction.DirX;
            this.Y += this.MovementSpeed*this.Direction.DirY;
        }
    }
}
