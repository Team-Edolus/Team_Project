using System;
using System.Collections.Generic;
using System.Linq;
using RPG_AdvancedCS_May.Graphics;
using RPG_AdvancedCS_May.Interfaces;
using RPG_AdvancedCS_May.Structure;

namespace RPG_AdvancedCS_May.Structure
{
    public class BasicAttack : MeleeAbility, IRenderable
    {
        //int x, int y, int sizeX, int sizeY, int visualX, int visualY, SpriteType spriteType
        public const int BasicAttackMaxLifespanInMS = 500;
        
        protected const int BasicAttackVisualSizeX = 6; //test
        protected const int BasicAttackVisualSizeY = 16;
        protected const int BasicAttackPower = 60;
        protected const AbilityEffectEnum BasicAttackAbilityEffect = AbilityEffectEnum.DamagingAbility;
        protected const SpriteType BasicAttackSpriteType = SpriteType.Sword;

        public BasicAttack(int x, int y, int sizeX, int sizeY, int visualX, int visualY, IUnit caster) 
            : base(x, y, sizeX, sizeY, visualX, visualY, BasicAttackVisualSizeX, BasicAttackVisualSizeY, BasicAttackPower, BasicAttackAbilityEffect, caster)
        {
            this.MaxLifespanInMS = BasicAttackMaxLifespanInMS;
            this.CurrentLifespanInMS = 0;
            this.HasTimedOut = false;
            this.SpriteType = BasicAttackSpriteType;
        }

        public SpriteType SpriteType { get; set; }
    }
}
