using AbstractRealm.Mechanics;
using AbstractRealm.Realm_Space;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRealm.Entities
{
    public class character
    {
        protected Vector3        position   ;
        protected BoundedBody    boundedBody;
        protected RigidBillboard testSprite ;

        public class BoundedBody
        {
            Dictionary<string, BoundedShape> boundedParts;

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
        }

        public character(Vector3 passedPos)
        {
            position = passedPos;

            boundedBody = new BoundedBody();
        }


        protected void move(Vector3 tranlsationVal)
        {
            position = Vector3.Add(position, tranlsationVal);

            //boundedBody.translate() allow for translation of bounded object.
        }
    }
}
