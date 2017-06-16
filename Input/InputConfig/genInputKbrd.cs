//C#
using System.Collections.Generic;
//Mongoame
using Microsoft.Xna.Framework.Input;


namespace AbstractRealm.Input
{
    public class genInputKbrd
    {
        //Public
        public genInputKbrd(RegKbrd regKbrd)
        {
            this.regKbrd = regKbrd;

            setupBinds(this);
        }

        public virtual bool checkInput(controls key)
        {
            return false;
        }

        public bool checkHold(Keys key)
        {
            if (regKbrd.getInput(keyTime.c, key)) { return true; }
            else { return false; }
        }

        public bool checkPress(Keys key)
        {
            if (!regKbrd.getInput(keyTime.p, key) && regKbrd.getInput(keyTime.c, key)) { return true; }
            else { return false; }
        }

        public virtual void setupBinds(object inputConfig)
        {
            binds = new Dictionary<string, Keys>();
        }

        //Protected
        protected RegKbrd                  regKbrd;
        protected Dictionary<string, Keys> binds  ;
    }
}
