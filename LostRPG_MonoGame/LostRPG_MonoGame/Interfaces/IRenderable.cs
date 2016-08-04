namespace LostRPG_MonoGame.Interfaces
{
    using Graphics;

    public interface IRenderable : IGameObject
    {
        SpriteType SpriteType { get; set; }
    }
}
