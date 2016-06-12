using System;
using System.Collections.Generic;
using System.Linq;

namespace RPG_AdvancedCS_May.Structure
{
    public abstract class MeleeAbility : Ability
    {
        protected MeleeAbility(int sizeX, int sizeY, int x, int y) : base(sizeX, sizeY, x, y)
        {

        }
    }
}
