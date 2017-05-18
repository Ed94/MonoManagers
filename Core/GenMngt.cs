using AbstractRealm.Realm_Space;
using AbstractRealm.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using AbstractRealm.Input;
using AbstractRealm.Interface;
using AbstractRealm.States;
using AbstractRealm.Options;

namespace AbstractRealm
{
    public partial class AR   //General Managment Sector
    {
        //Vars and Objects
        public static bool wake { get; set; }

        public static AssetMngr assetMngr;   //Handles all assets of the game.
        public static InputMngr inputMngr;   //Hanldes all inputs.
        public static UiMngr       uiMngr;   //Handles Ui.
        public static SpaceMngr spaceMngr;   //Handles all existing spaces.
        public static StateMngr stateMngr;   //Base handler for game states.

        public static ProfileMngr profileMngr;   //Handles user profiles.

        public static StndOptions options;   //Standard game configruation.
        public static Display     display;   //Display configuration.

        //Update and Draw syncronization and rate keeping;
        public float deltaTime;

        public long refreshRate;
        public long updateRate ;

        TimeSpan updateInterval ;
        TimeSpan refreshInterval;

        TimeSpan updateCount = new TimeSpan(0);

        //Functions
        private void updateTiming() //Able to change the update and refreshrate of the game.
        {
            updateRate = 1000;   //Configurable from standard options?
            refreshRate = 144;   //Configurable from Display  class.

            updateInterval  = new TimeSpan((long)10000000 / updateRate );   //Converts the specified upaterate   to its rate in ticks.
            refreshInterval = new TimeSpan((long)10000000 / refreshRate);   //Converts the specified refreshrate to its rate in ticks.
        }

        public void update(GameTime gameTime)
        {
            if(wake == true)
            {
                dreamer.Exit();
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
            assetMngr.spriteBatch.Begin();
            assetMngr.spriteBatch.End  ();

            RasterizerState rasterizerState = new RasterizerState();

            rasterizerState.CullMode = CullMode.None;
            rasterizerState.FillMode = FillMode.Solid;

            AssetMngr.gDevice.RasterizerState = rasterizerState;

            stateMngr.drawState();
            display.draw       (assetMngr.spriteBatch, assetMngr.basicEffect, deltaTime);
        }
    }
}