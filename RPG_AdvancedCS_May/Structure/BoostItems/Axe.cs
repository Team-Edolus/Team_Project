namespace RPG_AdvancedCS_May.Structure.BoostItems
{
    using Graphics;

    public class Axe : Item
    {
        private const int AXE_DEFAULT_DAMAGE_BOOST = 50;
        private const int AXE_DEFAULT_HEALTH_BOOST = 0;
        private const int AXE_DEFAULT_DEFENCE_BOOST = 0;
        private const int AxeDefaultSizeX = 40;
        private const int AxeDefaultSizeY = 40;
        private const SpriteType AxeDefaultSprite = SpriteType.Axe;

        public Axe(int x,int y) : base(AxeDefaultSizeX, AxeDefaultSizeY, x, y, AxeDefaultSprite, AXE_DEFAULT_HEALTH_BOOST, AXE_DEFAULT_DAMAGE_BOOST, AXE_DEFAULT_DEFENCE_BOOST)
        {
            this.SizeX = AxeDefaultSizeX;
            this.SizeY = AxeDefaultSizeY;
        }
    }
}
