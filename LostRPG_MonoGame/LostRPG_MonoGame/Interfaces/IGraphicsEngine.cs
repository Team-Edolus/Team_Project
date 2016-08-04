namespace LostRPG_MonoGame.Interfaces
{
    using Microsoft.Xna.Framework;

    public interface IGraphicsEngine
    {
        void AddBox(ITextureBox textureBox);
        ITextureBox RemoveBoxByParent(IRenderable boxParent);

        void RedrawAll(GameTime gameTime);
    }
}
