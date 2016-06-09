using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_AdvancedCS_May.Interfaces;

namespace RPG_AdvancedCS_May.GameEngine
{
    public struct Direction
    {
        //TO DO: Replace with enum
        public int DirX { get; set; }
        public int DirY { get; set; }

        public Direction(int dirX, int dirY) : this()
        {
            this.DirX = dirX;
            this.DirY = dirY;
        }
    }
}