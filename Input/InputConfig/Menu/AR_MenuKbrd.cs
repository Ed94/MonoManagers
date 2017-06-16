//Monogame
using Microsoft.Xna.Framework.Input;

namespace AbstractRealm.Input
{
    public class AR_MenuKbrd : genInputKbrd   //Example Input Config
    {
        //Public
        public AR_MenuKbrd(RegKbrd regKbrd) : base(regKbrd)
        {
            this.regKbrd = regKbrd;
        }

        public override bool checkInput(controls key)
        { 
            switch (key)
            {
                case controls.nullInput:
                    return false;
                case controls.pressUp      :
                    return checkPress(upKey   );
                case controls.pressLeft    :
                    return checkPress(leftKey );
                case controls.pressDown    :
                    return checkPress(downKey );
                case controls.pressRight   :
                    return checkPress(rightKey);
                case controls.holdUp       :
                    return checkHold (upKey   );
                case controls.holdLeft     :
                    return checkHold (leftKey );
                case controls.holdDown     :
                    return checkHold (downKey );
                case controls.holdRight    :
                    return checkHold (rightKey);
                case controls.pressTabRight:
                    return checkPress(tabRight);
                case controls.pressTabLeft :
                    return checkPress(tabLeft );
                case controls.pressEnter   :
                    return checkPress(enter   );
                case controls.pressBack    :
                    return checkPress(back    );
                case controls.pressEnd     :
                    return checkPress(endKey  );
                case controls.goTestTri    :
                    return checkPress(gotestTri);
            }
            return false;
        }

        //Private
        private Keys gotestTri = Keys.F7    ;
        private Keys tabRight  = Keys.E     ;
        private Keys tabLeft   = Keys.Q     ;
        private Keys enter     = Keys.Enter ;
        private Keys back      = Keys.Back  ;
        private Keys upKey     = Keys.W     ;
        private Keys leftKey   = Keys.A     ;
        private Keys downKey   = Keys.S     ;
        private Keys rightKey  = Keys.D     ;
        private Keys space     = Keys.Space ;
        private Keys endKey    = Keys.End   ;
    }
}
