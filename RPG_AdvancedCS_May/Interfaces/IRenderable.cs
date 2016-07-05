namespace RPG_AdvancedCS_May.Interfaces
{
    using Graphics;

    public interface IRenderable : IGameObject
    {
        SpriteType SpriteType { get; set; }
    }
}
