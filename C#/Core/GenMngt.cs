//C#
using System;
//Monogame
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//AbstractRealm
using AbstractRealm.Assets      ;
using AbstractRealm.Input       ;
using AbstractRealm.Interface   ;
using AbstractRealm.Options     ;
using AbstractRealm.Realm_Space ;
using AbstractRealm.States      ;


namespace AbstractRealm
{
    public partial class AR   //General Managment Sector
    {
        //Public
        public void update(GameTime gameTime)
        {
            if (wake == true)
            {
                gIni.Exit();
            }

            while (updateCount <= refreshInterval)
            {
                deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

                inputMngr.poll();

                stateMngr.updateStates(inputMngr);

                inputMngr.clearPoll();

                updateCount = updateCount + updateInterval;
            }
            updateCount = new TimeSpan(0);
        }

        public void draw()
        {
            gDeviceMngr.GraphicsDevice.Clear(Color.Black);

            assetMngr.spriteBatch.Begin();
            assetMngr.spriteBatch.End();

            RasterizerState rasterizerState = new RasterizerState();

            rasterizerState.CullMode = CullMode.None;
            rasterizerState.FillMode = FillMode.Solid;

            assetMngr.gDevice.RasterizerState = rasterizerState;

            stateMngr.drawState();

            display.draw(assetMngr.spriteBatch, assetMngr.basicEffect, deltaTime);
        }

        public static bool  wake      { get; set; }   //Used for termination.
        public static float deltaTime { get; set; }   //Update and Draw syncronization and rate keeping;

        public static AssetMngr   assetMngr  ;   //Handles all assets of the game.
        public static InputMngr   inputMngr  ;   //Hanldes all inputs.
        public static ProfileMngr profileMngr;   //Handles user profiles.
        public static SpaceMngr   spaceMngr  ;   //Handles all existing spaces.
        public static StateMngr   stateMngr  ;   //Base handler for game states.
        public static UiMngr      uiMngr     ;   //Handles Ui.
        
        public static StndOptions options;   //Standard game configruation.
        public static Display     display;   //Display configuration.

        //Private
        private void updateTiming() //Able to change the update and refresh rate of the game.
        {
            updateInterval  = new TimeSpan( (long)(10000000 / options.updateRate) );   //Converts the specified upaterate   to its rate in ticks.
            refreshInterval = new TimeSpan( (long)(10000000 / display.framerate ) );   //Converts the specified refreshrate to its rate in ticks.
        }

        private TimeSpan updateInterval ;
        private TimeSpan refreshInterval;

        private TimeSpan updateCount = new TimeSpan(0);
    }
}