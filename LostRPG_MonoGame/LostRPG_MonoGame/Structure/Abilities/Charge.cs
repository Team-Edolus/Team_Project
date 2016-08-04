namespace LostRPG_MonoGame.Structure
{
    using Interfaces;
    public class Charge : MeleeAbility //TO DO
    {
        private const int ChargeVisualX = 0;
        private const int ChargeVisualY = 0;
        private const int ChargeVisualSizeX = 0;
        private const int ChargeVisualSizeY = 0;
        private const int ChargePower = 0;
        private const AbilityEffectEnum ChargeAbilityEffect = AbilityEffectEnum.DisplacingAbility;

        public Charge(int x, int y, int sizeX, int sizeY, IUnit caster) 
            : base(x, y, sizeX, sizeY, ChargeVisualX, ChargeVisualY, ChargeVisualSizeX, ChargeVisualSizeY,
                  ChargePower, ChargeAbilityEffect, caster)
        {
        }

    }
}
