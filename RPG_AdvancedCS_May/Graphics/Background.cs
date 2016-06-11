
using RPG_AdvancedCS_May.Interfaces;

namespace RPG_AdvancedCS_May.Graphics
{
    public class Background : IRenderable //test class
    {
        public int SizeX { get; set; }
        public int SizeY { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public SpriteType SpriteType { get; set; }

        public Background()
        {
            SizeX = 1280;
            SizeY = 720;
            X = 0;
            Y = 0;
            SpriteType = SpriteType.Background;
        }
    }
}
