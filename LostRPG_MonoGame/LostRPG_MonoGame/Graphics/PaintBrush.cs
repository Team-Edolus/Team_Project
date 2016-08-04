namespace LostRPG_MonoGame.Graphics
{
    using Interfaces;

    public class PaintBrush : IPaintInterface
    {
        private readonly ITextureHandler textureHandler;
        private readonly IGraphicsEngine graphicsEngine;

        public PaintBrush(ITextureHandler textureHandler, IGraphicsEngine graphicsEngine)
        {
            this.textureHandler = textureHandler;
            this.graphicsEngine = graphicsEngine;
        }

        public void AddObject(IRenderable renderableObject)
        {
            var newBox = this.CreateTextureBox(renderableObject);
            this.graphicsEngine.AddBox(newBox);
            //TODO: Implement some sort of health bar
        }

        private ITextureBox CreateTextureBox(IRenderable renderableObject)
        {
            var texture = this.textureHandler.GetSpriteTexture(renderableObject);
            var textureBox = new TextureBox(texture, renderableObject);
            return textureBox;
        }

        public void RemoveObject(IRenderable renderableObject)
        {
            this.graphicsEngine.RemoveBoxByParent(renderableObject);
        }

        public void RedrawObject(IRenderable renderableObject)
        {
            var textureBox = this.graphicsEngine.RemoveBoxByParent(renderableObject);
            textureBox.UpdatePosition();
            this.graphicsEngine.AddBox(textureBox);
        }

        public void SetBackground(IRenderable renderableObject)
        {
            var newBox = this.CreateTextureBox(renderableObject);
            this.graphicsEngine.AddBox(newBox);
            //TODO: Check for MonoGame Background Options
        }

        public void RedrawObjectWithAShield(IRenderable renderableObject)
        {
            throw new System.NotImplementedException();
        }
    }
}
