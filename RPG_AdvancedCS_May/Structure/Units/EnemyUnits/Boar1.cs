
using RPG_AdvancedCS_May.Graphics;

namespace RPG_AdvancedCS_May.Structure
{
    public class Boar1 : EnemyNPCUnit
    {
        private const int Boar1SizeX = 39;
        private const int Boar1SizeY = 24;
        private const int Boar1CurrHP = 450;
        private const int Boar1MaxHP = 450;
        private const int Boar1AttPoins = 20;
        private const int Boar1DefPoints = 10;
        private const int Boar1MovSpeed = 3;
        private const SpriteType Boar1Sprite = SpriteType.Boar;

        public Boar1(int x, int y) 
            : base(x, y, Boar1SizeX, Boar1SizeY, Boar1CurrHP, Boar1MaxHP, 
                  Boar1AttPoins, Boar1DefPoints, Boar1MovSpeed, Boar1Sprite)
        {
        }
    }
}
