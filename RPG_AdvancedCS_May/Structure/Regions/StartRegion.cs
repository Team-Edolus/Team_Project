using RPG_AdvancedCS_May.GameEngine;

namespace RPG_AdvancedCS_May.Structure
{
    using System;
    using Graphics;

    public class StartRegion : Region<StartRegion>
    {
        public StartRegion() : base()
        {
            this.SpriteType = SpriteType.StartRegionBG;
        }

        protected override void SetEnemies()
        {
            this.RegionEnemies.Add(new GiantCrab1(200, 200));
            this.RegionEnemies.Add(new GiantCrab1(300, 300));
            this.RegionEnemies.Add(new GiantCrab1(400, 400));
            this.RegionEnemies.Add(new GiantCrab1(500, 400));
        }

        protected override void SetGateways()
        {
            this.RegionGateways.Add(new Gateway(544, 0, 32, 3, 
                () => this.regionEntities.InitialiseValleyRegion(), 384, 688,
                (x, y) => this.regionEntities.Player.Relocate(x, y)));
        }

        protected override void SetObstacles()
        {
            this.RegionObstacles.Add(new Obstacle(0, 0, 100, 100));
        }
    }
}
