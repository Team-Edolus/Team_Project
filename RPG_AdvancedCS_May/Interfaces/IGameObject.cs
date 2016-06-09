using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_AdvancedCS_May.Interfaces
{
    interface IGameObject
    {
        int sizeX { get; set; }
        int sizeY { get; set; }

        int X { get; set; }
        int Y { get; set; }
    }
}
