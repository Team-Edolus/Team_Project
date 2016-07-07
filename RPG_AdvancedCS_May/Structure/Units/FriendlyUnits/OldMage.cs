namespace RPG_AdvancedCS_May.Structure
{
    using Graphics;
    public class OldMage : FriendlyNPCUnit
    {
        private const int OldMageX = 704;
        private const int OldMageY = 288;
        private const int OldMageSizeX = 30;
        private const int OldMageSizeY = 33;
        private const SpriteType OldMageSprite = SpriteType.OldMageNPC;

        public OldMage() 
            : base(OldMageX, OldMageY, OldMageSizeX, OldMageSizeY, OldMageSprite)
        {
        }
    }
}
