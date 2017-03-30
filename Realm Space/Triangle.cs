//Monogame
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
//DIV
using Content;
using System;

namespace AbstractRealm.Realm_Space
{
    class Triangle : RealmControl
    {
        VertexPositionColor[] triangleVertices;
        VertexBuffer          vertexBuffer    ;

        public Triangle()
        {
            Console.WriteLine("hi");
            //Create triangle
            triangleVertices    = new VertexPositionColor[3];
            triangleVertices[0] = new VertexPositionColor(new Vector3(  0,  20, 0), Color.White  );
            triangleVertices[1] = new VertexPositionColor(new Vector3(-20, -20, 0), Color.Gray   );
            triangleVertices[2] = new VertexPositionColor(new Vector3( 20, -20, 0), Color.DimGray);

            vertexBuffer = new VertexBuffer(AssetMngr.gDevice, typeof(VertexPositionColor), 3, BufferUsage.WriteOnly);

            vertexBuffer.SetData<VertexPositionColor>(triangleVertices);
        }

        public override void Update()
        {
            //Basic Hori and Vert
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                SpaceMngr.camPosition.X -= 1f;
                SpaceMngr.camTarget  .X -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                SpaceMngr.camPosition.X += 1f;
                SpaceMngr.camTarget  .X += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                SpaceMngr.camPosition.Y -= 1f;
                SpaceMngr.camTarget  .Y -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                SpaceMngr.camPosition.Y += 1f;
                SpaceMngr.camTarget  .Y += 1f;
            }

            //Rotation
            if (Keyboard.GetState().IsKeyDown(Keys.Right))
            {
                Matrix rotationMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(1f));
                SpaceMngr.camPosition = Vector3.Transform(SpaceMngr.camPosition, rotationMatrix);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))
            {
                Matrix rotationMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(-1f));
                SpaceMngr.camPosition = Vector3.Transform(SpaceMngr.camPosition, rotationMatrix);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up))
            {
                Matrix rotationMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(1f));
                SpaceMngr.camPosition = Vector3.Transform(SpaceMngr.camPosition, rotationMatrix);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))
            {
                Matrix rotationMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(-1f));
                SpaceMngr.camPosition = Vector3.Transform(SpaceMngr.camPosition, rotationMatrix);
            }

            //Zoom
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
            {
                SpaceMngr.camPosition.Z += 1f;
                SpaceMngr.camTarget.Z += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
            {
                SpaceMngr.camPosition.Z -= 1f;
                SpaceMngr.camTarget.Z -= 1f;
            }

            SpaceMngr.view = Matrix.CreateLookAt(SpaceMngr.camPosition, SpaceMngr.camTarget, Vector3.Up);
        }

        public override void Draw(SpriteBatch spriteBatch, BasicEffect basicEffect)
        {
            basicEffect.Alpha              = 1.0f ;
            basicEffect.TextureEnabled     = false;
            basicEffect.VertexColorEnabled = true ;
            basicEffect.LightingEnabled    = false;

            basicEffect.Projection = SpaceMngr.camPerception;
            basicEffect.View       = SpaceMngr.view         ;
            basicEffect.World      = SpaceMngr.area         ; 

            AssetMngr.gDevice.SetVertexBuffer(vertexBuffer);

            // Turn off backface culling
            RasterizerState rasterizerState = new RasterizerState();

            rasterizerState.CullMode = CullMode.None;
            //rasterizerState.FillMode = FillMode.WireFrame;

            AssetMngr.gDevice.RasterizerState = rasterizerState;

            foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
            {
                pass.Apply();
                AssetMngr.gDevice.DrawPrimitives(PrimitiveType.TriangleList, 0, 3);
            }
        }
    }
}
