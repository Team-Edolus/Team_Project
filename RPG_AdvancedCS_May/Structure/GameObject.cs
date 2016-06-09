using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPG_AdvancedCS_May.Interfaces;

namespace RPG_AdvancedCS_May.Structure
{
    public abstract class GameObject : IGameObject
    {
        public int SizeX { get; set; }

        public int SizeY { get; set; }

        public int X { get; set; }

        public int Y { get; set; }

        public GameObject(int sizeX, int sizeY, int x, int y)
        {
            this.SizeX = sizeX;
            this.SizeY = sizeY;
            this.X = x;
            this.Y = y;
        }
    }
}
