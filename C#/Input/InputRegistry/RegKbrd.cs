//C#
using System;
//Monogame
using Microsoft.Xna.Framework.Input;

namespace AbstractRealm.Input
{
    public enum keyTime { p, c }

    public class RegKbrd
    {
        //Public
        public RegKbrd() { keyStatePrev = new KeyboardState(); keyStateCurr = new KeyboardState(); }

        public void poll()
        { keyStateCurr = Keyboard.GetState(); }

        public void setPast()
        { keyStatePrev = keyStateCurr; }

        public bool getInput(keyTime passedTime, Keys key)
        {
            if (passedTime == keyTime.p)
                return keyStatePrev.IsKeyDown(key);
            if (passedTime == keyTime.c)
                return keyStateCurr.IsKeyDown(key);
            else
            { Console.WriteLine("RegKbrd: Something went wrong."); return false; }
        }

        public KeyboardState keyStatePrev;
        public KeyboardState keyStateCurr;
    }
}