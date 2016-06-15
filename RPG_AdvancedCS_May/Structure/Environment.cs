using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_AdvancedCS_May.Structure
{
    public abstract class Environment : GameObject
    {
        protected Environment(int x, int y, int sizeX, int sizeY) : base(x, y, sizeX, sizeY)
        {
        }
    }
}
