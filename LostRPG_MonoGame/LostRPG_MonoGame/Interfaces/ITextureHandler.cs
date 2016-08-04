namespace LostRPG_MonoGame.Interfaces
{
    using Microsoft.Xna.Framework.Graphics;

    public interface ITextureHandler
    {
        Texture2D GetSpriteTexture(IRenderable renderableObject);
    }
}
