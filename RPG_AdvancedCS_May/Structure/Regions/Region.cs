namespace RPG_AdvancedCS_May.Structure
{
    using System.Collections.Generic;
    using Interfaces;
    using Graphics;
    using GameEngine;

    public abstract class Region<T> : GameObject, IRegionInterface
        where T : Region<T>, new()
    {
        private static readonly T _instance = new T();
        //===================================
        private const int DefaultX = 0;
        private const int DefaultY = 0;
        private const int DefaultSizeX = 1280;
        private const int DefaultSizeY = 720;

        private bool isInitialised;
        protected RegionEntities regionEntities;

        protected Region() : base(DefaultX, DefaultY, DefaultSizeX, DefaultSizeY)
        {
            this.RegionFriendlyNPCs = new List<FriendlyNPCUnit>();
            this.RegionEnemies = new List<EnemyNPCUnit>();
            this.RegionObstacles = new List<Obstacle>();
            this.RegionGateways = new List<Gateway>();
            this.isInitialised = false;
        }

        //public static T Instance => _instance;
        public static T Instance
        {
            get
            {
                if (_instance.isInitialised) return _instance;
                _instance.Initialise();
                _instance.isInitialised = true;
                return _instance;
            }
        }

        public List<FriendlyNPCUnit> RegionFriendlyNPCs { get; set; }
        public List<EnemyNPCUnit> RegionEnemies { get; set; }
        public List<Obstacle> RegionObstacles { get; set; }
        public List<Gateway> RegionGateways { get; set; }
        public SpriteType SpriteType { get; set; }

        protected abstract void SetFriendlyNPCs();
        protected abstract void SetEnemies();
        protected abstract void SetGateways();
        protected abstract void SetObstacles();

        protected void Initialise()
        {
            this.regionEntities = RegionEntities.GetInstance();
            SetFriendlyNPCs();
            SetEnemies();
            SetGateways();
            SetObstacles();
        }
    }
}