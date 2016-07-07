﻿using RPG_AdvancedCS_May.GameEngine;

namespace RPG_AdvancedCS_May.Structure
{
    using Graphics;

    public class ValleyRegion : Region<ValleyRegion>
    {
        public ValleyRegion() : base()
        {
            this.SpriteType = SpriteType.ValleyRegionBG;
        }

        protected override void SetFriendlyNPCs()
        {
        }

        protected override void SetEnemies()
        {
            this.RegionEnemies.Add(new Boar1(250, 200));
        }

        protected override void SetGateways()
        {
            // To StartRegion Gateway
            this.RegionGateways.Add(new Gateway(352, 717, 80, 3, 
                () => this.regionEntities.InitialiseNewRegion(StartRegion.Instance), 552, 8,
                (x, y) => this.regionEntities.Player.Relocate(x, y)));
            // To MageLayerRegion Gateway
            this.RegionGateways.Add(new Gateway(1277, 496, 3, 48,
                () => this.regionEntities.InitialiseNewRegion(MageLayerRegion.Instance), 0, 560,
                (x, y) => this.regionEntities.Player.Relocate(x, y)));
        }

        protected override void SetObstacles()
        {
            //this.RegionObstacles.Add(new Obstacle(0, 0, 320, 720));
        }
    }
}