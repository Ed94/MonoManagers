//C#
using System.Collections.Generic;
//Monogame
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//BEPU
using BEPUphysics;
using BEPUphysics.CollisionShapes.ConvexShapes;
//AbstractRealm
using AbstractRealm.Assets;
using AbstractRealm.Realm_Space;


namespace AbstractRealm.Entities
{
    public class FCB : character   //Fourth City Boss Keeping in this as a test char.
    {
        //Public
        public FCB(Vector3 position, AssetMngr assetMngr) : base(position, assetMngr)
        {
            this.assetMngr = assetMngr;
            this.position  = position ;

            boundedBody = new BoundedBody();

            loadAssets();

            testSprite.scaleBillboard(SpaceMngr.scale / 5f);
            testSprite.setPosition   (position            );

            charSphere = new BoundingSphere(this.position, 20f);
        }

        public override void move(Vector3 tranlsationVal)
        {
            base.move(tranlsationVal);

            charSphere.Center = Vector3.Add(charSphere.Center, tranlsationVal);
        }

        public override void Draw()
        {
            testSprite.draw(assetMngr.basicEffect);
        }

        public BoundingSphere charSphere;

        //Protected
        protected override void loadAssets()   //Since no textures provided, replace asset keys with desired.
        {
            assetMngr.LoadResource("FCB_test.xnb");

            foreach (KeyValuePair<string, Texture2D> texture in AssetMngr.currentTextures)
            {
                if (texture.Key.Contains("FCB_test"))
                {
                    testSprite = new RigidBillboard(texture.Value);
                }
            }
        }
    }
}