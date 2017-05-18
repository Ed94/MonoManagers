using AbstractRealm.Input;
using AbstractRealm.Interface;
using AbstractRealm.Options;
using AbstractRealm.Realm_Space;
using AbstractRealm.States;
using AbstractRealm.Assets;
using Game;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;

namespace AbstractRealm
{
    public partial class AR   //Startup Mangament Sector
    {
        static bool firstRun = checkFirstRun();   //Keeps information reguarding if this is the first time the program is run.

        private void checkAPISupport()   //Proposed way of checking api and changing binary to best one.
        {
            bool vulkan; bool openGL; bool directX;

            directX = false;
            openGL  = false;
            vulkan  = false;

            //Vulkan Goes first when its supported.
            if (openGL == true) { }
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
        {
            Console.WriteLine("Detecting if this is the first run of game client...");
            if (!System.IO.Directory.Exists(@"Users"))
            {
                Console.WriteLine("This is the first run." + "\n");
                return true;
            }
            else
            {
                return false;
            }
        }

        private void createUserPath()   //Makes the Users file directory.
        {
            string userPath = @"Users"; Console.WriteLine("Created a User folder." + "\n");

            System.IO.Directory.CreateDirectory(userPath);
        }

        public void setup(Game passGame, ContentManager passContent)
        {
            content = passContent;

            gDeviceMngr = new GraphicsDeviceManager(passGame);

            checkAPISupport();

            dreamer = passGame;

            if (firstRun == true)
            {
                createUserPath();
            }

            profileMngr = new ProfileMngr(); //Initalizes the profile manager.

            //Related to Options
            options = new StndOptions       ();   //Initalizes standard options.
            display = new Display(gDeviceMngr);   //Initalizes display  options.

            //Related to timing
            updateTiming();
        }

        public void initialize()  //Called in dreamer's iniitalize override function for the game class. Starts up all abstract realm realated managers (except Asset Manager).
        {
            inputMngr = new InputMngr();
            uiMngr    = new UiMngr   ();
            spaceMngr = new SpaceMngr();
            stateMngr = new StateMngr();

            stateMngr.setCRTState(StateMngr.ARstate.AR_Launch, assetMngr);
        }

        public void loadAssetMngr() //Initializes the abstract realm's manager for the game.
        {
            assetMngr = new AssetMngr(content, gDeviceMngr.GraphicsDevice);
        }
    }
}
