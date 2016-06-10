using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RPG_AdvancedCS_May.Graphics;
using RPG_AdvancedCS_May.Interfaces;
//using RPG_AdvancedCS_May.GameEngine;

namespace RPG_AdvancedCS_May.Structure
{
    public abstract class Spell : Projectile, ITimeoutable, IRenderable //TO DO
    {
        
        public int MaxLifespanInMS { get; set; }
        public int CurrentLifespanInMS { get; set; } //TO DO: Implement check for timing out;
        public bool hasTimedOut { get; set; }

        private int Power { get; set; }
        private int Range { get; set; }
        private ISpellCastable Caster;

        public SpriteType SpriteType { get; set; }

        protected Spell(int sizeX, int sizeY, int x, int y, ISpellCastable caster, int maxLifespanInMs, int power, int range, SpriteType spriteType) : base(sizeX, sizeY, x, y)
        {
            Caster = caster;
            MaxLifespanInMS = maxLifespanInMs;
            Power = power;
            Range = range;
            SpriteType = spriteType;
        }
    }
}
