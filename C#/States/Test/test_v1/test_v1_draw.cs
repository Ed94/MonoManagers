//C#
using System;
//Monogame
using Microsoft.Xna.Framework         ;
using Microsoft.Xna.Framework.Graphics;
//AbstractRealm
using AbstractRealm.Realm_Space;


namespace AbstractRealm.States
{
    public partial class Test_v1 : RealmControl
    {
        //Public
        public override void Draw()
        {
            if (viewBillboards)
                level.draw(assetMngr.basicEffect);

            fcb.Draw();

            if (viewBoundingShapes)
            {
                drawBoundingShapes(fallingBox, Color.Aqua);
                //drawSphere        (fcb.charSphere, Color.Red   );
                drawBoundingShapes(floor, Color.Yellow);
            }
        }

        //Private
        void drawBoundingShapes(BoundingBox passedBox, Color color)
        {
            assetMngr.basicEffect.Alpha              = 0.15f;
            assetMngr.basicEffect.TextureEnabled     = false;
            assetMngr.basicEffect.VertexColorEnabled = true ;
            assetMngr.basicEffect.LightingEnabled    = false;

            assetMngr.basicEffect.Projection = SpaceMngr.camPerception;
            assetMngr.basicEffect.View       = SpaceMngr.view         ;
            assetMngr.basicEffect.World      = SpaceMngr.area         ;

            VertexBuffer BoundingShapeBuffer;
            IndexBuffer  BoundingShapeIndex ;

            VertexPositionColor[] BoundingShapePos;

            BoundingShapePos = new VertexPositionColor[8];

            int corner = 0; foreach (Vector3 pos in passedBox.GetCorners())
            {
                BoundingShapePos[corner].Position = pos  ;
                BoundingShapePos[corner].Color    = color;

                corner++;
            }

            indices[ 0] = 0; indices[ 1] = 1; indices[ 2] = 2;
            indices[ 3] = 0; indices[ 4] = 2; indices[ 5] = 3;
            indices[ 6] = 0; indices[ 7] = 1; indices[ 8] = 4;
            indices[ 9] = 1; indices[10] = 4; indices[11] = 5;
            indices[12] = 1; indices[13] = 2; indices[14] = 5;
            indices[15] = 2; indices[16] = 5; indices[17] = 6;
            indices[18] = 5; indices[19] = 6; indices[20] = 7;
            indices[21] = 4; indices[22] = 5; indices[23] = 7;
            indices[24] = 3; indices[25] = 6; indices[26] = 7;
            indices[27] = 2; indices[28] = 3; indices[29] = 6;
            indices[30] = 3; indices[31] = 7; indices[32] = 4;
            indices[33] = 3; indices[34] = 4; indices[35] = 0;

            BoundingShapeBuffer = new VertexBuffer(assetMngr.gDevice, typeof(VertexPositionColor), 8, BufferUsage.WriteOnly);
            BoundingShapeBuffer.SetData<VertexPositionColor>(BoundingShapePos);

            BoundingShapeIndex = new IndexBuffer(assetMngr.gDevice, typeof(short), indices.Length, BufferUsage.WriteOnly);
            BoundingShapeIndex.SetData(indices);

            assetMngr.gDevice.SetVertexBuffer(BoundingShapeBuffer);

            foreach (EffectPass pass in assetMngr.basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                assetMngr.gDevice.DrawUserIndexedPrimitives(PrimitiveType.TriangleList, BoundingShapePos, 0, 8, indices, 0, 12);
            }
        }

        void drawSphere(BoundingSphere sphere, Color color)
        {
            assetMngr.basicEffect.Alpha              = 0.15f;
            assetMngr.basicEffect.TextureEnabled     = false;
            assetMngr.basicEffect.VertexColorEnabled = true ;
            assetMngr.basicEffect.LightingEnabled    = false;

            assetMngr.basicEffect.Projection = SpaceMngr.camPerception;
            assetMngr.basicEffect.View       = SpaceMngr.view         ;
            assetMngr.basicEffect.World      = SpaceMngr.area         ;

            VertexBuffer      BoundingShapeBuffer;

            ushort sphereResolution = 10000; 

            VertexPositionColor[] BoundingShapePos = new VertexPositionColor[ (sphereResolution + 1) * 3];

            uint index = 0;
            double pi  = 3.141592653589793238462643383279502884197169399375105820974944592307816406286208998628034825342117067982148086513282306647093844609550582231725359408128481117450284102701938521; //Accuracy!!!

            double twoPi = Math.Pow(pi, 2);
            double step  = twoPi / (double)sphereResolution;

            for (double a = 0f; a <= twoPi; a+= step)  //For the XY Plane
            {
                BoundingShapePos[index  ].Position = new Vector3((float)Math.Cos(a), (float)Math.Sin(a), 0f);
                BoundingShapePos[index  ].Position = Vector3.Multiply(BoundingShapePos[index].Position, sphere.Radius);
                BoundingShapePos[index  ].Position = Vector3.Add     (BoundingShapePos[index].Position, sphere.Center);
                BoundingShapePos[index++].Color    = color;
            }

            for (double a = 0f; a <= twoPi; a += step)   //XZ
            {
                BoundingShapePos[index  ].Position = new Vector3((float)Math.Cos(a), 0f, (float)Math.Sin(a));
                BoundingShapePos[index  ].Position = Vector3.Multiply(BoundingShapePos[index].Position, sphere.Radius);
                BoundingShapePos[index  ].Position = Vector3.Add     (BoundingShapePos[index].Position, sphere.Center);
                BoundingShapePos[index++].Color = color;
            }

            for (double a = 0f; a <= twoPi; a += step)   //YZ
            {
                BoundingShapePos[index  ].Position = new Vector3( 0f, (float)Math.Cos(a), (float)Math.Sin(a));
                BoundingShapePos[index  ].Position = Vector3.Multiply(BoundingShapePos[index].Position, sphere.Radius);
                BoundingShapePos[index  ].Position = Vector3.Add     (BoundingShapePos[index].Position, sphere.Center);
                BoundingShapePos[index++].Color = color;
            }

            BoundingShapeBuffer = new VertexBuffer(assetMngr.gDevice, typeof(VertexPositionColor), BoundingShapePos.Length, BufferUsage.WriteOnly);
            BoundingShapeBuffer.SetData(BoundingShapePos);

            foreach (EffectPass pass in assetMngr.basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();

                AR.assetMngr.gDevice.DrawUserPrimitives(PrimitiveType.LineList, BoundingShapePos, 0, sphereResolution+ (sphereResolution/3));
            }
        }

        short[] indices = new short[36];
    }
}