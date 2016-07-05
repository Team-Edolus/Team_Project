namespace RPG_AdvancedCS_May.Structure
{
    using Graphics;

    public class FriendlyNPCUnit : Unit
    {
        //TO DO
        //Make a questgiver.
        public FriendlyNPCUnit(int x, int y, int sizeX, int sizeY, int currentHp, int maxHp, 
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {
        }
    }
}
