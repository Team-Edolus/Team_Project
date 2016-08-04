namespace LostRPG_MonoGame.Structure
{
    using Interfaces;
    using Graphics;

    public class Structure : Environment, IRenderable
    {
        //TO DO
        public Structure(int x, int y, int sizeX, int sizeY) : base(x, y, sizeX, sizeY)
        {
        }

        public SpriteType SpriteType { get; set; }
    }
}
