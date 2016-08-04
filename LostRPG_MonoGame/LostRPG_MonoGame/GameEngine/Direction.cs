namespace LostRPG_MonoGame.GameEngine
{
    public struct Direction
    {
        //TO DO: Replace with enum
        public int DirX { get; set; }
        public int DirY { get; set; }

        public Direction(int dirX, int dirY) : this()
        {
            this.DirX = dirX;
            this.DirY = dirY;
        }
    }
}