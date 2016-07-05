namespace RPG_AdvancedCS_May.Structure
{
    using Interfaces;

    public abstract class Ability : GameObject, IAbility, ITimeoutable
    {
        public int VisualX { get; set; }
        public int VisualY { get; set; }
        public int VisualSizeX { get; set; }
        public int VisualSizeY { get; set; }
        public int Power { get; set; }
        public AbilityEffectEnum AbilityEffect { get; set; }
        public IUnit Caster { get; set; }

        private int _maxLifespanInMS;
        private int _currentLifespanInMS;
        
        public int MaxLifespanInMS { get; set; }
        
        public int CurrentLifespanInMS
        {
            get
            {
                return this._currentLifespanInMS;
            }
            set
            {
                if (value > MaxLifespanInMS)
                {
                    this.HasTimedOut = true;
                }
                else
                {
                    this._currentLifespanInMS = value;
                }
            }
        }
        public bool HasTimedOut { get; set; }

        protected Ability(int x, int y, int sizeX, int sizeY, int visualX, int visualY, 
            int visualSizeX, int visualSizeY, int power, AbilityEffectEnum abilityEffect, IUnit caster)
            : base(x, y, sizeX, sizeY)
        {
            VisualX = visualX;
            VisualY = visualY;
            VisualSizeX = visualSizeX;
            VisualSizeY = visualSizeY;
            this.Power = power;
            AbilityEffect = abilityEffect;
            this.Caster = caster;
        }
    }
}
