//Monogame
using Microsoft.Xna.Framework.Graphics;
//DIV
using AbstractRealm.Realm_Space;
using Dreams_in_Vapor;
using Microsoft.Xna.Framework.Input;
using AbstractRealm.Input;
using System;
using AbstractRealm;
using Microsoft.Xna.Framework;

namespace AbstractRealm.States
{
    public class TestTri : RealmControl
    {
        string Instructions = "Controls: " + "\n"
                                + "WASD Horizantal and Vertical Movement" + "\n"
                                + "Left shift and control for zooming in and out." + "\n"
                                + "Use arrow keys to rotate around.";

        Triangle triangle;

        bool firstpass = true;

        public TestTri()
        {
            triangle = new Triangle();

            
        }

        public override void Update(InputMngr inputMngr)
        {
            //Basic Hori and Vert
            if (Keyboard.GetState().IsKeyDown(Keys.A))
            {
                SpaceMngr.camPosition.X -= 1f;
                SpaceMngr.camTarget.X -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.D))
            {
                SpaceMngr.camPosition.X += 1f;
                SpaceMngr.camTarget.X += 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.W))
            {
                SpaceMngr.camPosition.Y -= 1f;
                SpaceMngr.camTarget.Y -= 1f;
            }
            if (Keyboard.GetState().IsKeyDown(Keys.S))
            {
                SpaceMngr.camPosition.Y += 1f;
                SpaceMngr.camTarget.Y += 1f;
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


            //Scene Changing
            if (Keyboard.GetState().IsKeyDown(Keys.PageDown))
            {
                stateMngr.setCRTState(States.StateMngr.ARstate.AR_Launch, assetMngr);
            }
         }

        public override void Draw()
        {
            triangle.Draw(assetMngr.basicEffect);
        }
    }
}