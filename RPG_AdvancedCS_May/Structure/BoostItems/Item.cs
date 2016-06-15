namespace RPG_AdvancedCS_May.Structure.BoostItems
{
    using Graphics;
    using Interfaces;

    public abstract class Item : GameObject, IRenderable
    {
        protected Item(int sizeX, int sizeY, int x, int y, SpriteType sprite, int healthPointsBoost, int damagePointBoost) : base(sizeX, sizeY, x, y)
        {
            this.HealthPointsBoost = healthPointsBoost;
            this.DamagePointsBoost = damagePointBoost;
            this.SpriteType = sprite;
        }

        public int HealthPointsBoost { get; set; }
        public int DamagePointsBoost { get; set; }

        public void ApplyItemEffects(IUnit unit)
        {
            unit.AttackPoints += DamagePointsBoost;
            unit.CurrentHP += HealthPointsBoost;
        }

        public SpriteType SpriteType { get; set; }

    }
}
