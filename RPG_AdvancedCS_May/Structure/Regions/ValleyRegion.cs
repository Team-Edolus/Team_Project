using RPG_AdvancedCS_May.GameEngine;

namespace RPG_AdvancedCS_May.Structure
{
    using System;
    using Graphics;

    public class ValleyRegion : Region<ValleyRegion>
    {
        public ValleyRegion() : base()
        {
            this.SpriteType = SpriteType.ValleyRegionBG;
            SetEnemies();
        }

        protected override void SetEnemies()
        {
            this.RegionEnemies.Add(new Boar1(200, 200));
        }

        protected override void SetGateways()
        {
            this.RegionGateways.Add(new Gateway(352, 717, 80, 3, 
                () => this.regionEntities.InitialiseStartRegion(), 552, 8,
                (x, y) => this.regionEntities.Player.Relocate(x, y)));
        }

        protected override void SetObstacles()
        {

        }
    }
}
