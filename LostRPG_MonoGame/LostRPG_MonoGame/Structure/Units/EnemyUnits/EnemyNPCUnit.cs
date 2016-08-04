namespace LostRPG_MonoGame.Structure
{
    using Graphics;

    public abstract class EnemyNPCUnit : Unit
    {
        protected EnemyNPCUnit(int x, int y, int sizeX, int sizeY, int currentHp, int maxHp, 
            int attackPoints, int defensePoints, int movementSpeed, SpriteType spriteType) 
            : base(x, y, sizeX, sizeY, currentHp, maxHp, attackPoints, defensePoints, movementSpeed, spriteType)
        {
        }
    }
}
