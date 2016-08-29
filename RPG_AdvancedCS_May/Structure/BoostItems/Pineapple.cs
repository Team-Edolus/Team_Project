namespace RPG_AdvancedCS_May.Structure
{
    using Graphics;

    public class Pineapple : Item
    {
        private const int Pineapple_DEFAULT_DAMAGE_BOOST = 0;
        private const int Pineapple_DEFAULT_HEALTH_BOOST = 100;
        private const int Pineapple_DEFAULT_DEFENCE_BOOST = 0;
        private const int PineappleDefaultSizeX = 35;
        private const int PineappleDefaultSizeY = 32;

        private const SpriteType PineappleDefaultSprite = SpriteType.Pineapple;

        public Pineapple(int x, int y)
            : base(x, y, PineappleDefaultSizeX, PineappleDefaultSizeY, Pineapple_DEFAULT_HEALTH_BOOST,
                  Pineapple_DEFAULT_DAMAGE_BOOST, Pineapple_DEFAULT_DEFENCE_BOOST, PineappleDefaultSprite)
        {
        }
    }
}
