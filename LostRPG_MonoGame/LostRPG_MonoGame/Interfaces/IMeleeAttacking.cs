namespace LostRPG_MonoGame.Interfaces
{
    using Structure;

    public interface IMeleeAttacking
    {
        MeleeAbility MeleeAttack(int mouseX, int mouseY);
    }
}