using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_AdvancedCS_May.GameEngine;
using RPG_AdvancedCS_May.Interfaces;

namespace RPG_AdvancedCS_May.Structure
{
    class Projectile : GameObject, IMoveable
    {
        //TO DO
        //Spells, Arrows, etc..

        public Projectile(int sizeX, int sizeY, int x, int y) : base(sizeX, sizeY, x, y)
        {
        }

        public Direction Direction { get; set; }
        public int MovementSpeed { get; set; }
        public void Move()
        {
            throw new NotImplementedException();
        }
    }
}
