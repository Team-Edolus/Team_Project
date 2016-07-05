namespace RPG_AdvancedCS_May.Interfaces
{
    using Structure;

    public interface IMeleeAttacking
    {
        MeleeAbility MeleeAttack(int mouseX, int mouseY);
    }
}