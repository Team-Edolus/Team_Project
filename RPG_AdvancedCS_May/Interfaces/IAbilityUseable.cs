using RPG_AdvancedCS_May.GameEngine;

namespace RPG_AdvancedCS_May.Interfaces
{
    public interface IAbilityUseable
    {
        DirectionEnum DetermineAbilityDirection(int mouseX, int mouseY);
    }
}
