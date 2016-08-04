namespace LostRPG_MonoGame.Structure
{
    using System;
    using GameEngine;
    using Interfaces;

    public abstract class Projectile : GameObject, IMoveable   //Make an interface?   //TO DO: 
    {
        //Description: Spells, Arrows, etc..
        protected Projectile(int sizeX, int sizeY, int x, int y) : base(sizeX, sizeY, x, y)
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
