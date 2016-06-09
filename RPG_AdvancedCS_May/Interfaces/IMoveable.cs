using System;
using System.Collections.Generic;
using System.Linq;

using RPG_AdvancedCS_May.GameEngine;

namespace RPG_AdvancedCS_May.Interfaces
{
    interface IMoveable
    {
        Direction Direction { get; set; }
        int MovementSpeed { get; set; }
        void Move();
    }
}
