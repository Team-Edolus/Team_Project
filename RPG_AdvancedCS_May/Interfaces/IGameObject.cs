using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_AdvancedCS_May.Interfaces
{
    public interface IGameObject
    {
        int X { get; set; }
        int Y { get; set; }

        int SizeX { get; set; }
        int SizeY { get; set; }
    }
}
