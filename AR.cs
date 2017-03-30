//C#
using System;
//Monogame
using Microsoft.Xna.Framework         ;
using Microsoft.Xna.Framework.Content ;
using Microsoft.Xna.Framework.Graphics;
//AR
using AbstractRealm.Options          ;
using Game_NameSpace                 ;
using Content                        ;
using AbstractRealm.States           ;
using AbstractRealm.Realm_Space      ;

namespace AbstractRealm
{
    public class AR   //Abstract Realm Class       
    {
        public static float deltaTime;

        private  ContentManager        content    ;
        public   GraphicsDeviceManager gDeviceMngr;

        public static AssetMngr    assetMngr;
        public static SpaceMngr    spaceMngr;
        public static StateMngr    stateMngr;

        Display     display;
        Profile     profile;
        StndOptions options;
        
        //Constructors
        public AR(Game game, ContentManager passContent)
        {
            content     = passContent                       ;
            gDeviceMngr = new GraphicsDeviceManager(dreamer);

            checkAPISupport();

            Console.WriteLine("Running AR class.");
            if (firstRun == true)
            {
                createPath();

                profile = new Profile("Temp");   //Sets Current Profile Name to "temp"
            }

            profile = new Profile();

            //Related to Options
            options = new StndOptions(firstRun, profile             );   //Loads standard options.
            display = new Display    (firstRun, profile, gDeviceMngr);   //Loads display  options.
        }

        //------------------------------------------Startup Management--------------------------------------------------------------------

        static bool    firstRun = checkFirstRun();   //Keeps information reguarding if this is the first time the program is run.

        private void checkAPISupport()   //Proposed way of checking api and changing binary to best one.
        {
            bool vulkan;  bool openGL; bool directX;

            openGL  = false;
            directX = false;

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

        private void createPath()   //Makes the Users file directory.
        {
            string userPath = @"Users";         Console.WriteLine("Created a User folder." + "\n");

            System.IO.Directory.CreateDirectory(userPath);
        }

        private Profile getProfile()
        {
            return profile;
        }

        //------------------------------------------General Management---------------------------------------------------------------------
        public void initialize()
        {
            spaceMngr = new SpaceMngr();
            stateMngr = new StateMngr();
        }

        public void loadAssetMngr()
        {
            assetMngr = new AssetMngr(content, gDeviceMngr.GraphicsDevice);
        }

        public void update(GameTime gameTime)
        {
            deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            //display.updatePPS();

            stateMngr.updateStates();
        }

        public void draw(SpriteBatch spriteBatch, BasicEffect basicEffect)
        {
            gDeviceMngr.GraphicsDevice.Clear(Color.Black);

            stateMngr.drawState                                   ();
            display  .draw     (spriteBatch, basicEffect, deltaTime);
        }

        //----Related to Display------
        public void changeRes()
        {
            display.changeDisplay();
        }
    }

    //Allows for objects with ability to call update and draw calls from the game class.
    public abstract class RealmControl
    {
        public float     deltaTime = AR.deltaTime;

        public AssetMngr assetMngr = AR.assetMngr;
        public StateMngr stateMngr = AR.stateMngr;
        public SpaceMngr spaceMngr = AR.spaceMngr;

        public abstract void Update                                                ();
        public abstract void Draw  (SpriteBatch spriteBatch, BasicEffect basicEffect);
    }
}
