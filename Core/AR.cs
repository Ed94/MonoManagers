//C#

//Monogame
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
//DIV
using Game;
using AbstractRealm.Input;
using AbstractRealm.Options;
using AbstractRealm.Realm_Space;
using AbstractRealm.States;
using AbstractRealm.Interface;
using AbstractRealm.Assets;
using System;

namespace AbstractRealm
{
    public partial class AR   //Abstract Realm Core Class       
    {
        //Vars and Objects
        private Game game;   //Passed Game override class for div.

        private ContentManager            content;   //Base content managment for monogame.
        public  GraphicsDeviceManager gDeviceMngr;   //Graphics managment related to monogame.

        //Constructors
        public AR()
        {
            Console.WriteLine("AR created.");
        }
    }


    public abstract class RealmControl  //Allows for objects with ability to call update and draw calls from the game class.
    {
        public AssetMngr assetMngr;
        public InputMngr inputMngr;
        public UiMngr    uiMngr   ;
        public SpaceMngr spaceMngr;
        public StateMngr stateMngr;

        public ProfileMngr profileMngr;

        public StndOptions options;
        public Display     display;

        public RealmControl()
        { 
            assetMngr = AR.assetMngr;
            inputMngr = AR.inputMngr;
            uiMngr    = AR.uiMngr   ;
            spaceMngr = AR.spaceMngr;
            stateMngr = AR.stateMngr;

            profileMngr = AR.profileMngr;

            options = AR.options;
            display = AR.display;
        }

        public abstract void Update(InputMngr inputMngr);
        public abstract void Draw                     ();
    }
}
