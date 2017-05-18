//C#
using System;
//DIV
using AbstractRealm.Input;
using AbstractRealm.Assets;

namespace AbstractRealm.States
{
    public class StateMngr
    {
        public enum ARstate
        {
            Test_v1,
        }

        ARstate crtState;

        Test_v1       test_v1;


        public StateMngr()
        {
            crtState = ARstate.AR_Launch;                                    //Console.WriteLine("State manager created."+ "\n");
        }


        public void setCRTState(ARstate newState, AssetMngr assetMngr)
        {
            crtState = newState;

            assetMngr.unload();

            initalizeState();
        }

        public ARstate getCRTState()
        {
            return crtState;
        }

        //--------------------------------------------------------
        public void initalizeState()
        {
            switch (crtState)
            {
                case ARstate.Test_v1:
                    test_v1 = new Test_v1();
                    break;
            }
        }

        public void updateStates(InputMngr inputMngr)
        {
            switch (crtState)
            {
                case ARstate.Test_v1:
                    test_v1.Update(inputMngr);
                    break;
            }
        }

        public void drawState()
        {
            switch (crtState)
            {
                case ARstate.Test_v1:
                    test_v1.Draw();
                    break;
            }
        }
    }
}