//Monogame
using Microsoft.Xna.Framework.Graphics;
//DIV
using AbstractRealm.Realm_Space;
using Dreams_in_Vapor;
using Microsoft.Xna.Framework.Input;

namespace AbstractRealm.States
{
    public class TestTri : RealmControl
    {
        string Instructions = "Controls: " + "\n"
                                + "WASD Horizantal and Vertical Movement" + "\n"
                                + "Left shift and control for zooming in and out." + "\n"
                                + "Use arrow keys to rotate around.";

        Triangle triangle;

        public TestTri()
        {
            triangle = new Triangle();
        }

        public override void Update()
        {
            triangle.Update();

            if (Keyboard.GetState().IsKeyDown(Keys.PageDown))
            {
                assetMngr.unload();
                stateMngr.setCRTState(StateMngr.ARstate.TestBill);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Back))
            {
                assetMngr.unload();
                stateMngr.setCRTState(StateMngr.ARstate.AR_Intro);
            }
        }

        public override void Draw(SpriteBatch spriteBatch, BasicEffect basicEffect)
        {
            triangle.Draw(spriteBatch, basicEffect);
        }
    }
}