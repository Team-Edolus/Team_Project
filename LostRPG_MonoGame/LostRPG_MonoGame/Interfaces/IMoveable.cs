namespace LostRPG_MonoGame.Interfaces
{
    using GameEngine;

    public interface IMoveable
    {
        Direction Direction { get; set; }
        int MovementSpeed { get; set; }
        void Move();
    }
}
