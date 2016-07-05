namespace RPG_AdvancedCS_May.Structure
{
    using Interfaces;
    public abstract class GameObject : IGameObject
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int SizeX { get; set; }
        public int SizeY { get; set; }

        protected GameObject(int x, int y, int sizeX, int sizeY)
        {
            X = x;
            Y = y;
            SizeX = sizeX;
            SizeY = sizeY;
        }
    }
}