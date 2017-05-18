using AbstractRealm.States;
using System;
using System.Collections.Generic;

namespace AbstractRealm.Input
{
    public class InputMngr
    {
        public enum InputDevice
        {
            DInput,
            GC    ,
            Kbrd  ,
            PS4   ,
            PS3   ,
            SteamC,
            XInput,
        }

        public enum InputState
        {
            AR_MenuKbrd,
        }

        public enum controls
        {
            nullInput,
            pressUp,
            pressLeft,
            pressDown,
            pressRight,
            holdUp,
            holdLeft,
            holdDown,
            holdRight,
            pressTabRight,
            pressTabLeft,
            pressEnter,
            pressBack,
            pressEnd,
            goTestTri,
        }

        InputDevice crtInputDevice;
        InputState  crtInput      ;

        AR_MenuKbrd ar_MenuKbrd;
        RegKbrd     regKbrd    ;


        public InputMngr()
        {
            regKbrd = new RegKbrd();

            crtInputDevice = InputDevice.Kbrd       ;
            crtInput       = InputState .AR_MenuKbrd;

            initalizeInput();
        }

        public void initalizeInput()
        { 
            switch (crtInput)
            {
                case InputState.AR_MenuKbrd:
                    ar_MenuKbrd = new AR_MenuKbrd(regKbrd);
                    break;
            }
        }

        public bool checkInput(controls key)
        {
            switch (crtInput)
            {
                case InputState.AR_MenuKbrd:
                    return ar_MenuKbrd.checkInput(key);
            }
            return false;
        }

        public void poll()
        {
            switch (crtInputDevice)
            {
                case InputDevice.Kbrd:
                     regKbrd.poll();
                    break;
            }
        }

        public void clearPoll()
        {
            switch (crtInputDevice)
            {
                case InputDevice.Kbrd:
                    regKbrd.setPast();
                    break;
            }
        }
    }
}
