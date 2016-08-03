namespace RPG_AdvancedCS_May.Structure
{
    using Graphics;
    public class MageLayerRegion : Region<MageLayerRegion>
    {
        public MageLayerRegion() : base()
        {
            this.SpriteType = SpriteType.MageLayerRegionBG;
        }

        protected override void SetFriendlyNPCs()
        {
        }

        protected override void SetEnemies()
        {
            this.RegionEnemies.Add(new Boar1(200, 200));
        }

        protected override void SetGateways()
        {
            // To ValleyRegion Gateway
            this.RegionGateways.Add(new Gateway(0, 496, 3, 112,
                () => this.regionEntities.InitialiseNewRegion(ValleyRegion.Instance), 1248, 512,
                (x, y) => this.regionEntities.Player.Relocate(x, y)));
            // To MageHouseRegion Gateway
            this.RegionGateways.Add(new Gateway(1056, 176, 32, 3,
                () => this.regionEntities.InitialiseNewRegion(MageHouseRegion.Instance), 544, 544,
                (x, y) => this.regionEntities.Player.Relocate(x, y)));
        }

        protected override void SetObstacles()
        {

        }

        protected override void SetBoostItems()
        {
            this.RegionItems.Add(new Shield(1100, 280));
        }
    }
}
