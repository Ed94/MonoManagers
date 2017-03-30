//C#
using System;
//DIV
using Content;


namespace AbstractRealm.States
{
    public class StateMngr
    {
        public enum ARstate
        {
            TestTri      ,
            TestBill     ,
        }

        ARstate crtState;

        TestTri       testTri     ;
        TestBill      testBill    ;

        public StateMngr()
        {
            crtState = ARstate.testTri                                    Console.WriteLine("State manager created."+ "\n");

            initalizeState();
        }

        public void initalizeState()
        {
            switch (crtState)
            {
                case ARstate.TestTri      :
                    testTri      = new TestTri      ();
                    break;
                case ARstate.TestBill     :
                    testBill     = new TestBill();
                    break;
            }
        }

        public void updateStates()
        {
            switch (crtState)
            {
                case ARstate.TestTri      :
                    testTri     .Update();
                    break;
                case ARstate.TestBill     :
                    testBill    .Update();
                    break;
            }
        }

        public void drawState()
        {
            switch (crtState)
            {
                case ARstate.TestTri      :
                    testTri     .Draw(AssetMngr.spriteBatch, AssetMngr.basicEffect);
                    break;
                case ARstate.TestBill     :
                    testBill    .Draw(AssetMngr.spriteBatch, AssetMngr.basicEffect);
                    break;
            }
        }

        public void setCRTState(ARstate newState)
        {
            crtState = newState;

            initalizeState();
        }
    }
}
