using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

using Game;
using Adventure.Player;
using AbstractRealm.Realm_Space;
using AbstractRealm.States;
using static AbstractRealm.Input.RegKbrd;
using static AbstractRealm.Input.InputMngr;
using AbstractRealm;

namespace AbstractRealm.Input
{
    public class AR_MenuKbrd
    {
        RegKbrd regKbrd;

        keys gotestTri = keys.F7 ;
        keys tabRight  = keys.E  ;
        keys tabLeft   = keys.Q  ;
        keys enter     = keys.En ;
        keys back      = keys.Bk ;
        keys upKey     = keys.W ;
        keys leftKey   = keys.A ;
        keys downKey   = keys.S ;
        keys rightKey  = keys.D ;
        keys space     = keys.sp;
        keys endKey    = keys.end;

        public AR_MenuKbrd(RegKbrd passedRegKbrd)
        {
            regKbrd = passedRegKbrd;
        }

        public bool checkInput(controls key)
        { 
            switch (key)
            {
                case controls.nullInput:
                    return false;
                case controls.pressUp      :
                    return checkPress(regKbrd.getInput(keyTime.p, upKey   ), regKbrd.getInput(keyTime.c, upKey   ));
                case controls.pressLeft    :
                    return checkPress(regKbrd.getInput(keyTime.p, leftKey ), regKbrd.getInput(keyTime.c, leftKey ));
                case controls.pressDown    :
                    return checkPress(regKbrd.getInput(keyTime.p, downKey ), regKbrd.getInput(keyTime.c, downKey ));
                case controls.pressRight   :
                    return checkPress(regKbrd.getInput(keyTime.p, rightKey), regKbrd.getInput(keyTime.c, rightKey));
                case controls.holdUp       :
                    return checkHold (regKbrd.getInput(keyTime.c, upKey   ));
                case controls.holdLeft     :
                    return checkHold (regKbrd.getInput(keyTime.c, leftKey ));
                case controls.holdDown     :
                    return checkHold (regKbrd.getInput(keyTime.c, downKey ));
                case controls.holdRight    :
                    return checkHold (regKbrd.getInput(keyTime.c, rightKey));
                case controls.pressTabRight:
                    return checkPress(regKbrd.getInput(keyTime.p, tabRight ), regKbrd.getInput(keyTime.c, tabRight ));
                case controls.pressTabLeft :
                    return checkPress(regKbrd.getInput(keyTime.p, tabLeft  ), regKbrd.getInput(keyTime.c, tabLeft  ));
                case controls.pressEnter   :
                    return checkPress(regKbrd.getInput(keyTime.p, enter    ), regKbrd.getInput(keyTime.c, enter    ));
                case controls.pressBack    :
                    return checkPress(regKbrd.getInput(keyTime.p, back     ), regKbrd.getInput(keyTime.c, back     ));
                case controls.pressEnd     :
                    return checkPress(regKbrd.getInput(keyTime.p, endKey   ), regKbrd.getInput(keyTime.c, endKey   ));
                case controls.goTestTri    :
                    return checkPress(regKbrd.getInput(keyTime.p, gotestTri), regKbrd.getInput(keyTime.c, gotestTri));
            }
            return false;
        }

        public static bool checkHold(bool current)
        {
            if   (current == true) { return true ; }
            else                   { return false; }
        }

        public static bool checkPress(bool past, bool current)
        {
            if   (past == false && current == true) { return true ; }
            else                                    { return false; }
        }

        

        
    }
}
