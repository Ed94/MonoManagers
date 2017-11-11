//C#
using System;
//Monogame
using Microsoft.Xna.Framework        ;
using Microsoft.Xna.Framework.Content;
//AbstractRealm
using Game                     ;
using AbstractRealm            ;
using AbstractRealm.Assets     ;
using AbstractRealm.Input      ;
using AbstractRealm.Interface  ;
using AbstractRealm.Options    ;
using AbstractRealm.Realm_Space;
using AbstractRealm.States     ;


namespace AbstractRealm
{
    public partial class AR   //Abstract Realm Core Class       
    {
        //Public
        public AR()
        {
            Console.WriteLine("AR created.");
        }

        public GraphicsDeviceManager gDeviceMngr;   //Graphics managment related to monogame.


        //Private
        private GIni           gIni   ;   //Passed Game override class for div.
        private ContentManager content;   //Base content managment for monogame.
    }


    public abstract class RealmControl  //Allows for objects with ability to call update and draw calls from the game class.
    {
        public RealmControl()
        {
            deltaTime = AR.deltaTime;

            assetMngr   = AR.assetMngr  ;
            inputMngr   = AR.inputMngr  ;
            profileMngr = AR.profileMngr;
            spaceMngr   = AR.spaceMngr  ;
            stateMngr   = AR.stateMngr  ;
            uiMngr      = AR.uiMngr     ;

            options = AR.options;
            display = AR.display;
        }

        //Functions
        public abstract void Update(InputMngr inputMngr);
        public abstract void Draw                     ();

        //Vars
        public float deltaTime;

        public AssetMngr   assetMngr  ;
        public InputMngr   inputMngr  ;
        public ProfileMngr profileMngr;
        public SpaceMngr   spaceMngr  ;
        public StateMngr   stateMngr  ;
        public UiMngr      uiMngr     ;

        public StndOptions options;
        public Display     display;
    }
}