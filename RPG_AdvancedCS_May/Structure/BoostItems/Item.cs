namespace RPG_AdvancedCS_May.Structure
{
    using Graphics;
    using Interfaces;

    public abstract class Item : GameObject, IRenderable
    {
        protected Item(int sizeX, int sizeY, int x, int y, SpriteType sprite, 
            int healthPointsBoost, int damagePointBoost, int defensePointsBoost) 
            : base(sizeX, sizeY, x, y)
        {
            this.HealthPointsBoost = healthPointsBoost;
            this.DamagePointsBoost = damagePointBoost;
            this.DefensePointsBoost = defensePointsBoost;
            this.SpriteType = sprite;
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

    }
}
