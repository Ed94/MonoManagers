//Monogame
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//DIV
using AbstractRealm.Assets;
using System;
using AbstractRealm.Input;

namespace AbstractRealm.Realm_Space
{
    class Triangle
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

        public void Update(InputMngr inputMngr)
        {
            
        }

        public void Draw(BasicEffect basicEffect)
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
