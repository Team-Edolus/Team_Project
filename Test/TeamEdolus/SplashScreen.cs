using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

//first screen we see
namespace TeamEdolus
{
   public class SplashScreen : GameScreen
   {
       Texture2D image;
       string splashScreenPath = "Content/island.png";//here it gives me error

       public override void LoadContent()
       {
           base.LoadContent();
           image = content.Load<Texture2D>("Content/island.png");
       }

       public override void UnloadContent()
       {
           base.UnloadContent();
       }

       public override void Update(GameTime gameTime)
       {
           base.Update(gameTime);
       }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(image, Vector2.Zero, Color.White);
        }
    }
}
