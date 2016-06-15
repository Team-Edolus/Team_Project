using System;
using System.Collections.Generic;
using System.Linq;
using RPG_AdvancedCS_May.Interfaces;

namespace RPG_AdvancedCS_May.Structure
{
    public abstract class MeleeAbility : Ability
    {
        protected MeleeAbility(int x, int y, int sizeX, int sizeY, int visualX, int visualY, 
            int visualSizeX, int visualSizeY, int power, AbilityEffectEnum abilityEffect, IUnit caster) 
            : base(x, y, sizeX, sizeY, visualX, visualY, visualSizeX, visualSizeY, power, abilityEffect, caster)
        {
        }
    }
}
