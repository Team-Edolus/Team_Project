using RPG_AdvancedCS_May.Structure;

namespace RPG_AdvancedCS_May.Interfaces
{
    public interface IAbility
    {
        int VisualX { get; set; }
        int VisualY { get; set; }

        int VisualSizeX { get; set; }
        int VisualSizeY { get; set; }

        int Power { get; set; }

        IUnit Caster { get; set; }
        AbilityEffectEnum AbilityEffect { get; set; }
    }
}
