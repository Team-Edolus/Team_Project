namespace RPG_AdvancedCS_May.Interfaces
{
    using System.Collections.Generic;

    using Structure;

    public interface IRegionInterface : IRenderable
    {
        List<FriendlyNPCUnit> RegionFriendlyNPCs { get; set; }
        List<EnemyNPCUnit> RegionEnemies { get; set; }
        List<Obstacle> RegionObstacles { get; set; }
        List<Gateway> RegionGateways { get; set; }
        List<Item> RegionItems { get; set; }
    }
}
