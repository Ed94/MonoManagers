//C#
using System                    ;
using System.Collections.Generic;
//Monogame
using Microsoft.Xna.Framework         ;
using Microsoft.Xna.Framework.Input   ;
using Microsoft.Xna.Framework.Graphics;
//Game
using Content                  ;
using Game_Namespace           ;
using AbstractRealm.Realm_Space;


namespace AbstractRealm.States
{
    class TestBill : RealmControl
    {
        public TestBill() {}

        public override void Update()
        {
            player.Update();

            if (Keyboard.GetState().IsKeyDown(Keys.PageUp))
            {
                assetMngr.unload();
                stateMngr.setCRTState(StateMngr.ARstate.TestTri);
            }
        }
        public override void Draw(SpriteBatch spriteBatch, BasicEffect basicEffect) {}
    }
}
