namespace RPG_AdvancedCS_May.GameEngine
{
    using System;
    using System.Collections.Generic;

    using Interfaces;
    using Structure;

    public sealed class RegionEntities
    {
        //bg->(items)->enemies->player  ?obstacles;
        private static RegionEntities instance;

        private readonly IPaintInterface painter;
        private IRegionInterface currentRegion;

        private RegionEntities(IPaintInterface painter)
        {
            this.painter = painter;
        }

        public CharacterUnit Player { get; set; }
        public List<FriendlyNPCUnit> FriendlyNPCs { get; set; }
        public List<EnemyNPCUnit> Enemies { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<Obstacle> Obstacles { get; set; }
        public List<Gateway> Gateways { get; set; }
        public List<Item> Items { get; set; }

        public static void IntantiateClass(IPaintInterface painter)
        {
            instance = new RegionEntities(painter);
            instance.SetupFirstRegion();
        }

        public static RegionEntities GetInstance()
        {
            if (instance == null)
            {
                throw new Exception("Problem with Singleton");
            }
            return instance;
        }

        private void AddNewGraphicObjects()
        {
            this.painter.SetBackground(this.currentRegion);
            foreach (var friendlyNpcUnit in FriendlyNPCs)
            {
                this.painter.AddObject(friendlyNpcUnit);
            }
            foreach (var enemy in this.Enemies)
            {
                this.painter.AddObject(enemy);
            }
            this.painter.AddObject(Player);

            foreach (var item in Items)
            {
                this.painter.AddObject(item);
            }
        }

        private void RemoveOldGraphicObjects()
        {
            this.painter.RemoveObject(this.Player);

            foreach (var friendlyNpcUnit in FriendlyNPCs)
            {
                this.painter.RemoveObject(friendlyNpcUnit);
            }
            foreach (var enemy in Enemies)
            {
                this.painter.RemoveObject(enemy);
            }

            foreach (var item in Items)
            {
                this.painter.RemoveObject(item);
            }

            this.painter.RemoveObject(this.currentRegion); //(background)
        }

        private void LoadRegionEntities()
        {
            this.FriendlyNPCs = new List<FriendlyNPCUnit>();
            this.Enemies = new List<EnemyNPCUnit>();
            this.Abilities = new List<Ability>();
            this.Obstacles = new List<Obstacle>();
            this.Gateways = new List<Gateway>();
            this.Items = new List<Item>();

            foreach (var regionFriendlyNpC in this.currentRegion.RegionFriendlyNPCs)
            {
                this.FriendlyNPCs.Add(regionFriendlyNpC);
            }

            foreach (var enemy in this.currentRegion.RegionEnemies)
            {
                this.Enemies.Add(enemy);
            }

            foreach (var regionGateway in this.currentRegion.RegionGateways)
            {
                this.Gateways.Add(regionGateway);
            }

            foreach (var regionObstacle in this.currentRegion.RegionObstacles)
            {
                this.Obstacles.Add(regionObstacle);
            }

            foreach (var item in this.currentRegion.RegionItems)
            {
                this.Items.Add(item);
            }
        }
        private void SetupFirstRegion()
        {
            //this.currentRegion = MageLayerRegion.Instance;
            this.currentRegion = StartRegion.Instance;
            this.Player = new Warrior(1000, 400);
            this.LoadRegionEntities();
            this.AddNewGraphicObjects();
        }

        public void InitialiseNewRegion(IRegionInterface newRegion)
        {
            this.RemoveOldGraphicObjects();

            this.currentRegion = newRegion;
            this.LoadRegionEntities();

            this.AddNewGraphicObjects();
        }
    }
}
