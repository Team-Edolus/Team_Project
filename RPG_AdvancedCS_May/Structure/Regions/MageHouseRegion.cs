namespace RPG_AdvancedCS_May.Structure
{
    using Graphics;
    public class MageHouseRegion : Region<MageHouseRegion>
    {
        public MageHouseRegion() : base()
        {
            this.SpriteType = SpriteType.MageHouseRegionBG;
        }

        protected override void SetFriendlyNPCs()
        {
            this.RegionFriendlyNPCs.Add(new OldMage());
        }

        protected override void SetEnemies()
        {

        }

        protected override void SetGateways()
        {
            // To MageLayerRegion Gateway
            this.RegionGateways.Add(new Gateway(528, 589, 48, 3,
                () => this.regionEntities.InitialiseNewRegion(MageLayerRegion.Instance), 1040, 192,
                (x, y) => this.regionEntities.Player.Relocate(x, y)));
        }

        protected override void SetObstacles()
        {

        }
    }
}
