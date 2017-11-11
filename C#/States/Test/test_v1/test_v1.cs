//C#
using System.Collections.Generic;
//Monogame Framework
using Microsoft.Xna.Framework.Graphics;
//BEPU
using BEPUphysics.Entities.Prefabs;
//AbstractRealm
using AbstractRealm.Assets     ;
using AbstractRealm.Realm_Space;
using AbstractRealm.Entities   ;


namespace AbstractRealm.States
{
    public partial class Test_v1 : RealmControl   //Mechanics testing class.
    {
        //Public
        public Test_v1()
        {
            loadAssets();
            setupLevel();
        }

        //Private
        void loadAssets()
        {
            assetMngr.LoadStateResource("test");

            foreach (KeyValuePair<string, Texture2D> texture in AssetMngr.currentTextures)
            {
                if (texture.Key.Contains("Initial"))
                    levelTexture = texture.Value;
            }
        }

        void setupLevel()
        {
            //Objs
            level = new RigidBillboard(levelTexture);

            level.moveBillboard (new Microsoft.Xna.Framework.Vector3(0, 0, 60));
            level.scaleBillboard(SpaceMngr.scale / 6f                         );

            //floor      = new BoundingBox   (new Vector3(80, -50, 50), new Vector3(-80, -30, -50));
            //fallingBox = new BoundingBox   (new Vector3(10, -40, 10), new Vector3(-10,  30, -10));
            //testSphere = new BoundingSphere(new Vector3( 0,   0,  0), 25                        );

            floorTest = new Box(BEPUutilities.Vector3.Zero, 100, 20, 20);

            spaceMngr.spacetest.Add(floorTest); 

            fcb = new FCB(new Microsoft.Xna.Framework.Vector3(50, 30, 0), assetMngr);

            inputMngr.changeInputState(Input.InputMngr.InputState.playerKbrd);
        }


        FCB fcb;

        RigidBillboard level; Texture2D levelTexture;

        Microsoft.Xna.Framework.BoundingBox    floor     ;   //See if you can change these to use bepu later...
        Microsoft.Xna.Framework.BoundingBox    fallingBox;
        Microsoft.Xna.Framework.BoundingSphere testSphere;

        Box floorTest;
    }
}