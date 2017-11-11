//C#
using System;
//Monogame
using Microsoft.Xna.Framework         ;
using Microsoft.Xna.Framework.Content ;
using Microsoft.Xna.Framework.Graphics;
//AbstractRealm
using Game                     ;
using AbstractRealm.Assets     ; 
using AbstractRealm.Input      ;
using AbstractRealm.Interface  ;
using AbstractRealm.Options    ;
using AbstractRealm.Realm_Space;
using AbstractRealm.States     ;


namespace AbstractRealm
{
    public partial class AR   //Startup Mangament Sector
    {
        //Public
        public void initialize()  //Called in dreamer's iniitalize override function for the game class. Starts up all abstract realm realated managers (except Asset Manager).
        {
            inputMngr = new InputMngr();
            uiMngr    = new UiMngr   ();
            spaceMngr = new SpaceMngr();
            stateMngr = new StateMngr();

            stateMngr.setCRTState(StateMngr.ARstate.AR_Launch, assetMngr);

            ulong rateToTicks = (ulong)10000000 / (ulong)AR.display.framerate; Console.WriteLine("ratetoTicks: " + rateToTicks);

            dreamer.TargetElapsedTime = new TimeSpan((long)rateToTicks);
            dreamer.IsFixedTimeStep   = true                           ;
        }

        public void loadAssetMngr() //Initializes the abstract realm's manager for the game.
        {
            assetMngr = new AssetMngr(content, gDeviceMngr.GraphicsDevice);

            assetMngr.gDevice.SamplerStates[0] = new SamplerState { Filter = TextureFilter.Anisotropic };   //Needs to be moved to diplay as a configurable option.
        }

        public void setup(Dreamer passdreamer, ContentManager passContent)
        {
            dreamer = passdreamer;
            content = passContent;

            content.RootDirectory = "Content";   //Console.WriteLine("Linked Monogame content manager to content directory." + "\n");

            gDeviceMngr = new GraphicsDeviceManager(dreamer);

            checkAPISupport();

            if (firstRun = checkFirstRun())
                createUserPath();
            
            profileMngr = new ProfileMngr(); //Initalizes the profile manager.

            //Related to Options
            options = new StndOptions           ();   //Initalizes standard options.
            display = new Display    (gDeviceMngr);   //Initalizes display  options.

            //Related to timing
            updateTiming();
        }

        //Private
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

        private bool checkOpenGL()
        {
            bool support = false;

            return support;
        }

        private bool checkFirstRun()   //Checks if this is the first time the program was run.
        {
            Console.WriteLine("Detecting if this is the first run of client...");
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

        private bool firstRun;   //Keeps information reguarding if this is the first time the program is run.
    }
}
