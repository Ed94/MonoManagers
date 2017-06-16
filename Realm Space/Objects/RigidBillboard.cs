//Monogame
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


namespace AbstractRealm.Realm_Space
{
    public class RigidBillboard
    {
        //Public
        public RigidBillboard(Texture2D passedTexture)
        {
            billTexture = passedTexture                                        ;
            resolution  = new Vector3(billTexture.Width, billTexture.Height, 0);

            createBillboardVertices(resolution);
        }


        public Vector3 getCenter(Vector3 size)
        { return new Vector3(size.X / 2, size.Y / 2, 0); }

        public void setSize(Vector3 size)
        { this.size = size; createBillboardVertices(size); }

        public Vector3 getSize()
        { return size; }

        public void setTexture(Texture2D texture)
        { billTexture = texture;
        }

        public void scaleBillboard(float scale)
        {
            this.scale = scale;

            for (int i = 0; i < 6; i++)
                rigidBillVert[i].Position = Vector3.Multiply(rigidBillVert[i].Position, scale);

            size = new Vector3(rigidBillVert[2].Position.X * 2, rigidBillVert[2].Position.Y * 2, 0);
        }

        public void moveBillboard(Vector3 displacement)
        {
            for (int i = 0; i < 6; i++)
                rigidBillVert[i].Position = rigidBillVert[i].Position + displacement;
        }

        public void setPosition(Vector3 position)
        {
            rigidBillVert[0].Position = new Vector3(size.X,      0, 0);   //Triangle 1
            rigidBillVert[1].Position = new Vector3(     0, size.Y, 0);
            rigidBillVert[2].Position = new Vector3(size.X, size.Y, 0);

            rigidBillVert[3].Position = new Vector3(     0, size.Y, 0);   //Triangle 2
            rigidBillVert[4].Position = new Vector3(size.X,      0, 0);
            rigidBillVert[5].Position = new Vector3(     0,      0, 0);

            Vector3 centerOffset = -getCenter(size);

            moveBillboard(centerOffset);

            for (int i = 0; i < 6; i++)
            {
                rigidBillVert[i].Position = rigidBillVert[i].Position + position;
            }
        }

        public void update()
        { vertbuffer.SetData(rigidBillVert); }

        public void draw(BasicEffect basicEffect)
        {
            basicEffect.Alpha              = 1.0f       ;
            basicEffect.VertexColorEnabled = false      ;
            basicEffect.TextureEnabled     = true       ;
            basicEffect.Texture            = billTexture;

            basicEffect.Projection = SpaceMngr.camPerception;
            basicEffect.View       = SpaceMngr.view         ;
            basicEffect.World      = SpaceMngr.area         ;

            AR.assetMngr.gDevice.SetVertexBuffer(vertbuffer);

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                AR.assetMngr.gDevice.DrawUserPrimitives(PrimitiveType.TriangleList, rigidBillVert, 0, 2);
            }
        }

        //Private
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

            vertbuffer = new VertexBuffer(AR.assetMngr.gDevice, typeof(VertexPositionTexture), 6, BufferUsage.None);
            vertbuffer.SetData(rigidBillVert);
        }


        private float scale;

        private Vector3                 resolution   ;
        private Vector3                 size         ;
        private VertexBuffer            vertbuffer   ;
        private VertexPositionTexture[] rigidBillVert;
        private Texture2D               billTexture  ;
    }
}