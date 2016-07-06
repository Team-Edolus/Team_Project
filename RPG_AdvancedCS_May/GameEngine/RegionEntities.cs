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
        public List<EnemyNPCUnit> Enemies { get; set; }
        public List<Ability> Abilities { get; set; }
        public List<Obstacle> Obstacles { get; set; }
        public List<Gateway> Gateways { get; set; }
        
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
            foreach (var enemy in this.Enemies)
            {
                this.painter.AddObject(enemy);
            }
            this.painter.AddObject(Player);
        }

        private void RemoveOldGraphicObjects()
        {
            this.painter.RemoveObject(this.Player);
            foreach (var enemy in Enemies)
            {
                this.painter.RemoveObject(enemy);
            }

            this.painter.RemoveObject(this.currentRegion); //(background)
        }

        private void LoadRegionEntities()
        {
            this.Enemies = new List<EnemyNPCUnit>();
            this.Abilities = new List<Ability>();
            this.Obstacles = new List<Obstacle>();
            this.Gateways = new List<Gateway>();
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
        }
        private void SetupFirstRegion()
        {
            this.currentRegion = StartRegion.Instance;
            this.Player = new Warrior(300, 200);
            this.LoadRegionEntities();
            this.AddNewGraphicObjects();
        }

        public void InitialiseStartRegion()
        {
            this.RemoveOldGraphicObjects();

            this.currentRegion = StartRegion.Instance;
            this.LoadRegionEntities();

            this.AddNewGraphicObjects();
        }

        public void InitialiseValleyRegion()
        {
            this.RemoveOldGraphicObjects();
            //
            this.currentRegion = ValleyRegion.Instance;
            this.LoadRegionEntities();
            //Set new player coordinates
            this.AddNewGraphicObjects();
        }

        //
    }
}
