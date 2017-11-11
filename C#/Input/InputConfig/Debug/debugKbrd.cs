//Monogame
using Microsoft.Xna.Framework.Input;

namespace AbstractRealm.Input
{
    public class debugKbrd : genInputKbrd   //Example Input Config
    {
        //Public
        public debugKbrd(RegKbrd regKbrd) : base(regKbrd) 
        {
            this.regKbrd = regKbrd;
        }

        public override bool checkInput(controls key)
        {
            switch (key)
            {
                case controls.debug:
                    return checkPress(debug);
                case controls.pressBack:
                    return checkPress(back );
                case controls.pressEnter:
                    return checkPress(enter);
            }
            return false;
        }

        //Private
        private Keys debug = Keys.F2     ;
        private Keys enter = Keys.Enter  ;
        private Keys back  = Keys.Back   ;
        private Keys menu  = Keys.F12    ;
        private Keys camU  = Keys.NumPad8;
        private Keys camD  = Keys.NumPad2;
        private Keys camR  = Keys.NumPad6;
        private Keys camL  = Keys.NumPad4;
        private Keys LTT   = Keys.F7     ;
    }
}