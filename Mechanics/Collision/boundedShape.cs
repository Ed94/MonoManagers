//C#
using System;
//Monogame
using Microsoft.Xna.Framework;


namespace AbstractRealm.Mechanics
{
    public class BoundedShape
    {
        //Public
        public BoundedShape(Type shape, float size, Vector3 position)
        {
            if (shape == typeof(BoundingBox   ))
                boundThing = new BoundingBox   (Vector3.Zero, position);
            if (shape == typeof(BoundingSphere))
                boundThing = new BoundingSphere(Vector3.Zero, size    );
        }

        public void addBoundShape()
        { }

        public object getBoundThing()
        { return boundThing; }

        //Private
        private object boundThing;
    }
}
