//C#
using System.Collections.Generic;
//Monogame
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//DIV
using AbstractRealm.Assets;
using System;
using Microsoft.Xna.Framework.Input;
using Game;
using AbstractRealm.Input;

namespace AbstractRealm.Realm_Space
{
    public class RigidBillboard
    {
        float   scale     ;
        Vector3 resolution;
        Vector3 size      ;

        VertexPositionTexture[] rigidBillVert;
        VertexBuffer            vertbuffer   ;

        Texture2D billTexture;

        //Constructor
        public RigidBillboard(Texture2D passedTexture)
        {
            billTexture = passedTexture;

            resolution = new Vector3(billTexture.Width, billTexture.Height, 0);

            createBillboardVertices(resolution);
        }

        //Functions
        private void createBillboardVertices(Vector3 passedSize) //This does not work....
        {
            size = passedSize;

            rigidBillVert = new VertexPositionTexture[6];

            rigidBillVert[0].Position = new Vector3(size.X, 0     , 0);   //Triangle 1
            rigidBillVert[1].Position = new Vector3(     0, size.Y, 0);
            rigidBillVert[2].Position = new Vector3(size.X, size.Y, 0);

            rigidBillVert[3].Position = new Vector3(     0, size.Y, 0);   //Triangle 2
            rigidBillVert[4].Position = new Vector3(size.X, 0     , 0);
            rigidBillVert[5].Position = new Vector3(     0, 0     , 0);

            rigidBillVert[0].TextureCoordinate = new Vector2(0, 1);   //Triangle 1
            rigidBillVert[1].TextureCoordinate = new Vector2(1, 0);
            rigidBillVert[2].TextureCoordinate = new Vector2(0, 0);

            rigidBillVert[3].TextureCoordinate = new Vector2(1, 0);   //Triangle 2i
            rigidBillVert[4].TextureCoordinate = new Vector2(0, 1);
            rigidBillVert[5].TextureCoordinate = new Vector2(1, 1);

            Vector3 centerOffset = -getCenter(size);

            moveBillboard(centerOffset);

            vertbuffer = new VertexBuffer(AssetMngr.gDevice, typeof(VertexPositionTexture), 6, BufferUsage.None);
            vertbuffer.SetData(rigidBillVert);
        }

        public Vector3 getCenter(Vector3 size)
        {
            Vector3 center = new Vector3(size.X / 2, size.Y/ 2, 0);

            return center;
        }

        public void setSize(Vector3 passedSize)
        {
            size = passedSize;

            createBillboardVertices(size);
        }

        public Vector3 getSize()
        {
            return size;
        }

        public void setTexture(Texture2D newTexture)
        {
            billTexture = newTexture;
        }

        public void scaleBillboard(float passedScale)
        {
            scale = passedScale;

            for (int i = 0; i < 6; i++)
            {
                rigidBillVert[i].Position =  Vector3.Multiply  (rigidBillVert[i].Position, scale);
            }

            size = new Vector3(rigidBillVert[2].Position.X*2, rigidBillVert[2].Position.Y*2, 0);
        }

        public void moveBillboard(Vector3 displacement)
        {
           for (int i = 0; i < 6; i++)
            {
                rigidBillVert[i].Position = rigidBillVert[i].Position + displacement;
            }
        }

        public void setPosition(Vector3 position)
        {
            rigidBillVert[0].Position = new Vector3(size.X,      0, 0);   //Triangle 1
            rigidBillVert[1].Position = new Vector3(     0, size.Y, 0);
            rigidBillVert[2].Position = new Vector3(size.X, size.Y, 0);

            rigidBillVert[3].Position = new Vector3(     0, size.Y, 0);   //Triangle 2
            rigidBillVert[4].Position = new Vector3(size.X,      0, 0);
            rigidBillVert[5].Position = new Vector3(      0,     0, 0);

            Vector3 centerOffset = -getCenter(size);

            moveBillboard(centerOffset);

            for (int i = 0; i < 6; i++)
            {
                rigidBillVert[i].Position = rigidBillVert[i].Position + position;
            }
        }

        public void Update()
        {
            vertbuffer.SetData(rigidBillVert);
        }

        public void Draw(BasicEffect basicEffect)
        {
            basicEffect.Alpha              = 1.0f;
            basicEffect.VertexColorEnabled = false;
            basicEffect.TextureEnabled     = true;
            basicEffect.Texture            = billTexture;

            basicEffect.Projection = SpaceMngr.camPerception;
            basicEffect.View       = SpaceMngr.view;
            basicEffect.World      = SpaceMngr.area;

            AssetMngr.gDevice.SetVertexBuffer(vertbuffer);

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                AssetMngr.gDevice.DrawUserPrimitives(PrimitiveType.TriangleList, rigidBillVert, 0, 2);
            }
        }
    }
}