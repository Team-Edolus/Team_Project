using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using RPG_AdvancedCS_May.Interfaces;

namespace RPG_AdvancedCS_May.Structure
{
    public class GameObject : IGameObject
    {
        public int sizeX { get; set; }

        public int sizeY { get; set; }

        public int X { get; set; }

        public int Y { get; set; }
    }
}
