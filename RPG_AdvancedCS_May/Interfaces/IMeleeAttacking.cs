using RPG_AdvancedCS_May.Structure;

namespace RPG_AdvancedCS_May.Interfaces
{
    public interface IMeleeAttacking
    {
        MeleeAbility MeleeAttack(int mouseX, int mouseY);
    }
}