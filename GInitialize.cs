#region Using Statements
//C#
using System;
//Monogame
using Content;
using Microsoft.Xna.Framework         ;   //https://msdn.microsoft.com/en-us/library/microsoft.xna.framework.aspx
using Microsoft.Xna.Framework.Graphics;
//DIV
using AbstractRealm;
using AbstractRealm.Options;
using AbstractRealm.Realm_Space;
using AbstractRealm.States;
#endregion

namespace Game   //The Game's main namespace.
{
    public class GIni
                 :  Game   //Game class is where the original structure that Dreamer uses origingates from.
    {
        public static AR ar;

        long rateToTicks;

        public GIni()
        {
            //Console.WriteLine("\n" + "Running GIni" + "\n");
            Content.RootDirectory = "Content"; //Console.WriteLine("Linked Monogame content manager to content directory." + "\n");

            ar = new AR(this, Content);   //Contains Essential Game Pre-Initialization Functions.
        }

        //Changes window title depending on program focus loss.
        protected override void OnActivated  (object sender, System.EventArgs args)
        { Window.Title = "Game Name"               ; base.OnActivated  (sender, args); }
        protected override void OnDeactivated(object sender, System.EventArgs args)
        { Window.Title = "(Out of Focus) Game Name"; base.OnDeactivated(sender, args); }

        //Allows the game to perform any initialization it needs to before starting to run.bv
        protected override void Initialize()
        {
            rateToTicks = (long)10000000 / (long)AR.refreshRate;

            Console.WriteLine("ratetoTicks: " + rateToTicks);

            TargetElapsedTime = new TimeSpan(rateToTicks);
            IsFixedTimeStep   = true;

            base.Initialize(); //Console.WriteLine("Base initialization run." + "\n");

            ar.initialize();

            AssetMngr.gDevice.SamplerStates[0] = new SamplerState { Filter = TextureFilter.Anisotropic };   //Needs to be moved to diplay as a configurable option.
        }

        //LoadContent will be called once per game and is the place to load all of your content.
        protected override void LoadContent()
        {
            ar.loadAssetMngr();
        }

        protected override void UnloadContent() { }   //Useless.

        //Allows the game to run logic such as updating the world, checking for collisions, gathering input, and playing audio.
        protected override void Update(GameTime gameTime)
        {
            ar.update(gameTime);
            //base.Update(gameTime);  Find out why this is used by default... seems unnecessary and bad coding.
        }

        //This is called when the game should draw itself.
        protected override void Draw(GameTime gameTime)
        {
            ar.gDeviceMngr.GraphicsDevice.Clear(Color.Black);

            ar.draw(AssetMngr.spriteBatch, AssetMngr.basicEffect);
            //base.Draw(gameTime);   Same as base.Update(gameTime)....
        }
    }
}
