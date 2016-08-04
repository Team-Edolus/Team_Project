namespace LostRPG_MonoGame.Graphics
{
    using Interfaces;
    using Microsoft.Xna.Framework;
    using Microsoft.Xna.Framework.Graphics;

    public class TextureBox : ITextureBox
    {
        public TextureBox(Texture2D texture, IRenderable parentObject)
        {
            this.ParentObject = parentObject;
            this.Texture = texture;
            this.SetPosition();
        }

        public IRenderable ParentObject { get; }

        public Texture2D Texture { get; }
        public Vector2 Position { get; private set; }

        private void SetPosition()
        {
            var position = new Vector2(this.ParentObject.X, this.ParentObject.Y);
            if (this.ParentObject is IAbility)
            {
                var parent = (IAbility)this.ParentObject;
                position = new Vector2(parent.VisualX, parent.VisualY);
            }
            this.Position = position;
        }

        public void UpdatePosition()
        {
            this.SetPosition();
        }
    }
}
