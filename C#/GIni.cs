#region Using Statements
//C#
using System;
//Monogame
using Microsoft.Xna.Framework;   //https://msdn.microsoft.com/en-us/library/microsoft.xna.framework.aspx
//AbstractRealm
using AbstractRealm;
#endregion

namespace Game   //The Game's main namespace.
{
    public class GIni : Game   //Game class is where the original structure that Dreamer uses origingates from.
    {
        private AR ar;

        public GIni()
        {
            ar = new AR();   //Contains Essential Game Pre-Initialization Functions.
            ar.setup(this, Content);
        }

        //Changes window title depending on program focus loss.
        protected override void OnActivated  (object sender, System.EventArgs args)
        { Window.Title = "Game Nmae"               ; base.OnActivated  (sender, args); }
        protected override void OnDeactivated(object sender, System.EventArgs args)
        { Window.Title = "(Out of Focus) Game Name"; base.OnDeactivated(sender, args); }

        //Allows the game to perform any initialization it needs to before starting to run.bv
        protected override void Initialize()
        {
            base.Initialize();
            ar  .initialize();
        }

        //LoadContent will be called once per game and is the place to load all of your content.
        protected override void LoadContent()
        {
            ar.loadAssetMngr();
        }

        protected override void UnloadContent() { }   //Never used.

        //Allows the game to run logic such as updating the world, checking for collisions, gathering input, and playing audio.
        protected override void Update(GameTime gameTime)
        {
            ar.update(gameTime);
            //base.Update(gameTime);  Find out why this is used by default... seems unnecessary and bad coding.
        }

        //This is called when the game should draw itself.
        protected override void Draw(GameTime gameTime)
        {
            ar.draw();
            //base.Draw(gameTime);   Same as base.Update(gameTime)....
        }
    }
}