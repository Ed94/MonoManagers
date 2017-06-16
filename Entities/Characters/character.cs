//C#
using System.Collections.Generic;
//Monogame
using Microsoft.Xna.Framework;
//AbstractRealm
using AbstractRealm.Assets     ;
using AbstractRealm.Mechanics  ;
using AbstractRealm.Realm_Space;


namespace AbstractRealm.Entities
{
    public class character 
    {
        //Public
        public character(Vector3 position, AssetMngr assetMngr)
        {
            this.position = position;

            boundedBody = new BoundedBody();
        }


        public class BoundedBody
        {
            //Public
            public BoundedBody()
            {
                boundedParts = new Dictionary<string, BoundedShape>();
            }


            public void addPart(string name, BoundedShape boundedShape)
            {
                boundedParts.Add(name, boundedShape);
            }

            public void translate(Vector3 translationVal)
            {
                foreach (KeyValuePair<string, BoundedShape> part in boundedParts)
                {
                    if (part.GetType() == typeof(BoundingBox))
                    {

                    }
                    if (part.GetType() == typeof(BoundingSphere))
                    {

                    }
                }
            }

            //Private
            private Dictionary<string, BoundedShape> boundedParts;
        }


        public virtual void move(Vector3 tranlsationVal)
        {
            position = Vector3.Add(position, tranlsationVal);

            testSprite.setPosition(position);

            //boundedBody.translate() allow for translation of bounded object.
        }

        public virtual void Update() { }
        public virtual void Draw  () { }

        //Protected
        protected virtual void loadAssets() { }

        protected AssetMngr      assetMngr  ;
        protected BoundedBody    boundedBody;
        protected RigidBillboard testSprite ;
        protected Vector3        position   ;
    }
}