//C#
using System;
//Monogame
using Microsoft.Xna.Framework.Graphics;
//DIV
using AbstractRealm.Realm_Space;
using Microsoft.Xna.Framework;
using Dreams_in_Vapor;
using Microsoft.Xna.Framework.Input;
using Content;
using System.Collections.Generic;

namespace AbstractRealm.States
{
    class TestBill : RealmControl
    {
        Vector3 playerPosition ;
        Vector3 conceptPosition;

        RigidBillboard player       ;
        RigidBillboard concept_level;

        Texture2D femaleIdle    ;
        Texture2D conceptTexture;

        public TestBill()
        {
            assetMngr.LoadStateResource("no_clothes");
            assetMngr.LoadStateResource("slum"      );

            foreach (KeyValuePair<string, Texture2D> texture in AssetMngr.currentTextures)
            {
                if (texture.Key.Contains("f_idleTexture"))
                {

                }
                else if (texture.Key.Contains("f_idle"))
                {
                    femaleIdle = texture.Value;
                }

                if (texture.Key.Contains("concept"))
                {
                    conceptTexture = texture.Value;
                }
            }

            Vector3 femaleSize = new Vector3(  52, 188, 0);
            Vector3 bkSize     = new Vector3(1780, 977, 0);

            playerPosition  = Vector3.Zero;
            conceptPosition = bkSize / 8  ;

            player        = new RigidBillboard(femaleIdle          , Vector3.Zero   , Vector3.Multiply(femaleSize, 0.25f));
            concept_level = new RigidBillboard(conceptTexture   , conceptPosition,     Vector3.Multiply(bkSize, 0.25f));
        }

        public override void Update()
        {
            player.Update();

            if (Keyboard.GetState().IsKeyDown(Keys.PageUp))
            {
                assetMngr.unload();
                stateMngr.setCRTState(StateMngr.ARstate.TestTri);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, BasicEffect basicEffect)
        {
            concept_level.Draw(spriteBatch, basicEffect);
            player       .Draw(spriteBatch, basicEffect);
        }
    }
}
