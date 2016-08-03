namespace RPG_AdvancedCS_May.Structure
{
    using Graphics;

    public class Shield : Item
    {
        private const int Shield_DEFAULT_DAMAGE_BOOST = 0;
        private const int Shield_DEFAULT_HEALTH_BOOST = 0;
        private const int Shield_DEFAULT_DEFENCE_BOOST = 50;
        private const int ShieldDefaultSizeX = 32;
        private const int ShieldDefaultSizeY = 32;

        private const SpriteType ShieldDefaultSprite = SpriteType.Shield;

        public Shield(int x, int y) 
            : base(x, y, ShieldDefaultSizeX, ShieldDefaultSizeY, Shield_DEFAULT_HEALTH_BOOST, 
                  Shield_DEFAULT_DAMAGE_BOOST, Shield_DEFAULT_DEFENCE_BOOST, ShieldDefaultSprite)
        {
        }

        
    }
}
