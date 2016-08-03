using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

//manag all of ours screen -load/unload/update/draw etc
namespace TeamEdolus
{
  public class ScreenManager
  {
      private static ScreenManager instance;
        GameScreen currentScreen;

        public ScreenManager()
        {
            //size of our screen
            Dimensions = new Vector2(640, 480);
            currentScreen = new SplashScreen();
        }

      public Vector2 Dimensions { get; private set; }
      public ContentManager Content { get; private set; }

      

      public static ScreenManager Instance
      {
          get
          {
              if (instance == null)
              
                  instance = new ScreenManager();

              return instance;

          }
      }

    
     public void LoadContent(ContentManager Content)
     {
         this.Content = new ContentManager(Content.ServiceProvider, "Content");
         currentScreen.LoadContent();
     }

      public void UnloadContent()
      {
          currentScreen.UnloadContent();
      }

      public void Update(GameTime gameTime)
      {
          currentScreen.Update(gameTime);
      }

      public void Draw(SpriteBatch spriteBatch)
      {
          currentScreen.Draw(spriteBatch);
      }
    }
}
