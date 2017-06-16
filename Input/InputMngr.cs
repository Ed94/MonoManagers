

namespace AbstractRealm.Input
{
    public enum controls   //A list of every possible input binding.
    {
        nullInput,

        pressUp, pressLeft, pressDown, pressRight,

        holdUp, holdLeft, holdDown, holdRight,

        pressUp2, pressDown2, pressLeft2, pressRight2,

        pressJump, holdJump,

        pressTabRight, pressTabLeft,

        pressEnter, pressBack,

        pressEnd, goTestTri,

        debug
    }

    public class InputMngr
    {
        //Public
        public InputMngr()
        {
            regKbrd = new RegKbrd();

            crtInputDevice = InputDevice.Kbrd       ;
            crtInputState  = InputState .AR_MenuKbrd;

            initalizeInput();
        }
        

        public void initalizeInput()
        { 
            switch (crtInputState)
            {
                case InputState.AR_MenuKbrd:
                    ar_MenuKbrd = new AR_MenuKbrd(regKbrd);
                    break;
                case InputState.debugKbrd  :
                    debugKbrd   = new debugKbrd  (regKbrd);
                    break;
                case InputState.playerKbrd :
                    playerKbrd  = new playerKbrd (regKbrd);
                    break;
            }
        }

        public bool checkInput(controls key)
        {
            switch (crtInputState)
            {
                case InputState.AR_MenuKbrd:
                    return ar_MenuKbrd.checkInput(key);
                case InputState.debugKbrd:
                    return debugKbrd  .checkInput(key);
                case InputState.playerKbrd:
                    return playerKbrd .checkInput(key);
            }

            return false;
        }

        public InputState getInputState()
        { return crtInputState; }

        public void changeInputState(InputState newState)
        { crtInputState = newState; initalizeInput(); }


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

        public enum InputDevice   //All compatible input devices
        {
            DInput,
            GC    ,
            Kbrd  ,
            PS4   ,
            PS3   ,
            SteamC,
            XInput,
        }

        public enum InputState   //Every possible input state of the game.
        {
            AR_MenuKbrd,
            debugKbrd  ,
            playerKbrd ,
        }

        InputDevice crtInputDevice;
        InputState  crtInputState ;

        AR_MenuKbrd ar_MenuKbrd;
        debugKbrd   debugKbrd  ;
        playerKbrd  playerKbrd ;
        RegKbrd     regKbrd    ;
    }
}