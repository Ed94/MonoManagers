using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractRealm.Mechanics
{
    public class BoundedShape
    {
        object boundThing;

        BoundedShape(Type shape, float size, Vector3 position)
        {
            if (shape == typeof(BoundingBox))
            {
                boundThing = new BoundingBox(Vector3.Zero, position);
            }

            if (shape == typeof(BoundingSphere))
            {
                boundThing = new BoundingSphere(Vector3.Zero, size);
            }
        }

        public void addBoundShape()
        {

        }

        public object getBoundThing()
        {
            return boundThing;
        }


    }
}
