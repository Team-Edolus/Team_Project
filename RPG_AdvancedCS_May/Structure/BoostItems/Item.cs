namespace RPG_AdvancedCS_May.Structure
{
    using Graphics;
    using Interfaces;

    public abstract class Item : GameObject, IRenderable
    {
        protected Item(int x, int y, int sizeX, int sizeY, int healthBoost, int damageBoost, int defenseBoost, SpriteType spriteType) : base(x, y, sizeX, sizeY)
        {
            this.SpriteType = spriteType;
            this.HealthPointsBoost = healthBoost;
            this.DamagePointsBoost = damageBoost;
            this.DefensePointsBoost = defenseBoost;
            hasBeenUsed = false;
        }

        public int HealthPointsBoost { get; set; }
        public int DamagePointsBoost { get; set; }
        public int DefensePointsBoost { get; set; }

        public void ApplyItemEffects(IUnit unit)
        {
            unit.AttackPoints += DamagePointsBoost;
            unit.CurrentHP += HealthPointsBoost;
            unit.DefensePoints += DefensePointsBoost;
        }

        public SpriteType SpriteType { get; set; }
        public bool hasBeenUsed { get; set; }
    }
}
