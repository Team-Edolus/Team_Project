using System;
using System.Collections.Generic;
using System.Linq;
using RPG_AdvancedCS_May.Graphics;
using RPG_AdvancedCS_May.Interfaces;

namespace RPG_AdvancedCS_May.Structure
{
    public abstract class Ability : GameObject
    {
        protected Ability (int sizeX, int sizeY, int x, int y) : base(sizeX, sizeY, x, y)
        {

        }
    }
}
