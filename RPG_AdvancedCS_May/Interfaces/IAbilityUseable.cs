namespace RPG_AdvancedCS_May.Interfaces
{
    using GameEngine;

    public interface IAbilityUseable
    {
        DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY);
    }
}
