using System;
using System.Collections.Generic;
using System.Drawing;
using RPG_AdvancedCS_May.Structure;

namespace RPG_AdvancedCS_May.Interfaces
{
    public interface ISpellCastable
    {
        Spell CastSpell(int x, int y); //TO DO: Implement according to game logic.
    }
}
