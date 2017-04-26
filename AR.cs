//C#
using System;
//Monogame
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
//Abstract Realm
using Content;
using Game;
using AbstractRealm.Input;
using AbstractRealm.Options;
using AbstractRealm.Realm_Space;
using AbstractRealm.States;
using AbstractRealm.Interface;

namespace AbstractRealm
{
    public class AR   //Abstract Realm Class       
    {
        GIni gini;

        public static long refreshRate    ;

        long     updateRate     ;
        TimeSpan updateInterval ;
        TimeSpan refreshInterval;

        TimeSpan updateCount = new TimeSpan(0);

        public static float deltaTime;

        private  ContentManager        content    ;
        public   GraphicsDeviceManager gDeviceMngr;

        public static AssetMngr assetMngr;
        public static InputMngr inputMngr;
        public static UiMngr    uiMngr   ;
        public static SpaceMngr spaceMngr;
        public static StateMngr stateMngr;

        public  static ProfileMngr  profileMngr;

        StndOptions options;
        Display     display;

        //Constructors
        public AR(GIni passGIni:, ContentManager passContent)
        {                                                                      //Console.WriteLine("Running AR class.");
            content     = passContent                           ;
            gDeviceMngr = new GraphicsDeviceManager(passGIni);

            checkAPISupport();

            gIni = passGIni;
            
            if (firstRun == true)
            {
                createUserPath();
            }

            profileMngr = new ProfileMngr(); //Initalizes the profile manager.

            //Related to Options
            options = new StndOptions();   //Loads standard options.
            display = new Display(gDeviceMngr);   //Loads display  options.

            //Related to timing
            updateTiming();
        }

        //------------------------------------------Startup Management--------------------------------------------------------------------
        static bool    firstRun = checkFirstRun();   //Keeps information reguarding if this is the first time the program is run.

        private void checkAPISupport()   //Proposed way of checking api and changing binary to best one.
        {
            bool vulkan;  bool openGL; bool directX;

            directX = false;
            openGL  = false;
            vulkan  = false;

            //Vulkan Goes first when its supported.
            if      (openGL  == true) {}
            else if (directX == true)
            {

            }
            else
            {
                
            }
        }

        private static bool checkOpenGL()
        {
            bool support = false;

            return support;
        }

        private static bool checkFirstRun()   //Checks if this is the first time the program was run.
        {                                                   Console.WriteLine("Detecting if this is the first run of DIV client...");
            if (!System.IO.Directory.Exists(@"Users"))
            {                                               Console.WriteLine("This is the first run." + "\n");
                return true; 
            }
            else
            {
                return false;
            }
        }

        private void createUserPath()   //Makes the Users file directory.
        {
            string userPath = @"Users";         Console.WriteLine("Created a User folder." + "\n");

            System.IO.Directory.CreateDirectory(userPath);
        }
        
        //------------------------------------------General Management---------------------------------------------------------------------
        public void initialize()
        {
            inputMngr = new InputMngr();
            uiMngr    = new UiMngr   ();
            spaceMngr = new SpaceMngr();
            stateMngr = new StateMngr();
        }

        public void loadAssetMngr()
        {
            assetMngr = new AssetMngr(content, gDeviceMngr.GraphicsDevice);
        }

        private void updateTiming()
        {
            updateRate  = 1000; //How many times per second you want the game logic to update.
            refreshRate =  144; //The monitor's refreshrate.

            updateInterval  = new TimeSpan((long)10000000 / updateRate );
            refreshInterval = new TimeSpan((long)10000000 / refreshRate);
        }

        public void update(GameTime gameTime)
        {
            while (updateCount <= refreshInterval)
            {
                deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

                inputMngr.poll();

                stateMngr.updateStates();

                inputMngr.clearPoll();

                updateCount = updateCount + updateInterval;
            }
            updateCount = new TimeSpan(0); 
        }

        public void draw(SpriteBatch spriteBatch, BasicEffect basicEffect)
        {
            spriteBatch.Begin();
            spriteBatch.End  ();

            RasterizerState rasterizerState = new RasterizerState();

            rasterizerState.CullMode = CullMode.None;
            rasterizerState.FillMode = FillMode.Solid;

            AssetMngr.gDevice.RasterizerState = rasterizerState;

            stateMngr.drawState                            ();
            display.draw(spriteBatch, basicEffect, deltaTime);
        }

        //----Related to Display------Temporary tester for config changing.
        public void changeRes()
        {
            display  .changeDisplay  ();
            assetMngr.unload         ();
            spaceMngr = new SpaceMngr();
            stateMngr.initalizeState ();

            SpaceMngr.camPosition.Z = -100f;

            SpaceMngr.view = Matrix.CreateLookAt(SpaceMngr.camPosition, SpaceMngr.camTarget, Vector3.Up);
        }
    }

    //Allows for objects with ability to call update and draw calls from the game class.
    public abstract class RealmControl
    {
        public float     deltaTime = AR.deltaTime;

        public AssetMngr assetMngr = AR.assetMngr;
        public StateMngr stateMngr = AR.stateMngr;
        public SpaceMngr spaceMngr = AR.spaceMngr;
        public InputMngr inputMngr = AR.inputMngr;

        public abstract void Update(InputMngr   inputMngr                           );
        public abstract void Draw  (SpriteBatch spriteBatch, BasicEffect basicEffect);
    }
}
