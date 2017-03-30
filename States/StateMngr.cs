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
            AR_Adventure ,
            AR_Conception,
            AR_Continue  ,
            AR_Intro     ,
            AR_Leave     ,
            AR_Main      ,
            AR_Options   ,
            AR_Profile   ,
            AR_Start     ,
            TestTri      ,
            TestBill     ,
        }

        ARstate crtState;

        AR_Adventure  arAdv       ;
        AR_Conception arConception;
        AR_Continue   arContinue  ;
        AR_Intro      arIntro     ;
        AR_Leave      arLeave     ;
        AR_Main       arMain      ;
        AR_Options    arOptions   ;   
        AR_Profile    arProfile   ;   //May just be put into options dunno yet.
        AR_Start      arStart     ;
        TestTri       testTri     ;
        TestBill      testBill    ;

        public StateMngr()
        {
            crtState = ARstate.AR_Intro;                                    Console.WriteLine("State manager created."+ "\n");

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
                case ARstate.AR_Intro     :
                    arIntro      = new AR_Intro     ();
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
                    testBill     = new TestBill();
                    break;
                
            }
        }

        public void updateStates()
        {
            switch (crtState)
            {
                case ARstate.AR_Adventure :
                    arAdv       .Update();
                    break;
                case ARstate.AR_Conception:
                    arConception.Update();
                    break;
                case ARstate.AR_Continue  :
                    arContinue  .Update();
                    break;
                case ARstate.AR_Intro     :
                    arIntro     .Update();
                    break;
                case ARstate.AR_Leave     :
                    arLeave     .Update();
                    break;
                case ARstate.AR_Main      :
                    arMain      .Update();
                    break;
                case ARstate.AR_Profile   :
                    arProfile   .Update();
                    break;
                case ARstate.AR_Start     :
                    arStart     .Update();
                    break;
                case ARstate.AR_Options   :
                    arOptions   .Update();
                    break;
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
                case ARstate.AR_Adventure :
                    arAdv       .Draw(AssetMngr.spriteBatch, AssetMngr.basicEffect);
                    break;
                case ARstate.AR_Conception:
                    arConception.Draw(AssetMngr.spriteBatch, AssetMngr.basicEffect);
                    break;
                case ARstate.AR_Continue  :
                    arContinue  .Draw(AssetMngr.spriteBatch, AssetMngr.basicEffect);
                    break;
                case ARstate.AR_Intro     :
                    arIntro     .Draw(AssetMngr.spriteBatch, AssetMngr.basicEffect);
                    break;
                case ARstate.AR_Leave     :
                    arLeave     .Draw(AssetMngr.spriteBatch, AssetMngr.basicEffect);
                    break;
                case ARstate.AR_Main      :
                    arMain      .Draw(AssetMngr.spriteBatch, AssetMngr.basicEffect);
                    break;
                case ARstate.AR_Profile   :
                    arProfile   .Draw(AssetMngr.spriteBatch, AssetMngr.basicEffect);
                    break;
                case ARstate.AR_Start     :
                    arStart     .Draw(AssetMngr.spriteBatch, AssetMngr.basicEffect);
                    break;
                case ARstate.AR_Options   :
                    arOptions   .Draw(AssetMngr.spriteBatch, AssetMngr.basicEffect);
                    break;
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