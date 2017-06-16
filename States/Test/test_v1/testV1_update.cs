//Monogame
using Microsoft.Xna.Framework      ;
using Microsoft.Xna.Framework.Input;
//AbstractRealm
using AbstractRealm.Input      ;
using AbstractRealm.Realm_Space;


namespace AbstractRealm.States
{
    public partial class Test_v1 : RealmControl
    {
        public override void Update(InputMngr inputMngr)
        {
            if      (fcb.charSphere.Intersects(fallingBox) == true) { }
            else if (fcb.charSphere.Intersects(floor     ) == true) { }
            else
                fcb.move(new Vector3(0, -0.01f, 0));

            //Need to make a generic player input checking system.
            if (inputMngr.getInputState() == InputMngr.InputState.playerKbrd)
            {
                if (inputMngr.checkInput(controls.holdRight))
                    fcb.move(new Vector3(-0.1f, 0, 0));

                if (inputMngr.checkInput(controls.holdLeft))
                    fcb.move(new Vector3(0.1f, 0, 0));

                if (inputMngr.checkInput(controls.pressJump))
                    fcb.move(new Vector3(0, 1f, 0));

                if (inputMngr.checkInput(controls.debug))
                    inputMngr.changeInputState(InputMngr.InputState.debugKbrd);
            }

            //Taken from Triangle class need to make proper
            else if (inputMngr.getInputState().Equals(InputMngr.InputState.debugKbrd))
            {
                //Basic Hori and Vert
                if (Keyboard.GetState().IsKeyDown(Keys.A))
                {
                    SpaceMngr.camPosition.X -= 0.1f;
                    SpaceMngr.camTarget.X -= 0.1f;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.D))
                {
                    SpaceMngr.camPosition.X += 0.1f;
                    SpaceMngr.camTarget.X += 0.1f;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.W))
                {
                    SpaceMngr.camPosition.Y -= 0.1f;
                    SpaceMngr.camTarget.Y -= 0.1f;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.S))
                {
                    SpaceMngr.camPosition.Y += 0.1f;
                    SpaceMngr.camTarget.Y += 0.1f;
                }

                //Rotation
                if (Keyboard.GetState().IsKeyDown(Keys.Right))
                {
                    Matrix rotationMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(0.1f));
                    SpaceMngr.camPosition = Vector3.Transform(SpaceMngr.camPosition, rotationMatrix);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Left))
                {
                    Matrix rotationMatrix = Matrix.CreateRotationY(MathHelper.ToRadians(-0.1f));
                    SpaceMngr.camPosition = Vector3.Transform(SpaceMngr.camPosition, rotationMatrix);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Up))
                {
                    Matrix rotationMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(0.1f));
                    SpaceMngr.camPosition = Vector3.Transform(SpaceMngr.camPosition, rotationMatrix);
                }
                if (Keyboard.GetState().IsKeyDown(Keys.Down))
                {
                    Matrix rotationMatrix = Matrix.CreateRotationX(MathHelper.ToRadians(-0.1f));
                    SpaceMngr.camPosition = Vector3.Transform(SpaceMngr.camPosition, rotationMatrix);
                }

                //Zoom
                if (Keyboard.GetState().IsKeyDown(Keys.LeftShift))
                {
                    SpaceMngr.camPosition.Z += 0.1f;
                    SpaceMngr.camTarget.Z += 0.1f;
                }
                if (Keyboard.GetState().IsKeyDown(Keys.LeftControl))
                {
                    SpaceMngr.camPosition.Z -= 0.1f;
                    SpaceMngr.camTarget.Z -= 0.1f;
                }

                SpaceMngr.view = Matrix.CreateLookAt(SpaceMngr.camPosition, SpaceMngr.camTarget, Vector3.Up);

                if (inputMngr.checkInput(controls.debug))
                    inputMngr.changeInputState(InputMngr.InputState.playerKbrd);

                if (inputMngr.checkInput(controls.pressBack))
                    toogleBillboard();

                if (inputMngr.checkInput(controls.pressEnter))
                    toogleBoundingShapes();

                spaceMngr.camera   .Update(deltaTime);
                spaceMngr.spacetest.Update         ();
            }
        }

        //Private
        void toogleBillboard()
        {
            if      (viewBillboards == false)
                viewBillboards = true ;
            else if (viewBillboards == true )
                viewBillboards = false;
        }

        void toogleBoundingShapes()
        {
            if      (viewBoundingShapes == false)
                viewBoundingShapes = true ;
            else if (viewBoundingShapes == true )
                viewBoundingShapes = false;
        }


        bool viewBillboards     = true;
        bool viewBoundingShapes = true;
    }
}
