//Monogame
using Microsoft.Xna.Framework.Input;

namespace AbstractRealm.Input
{
    public class playerKbrd : genInputKbrd   //Expample Input Config
    {
        //Public
        public playerKbrd(RegKbrd regKbrd) : base(regKbrd)
        {
            this.regKbrd = regKbrd;
        }


        public override bool checkInput(controls key)
        {
            switch (key)
            {
                case controls.debug:
                    return checkPress(debug  );
                case controls.holdRight:
                    return checkHold (mvRight);
                case controls.holdLeft :
                    return checkHold (mvLeft );
            }
            return false;
        }

        //Private
        private Keys debug   = Keys.F2   ;
        private Keys enter   = Keys.Enter;
        private Keys pause   = Keys.Back ;
        private Keys mvLeft  = Keys.A    ;
        private Keys mvRight = Keys.D    ;
        private Keys jump    = Keys.Space;
    }
}