namespace LostRPG_MonoGame.Interfaces
{
    using GameEngine;

    public interface IAbilityUseable
    {
        DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY);
    }
}
