namespace RPG_AdvancedCS_May.Interfaces
{
    using GameEngine;

    public interface IMoveable
    {
        Direction Direction { get; set; }
        int MovementSpeed { get; set; }
        void Move();
    }
}
