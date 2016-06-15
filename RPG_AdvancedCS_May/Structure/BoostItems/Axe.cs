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
        private const int AxeX = 100;
        private const int AxeY = 50;
        private const SpriteType AxeDefaultSprite = SpriteType.Axe;

        public Axe() : base(AxeDefaultSizeX, AxeDefaultSizeY, AxeX, AxeY, AxeDefaultSprite, AXE_DEFAULT_HEALTH_BOOST, AXE_DEFAULT_DAMAGE_BOOST, AXE_DEFAULT_DEFENCE_BOOST)
        {

        }
    }
}
