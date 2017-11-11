//AbstractRealm
using AbstractRealm.Input ;
using AbstractRealm.Assets;

namespace AbstractRealm.States
{
    public class StateMngr
    {
        public StateMngr()
        { crtState = ARstate.AR_Launch; }


        public void setCRTState(ARstate newState, AssetMngr assetMngr)
        {
            crtState = newState;

            assetMngr.unload();

            initalizeState();
        }

        public void initalizeState()
        {
            switch (crtState)
            {
                case ARstate.AR_Adventure :
                    arAdv        = new AR_Adventure ();
                    break;
                case ARstate.AR_Conception:
                    arConception = new AR_Conception();
                    break;
                case ARstate.AR_Continue  :
                    arContinue   = new AR_Continue  ();
                    break;
                case ARstate.AR_Launch     :
                    arLaunch      = new AR_Launch    ();
                    break;
                case ARstate.AR_Leave     :
                    arLeave      = new AR_Leave     ();
                    break;
                case ARstate.AR_Main      :
                    arMain       = new AR_Main      ();
                    break;
                case ARstate.AR_Profile   :
                    arProfile    = new AR_Profile   ();
                    break;
                case ARstate.AR_Start     :
                    arStart      = new AR_Start     ();
                    break;
                case ARstate.AR_Options   :
                    arOptions    = new AR_Options   ();
                    break;
                case ARstate.TestTri      :
                    testTri      = new TestTri      ();
                    break;
                case ARstate.TestBill     :
                    testBill     = new TestBill     ();
                    break;
                case ARstate.Test_v1      :
                    test_v1      = new Test_v1      ();
                    break;
            }
        }

        public void updateStates(InputMngr inputMngr)
        {
            switch (crtState)
            {
                case ARstate.AR_Adventure :
                    arAdv       .Update(inputMngr);
                    break;
                case ARstate.AR_Conception:
                    arConception.Update(inputMngr);
                    break;
                case ARstate.AR_Continue  :
                    arContinue  .Update(inputMngr);
                    break;
                case ARstate.AR_Launch    :
                    arLaunch     .Update(inputMngr);
                    break;
                case ARstate.AR_Leave     :
                    arLeave     .Update(inputMngr);
                    break;
                case ARstate.AR_Main      :
                    arMain      .Update(inputMngr);
                    break;
                case ARstate.AR_Profile   :
                    arProfile   .Update(inputMngr);
                    break;
                case ARstate.AR_Start     :
                    arStart     .Update(inputMngr);
                    break;
                case ARstate.AR_Options   :
                    arOptions   .Update(inputMngr);
                    break;
                case ARstate.TestTri      :
                    testTri     .Update(inputMngr);
                    break;
                case ARstate.TestBill     :
                    testBill    .Update(inputMngr);
                    break;
                case ARstate.Test_v1      :
                    test_v1     .Update(inputMngr);
                    break;
            }
        }

        public void drawState()
        {
            switch (crtState)
            {
                case ARstate.AR_Adventure :
                    arAdv       .Draw();
                    break;
                case ARstate.AR_Conception:
                    arConception.Draw();
                    break;
                case ARstate.AR_Continue  :
                    arContinue  .Draw();
                    break;
                case ARstate.AR_Launch     :
                    arLaunch     .Draw();
                    break;
                case ARstate.AR_Leave     :
                    arLeave     .Draw();
                    break;
                case ARstate.AR_Main      :
                    arMain      .Draw();
                    break;
                case ARstate.AR_Profile   :
                    arProfile   .Draw();
                    break;
                case ARstate.AR_Start     :
                    arStart     .Draw();
                    break;
                case ARstate.AR_Options   :
                    arOptions   .Draw();
                    break;
                case ARstate.TestTri      :
                    testTri     .Draw();
                    break;
                case ARstate.TestBill     :
                    testBill    .Draw();
                    break;
                case ARstate.Test_v1      :
                    test_v1     .Draw();
                    break;
            }
        }


        public enum ARstate
        {
            AR_Adventure    ,
            AR_Conception   ,
            AR_Continue     ,
            AR_Launch       ,
            AR_Leave        ,
            AR_Main         ,
            AR_Options      ,
            AR_Profile      ,
            AR_ProfileSelect,
            AR_Start        ,
            TestTri         ,
            TestBill        ,
            Test_v1         ,
        }

        public ARstate crtState { get; private set; }

        AR_Adventure  arAdv       ;
        AR_Conception arConception;
        AR_Continue   arContinue  ;
        AR_Launch     arLaunch    ;
        AR_Leave      arLeave     ;
        AR_Main       arMain      ;
        AR_Options    arOptions   ;
        AR_Profile    arProfile   ;
        AR_Start      arStart     ;
        TestTri       testTri     ;
        TestBill      testBill    ;
        Test_v1       test_v1     ;
    }
}