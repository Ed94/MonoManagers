using System;
using Microsoft.Xna.Framework.Input;

namespace AbstractRealm.Input
{
    public class RegKbrd
    {
        bool p_0 = false; bool c_0 = false;
        bool p_1 = false; bool c_1 = false;
        bool p_2 = false; bool c_2 = false;
        bool p_3 = false; bool c_3 = false;
        bool p_4 = false; bool c_4 = false;
        bool p_5 = false; bool c_5 = false;
        bool p_6 = false; bool c_6 = false;
        bool p_7 = false; bool c_7 = false;
        bool p_8 = false; bool c_8 = false;
        bool p_9 = false; bool c_9 = false;
        bool p_A = false; bool c_A = false;
        bool p_B = false; bool c_B = false;
        bool p_C = false; bool c_C = false;
        bool p_D = false; bool c_D = false;
        bool p_E = false; bool c_E = false;
        bool p_F = false; bool c_F = false;
        bool p_G = false; bool c_G = false;
        bool p_H = false; bool c_H = false;
        bool p_I = false; bool c_I = false;
        bool p_J = false; bool c_J = false;
        bool p_K = false; bool c_K = false;
        bool p_L = false; bool c_L = false;
        bool p_M = false; bool c_M = false;
        bool p_N = false; bool c_N = false;
        bool p_O = false; bool c_O = false;
        bool p_P = false; bool c_P = false;
        bool p_Q = false; bool c_Q = false;
        bool p_R = false; bool c_R = false;
        bool p_S = false; bool c_S = false;
        bool p_T = false; bool c_T = false;
        bool p_U = false; bool c_U = false;
        bool p_V = false; bool c_V = false;
        bool p_W = false; bool c_W = false;
        bool p_X = false; bool c_X = false;
        bool p_Y = false; bool c_Y = false;
        bool p_Z = false; bool c_Z = false;
        bool p_sp = false; bool c_sp = false;
        bool p_En = false; bool c_En = false;
        bool p_Bk = false; bool c_Bk = false;
        bool p_LS = false; bool c_LS = false;
        bool p_LC = false; bool c_LC = false;
        bool p_LA = false; bool c_LA = false;
        bool p_F1  = false; bool c_F1  = false;
        bool p_F2  = false; bool c_F2  = false;
        bool p_F3  = false; bool c_F3  = false;
        bool p_F4  = false; bool c_F4  = false;
        bool p_F5  = false; bool c_F5  = false;
        bool p_F6  = false; bool c_F6  = false;
        bool p_F7  = false; bool c_F7  = false;
        bool p_F8  = false; bool c_F8  = false;
        bool p_F9  = false; bool c_F9  = false;
        bool p_F10 = false; bool c_F10 = false;
        bool p_F11 = false; bool c_F11 = false;
        bool p_F12 = false; bool c_F12 = false;
        bool p_uA = false; bool c_uA = false;
        bool p_lA = false; bool c_lA = false;
        bool p_dA = false; bool c_dA = false;
        bool p_rA = false; bool c_rA = false;
        bool p_end  = false; bool c_end  = false;
        bool p_PgUp = false; bool c_PgUp = false;
        bool p_PgDn = false; bool c_PgDn = false;

        public enum keyTime { p, c }

        public enum keys
        {
            zero , one  , two  , three, four , five , six  , seven, eight, nine , ten  ,
            A , B , C , D , E , F , G , H , I , J , K , L , M ,
            N , O , P , Q , R , S , T , U , V , W , X , Y , Z ,
            sp, En, Bk, LS, LC, LA,
            F1 , F2 , F3 , F4 , F5 , F6 ,
            F7 , F8 , F9 , F10, F11, F12,
            uA, lA, dA, rA,
            end , PgUp, PgDn,
        }

        keyTime time  = new keyTime();
        keys    key   = new keys  ();
        
        
        public RegKbrd() {}

        public void poll()
        {
            if (Keyboard.GetState().IsKeyDown(Keys.D0)) { c_0 = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.D1)) { c_1 = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.D2)) { c_2 = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.D3)) { c_3 = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.D4)) { c_4 = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.D5)) { c_5 = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.D6)) { c_6 = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.D7)) { c_7 = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.D8)) { c_8 = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.D9)) { c_9 = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.A )) { c_A = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.B )) { c_B = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.C )) { c_C = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.D )) { c_D = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.E )) { c_E = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.F )) { c_F = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.G )) { c_G = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.H )) { c_H = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.I )) { c_I = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.J )) { c_J = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.K )) { c_K = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.L )) { c_L = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.M )) { c_M = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.N )) { c_N = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.O )) { c_O = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.P )) { c_P = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.Q )) { c_Q = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.R )) { c_R = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.S )) { c_S = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.T )) { c_T = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.U )) { c_U = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.V )) { c_V = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.W )) { c_W = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.X )) { c_X = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.Y )) { c_Y = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.Z )) { c_Z = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.Space      )) { c_sp = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.Enter      )) { c_En = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.Back       )) { c_Bk = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.LeftShift  )) { c_LS = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) { c_LC = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.LeftAlt    )) { c_LA = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.F1 )) { c_F1  = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.F2 )) { c_F2  = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.F3 )) { c_F3  = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.F4 )) { c_F4  = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.F5 )) { c_F5  = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.F6 )) { c_F6  = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.F7 )) { c_F7  = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.F8 )) { c_F8  = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.F9 )) { c_F9  = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.F10)) { c_F10 = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.F11)) { c_F11 = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.F12)) { c_F12 = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.Up  ))  { c_uA = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.Left))  { c_lA = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.Down))  { c_dA = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.Right)) { c_rA = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.End     )) { c_end  = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.PageUp  )) { c_PgUp = true; }
            if (Keyboard.GetState().IsKeyDown(Keys.PageDown)) { c_PgDn = true; }
        }

        public void setPast()
        {
            p_0 = c_0; c_0 = false;
            p_1 = c_2; c_1 = false;
            p_2 = c_3; c_2 = false;
            p_3 = c_4; c_3 = false;
            p_4 = c_5; c_4 = false;
            p_5 = c_6; c_5 = false;
            p_6 = c_7; c_6 = false;
            p_7 = c_8; c_7 = false;
            p_8 = c_8; c_8 = false;
            p_9 = c_9; c_9 = false;
            p_A = c_A; c_A = false;
            p_B = c_B; c_B = false;
            p_C = c_C; c_C = false;
            p_D = c_D; c_D = false;
            p_E = c_E; c_E = false;
            p_F = c_F; c_F = false;
            p_G = c_G; c_G = false;
            p_H = c_H; c_H = false;
            p_I = c_I; c_I = false;
            p_J = c_J; c_J = false;
            p_K = c_K; c_K = false;
            p_L = c_L; c_L = false;
            p_M = c_M; c_M = false;
            p_N = c_N; c_N = false;
            p_O = c_O; c_O = false;
            p_P = c_P; c_P = false;
            p_Q = c_Q; c_Q = false;
            p_R = c_R; c_R = false;
            p_S = c_S; c_S = false;
            p_T = c_T; c_T = false;
            p_U = c_U; c_U = false;
            p_V = c_V; c_V = false;
            p_W = c_W; c_W = false;
            p_X = c_X; c_X = false;
            p_Y = c_Y; c_Y = false;
            p_Z = c_Z; c_Z = false;
            p_sp = c_sp; c_sp = false;
            p_En = c_En; c_En = false;
            p_Bk = c_Bk; c_Bk = false;
            p_LS = c_LS; c_LS = false;
            p_LC = c_LS; c_LS = false;
            p_LA = c_LA; c_LA = false;
            p_F1  = c_F1 ; c_F1  = false;
            p_F2  = c_F2 ; c_F2  = false;
            p_F3  = c_F3 ; c_F3  = false;
            p_F4  = c_F4 ; c_F4  = false;
            p_F5  = c_F5 ; c_F5  = false;
            p_F6  = c_F6 ; c_F6  = false;
            p_F7  = c_F7 ; c_F7  = false;
            p_F8  = c_F8 ; c_F8  = false;
            p_F9  = c_F9 ; c_F9  = false;
            p_F10 = c_F10; c_F10 = false;
            p_F11 = c_F11; c_F11 = false;
            p_F12 = c_F12; c_F12 = false;
            p_uA = c_uA; c_uA = false;
            p_lA = c_lA; c_lA = false;
            p_dA = c_dA; c_dA = false;
            p_rA = c_rA; c_rA = false;
            p_end  = c_end ; c_end  = false;
            p_PgUp = c_PgUp; c_PgUp = false;
            p_PgDn = c_PgDn; c_PgDn = false;
        }

        public bool getInput(keyTime passedTime, keys passedInput)
        {
            if (passedTime == keyTime.p)
            {
                if (passedInput == keys.zero ) { return p_0; }
                if (passedInput == keys.one  ) { return p_1; }
                if (passedInput == keys.two  ) { return p_2; }
                if (passedInput == keys.three) { return p_3; }
                if (passedInput == keys.four ) { return p_4; }
                if (passedInput == keys.five ) { return p_5; }
                if (passedInput == keys.six  ) { return p_6; }
                if (passedInput == keys.seven) { return p_7; }
                if (passedInput == keys.eight) { return p_8; }
                if (passedInput == keys.nine ) { return p_9; }
                if (passedInput == keys.A) { return p_A; }
                if (passedInput == keys.B) { return p_B; }
                if (passedInput == keys.C) { return p_C; }
                if (passedInput == keys.D) { return p_D; }
                if (passedInput == keys.E) { return p_E; }
                if (passedInput == keys.F) { return p_F; }
                if (passedInput == keys.G) { return p_G; }
                if (passedInput == keys.H) { return p_H; }
                if (passedInput == keys.I) { return p_I; }
                if (passedInput == keys.J) { return p_J; }
                if (passedInput == keys.K) { return p_K; }
                if (passedInput == keys.L) { return p_L; }
                if (passedInput == keys.M) { return p_M; }
                if (passedInput == keys.N) { return p_N; }
                if (passedInput == keys.O) { return p_O; }
                if (passedInput == keys.P) { return p_P; }
                if (passedInput == keys.Q) { return p_Q; }
                if (passedInput == keys.R) { return p_R; }
                if (passedInput == keys.S) { return p_S; }
                if (passedInput == keys.T) { return p_T; }
                if (passedInput == keys.U) { return p_U; }
                if (passedInput == keys.V) { return p_V; }
                if (passedInput == keys.W) { return p_W; }
                if (passedInput == keys.X) { return p_X; }
                if (passedInput == keys.Y) { return p_Y; }
                if (passedInput == keys.Z) { return p_Z; }
                if (passedInput == keys.sp) { return p_sp; }
                if (passedInput == keys.En) { return p_En; }
                if (passedInput == keys.Bk) { return p_Bk; }
                if (passedInput == keys.LS) { return p_LS; }
                if (passedInput == keys.LC) { return p_LC; }
                if (passedInput == keys.LA) { return p_LA; }
                if (passedInput == keys.F1 ) { return p_F1 ; }
                if (passedInput == keys.F2 ) { return p_F2 ; }
                if (passedInput == keys.F3 ) { return p_F3 ; }
                if (passedInput == keys.F4 ) { return p_F4 ; }
                if (passedInput == keys.F5 ) { return p_F5 ; }
                if (passedInput == keys.F6 ) { return p_F6 ; }
                if (passedInput == keys.F7 ) { return p_F7 ; }
                if (passedInput == keys.F8 ) { return p_F8 ; }
                if (passedInput == keys.F9 ) { return p_F9 ; }
                if (passedInput == keys.F10) { return p_F10; }
                if (passedInput == keys.F11) { return p_F11; }
                if (passedInput == keys.F12) { return p_F12; }
                if (passedInput == keys.uA) { return p_uA; }
                if (passedInput == keys.lA) { return p_lA; }
                if (passedInput == keys.dA) { return p_dA; }
                if (passedInput == keys.rA) { return p_rA; }
                if (passedInput == keys.end ) { return p_end ; }
                if (passedInput == keys.PgUp) { return p_PgUp; }
                if (passedInput == keys.PgDn) { return p_PgDn; }

                else
                { Console.WriteLine("RegKbrd: Something went wrong."); return false; }
            }
            if (passedTime == keyTime.c)
            {
                if (passedInput == keys.zero ) { return c_0; }
                if (passedInput == keys.one  ) { return c_1; }
                if (passedInput == keys.two  ) { return c_2; }
                if (passedInput == keys.three) { return c_3; }
                if (passedInput == keys.four ) { return c_4; }
                if (passedInput == keys.five ) { return c_5; }
                if (passedInput == keys.six  ) { return c_6; }
                if (passedInput == keys.seven) { return c_7; }
                if (passedInput == keys.eight) { return c_8; }
                if (passedInput == keys.nine ) { return c_9; }
                if (passedInput == keys.A) { return c_A; }
                if (passedInput == keys.B) { return c_B; }
                if (passedInput == keys.C) { return c_C; }
                if (passedInput == keys.D) { return c_D; }
                if (passedInput == keys.E) { return c_E; }
                if (passedInput == keys.F) { return c_F; }
                if (passedInput == keys.G) { return c_G; }
                if (passedInput == keys.H) { return c_H; }
                if (passedInput == keys.I) { return c_I; }
                if (passedInput == keys.J) { return c_J; }
                if (passedInput == keys.K) { return c_K; }
                if (passedInput == keys.L) { return c_L; }
                if (passedInput == keys.M) { return c_M; }
                if (passedInput == keys.N) { return c_N; }
                if (passedInput == keys.O) { return c_O; }
                if (passedInput == keys.P) { return c_P; }
                if (passedInput == keys.Q) { return c_Q; }
                if (passedInput == keys.R) { return c_R; }
                if (passedInput == keys.S) { return c_S; }
                if (passedInput == keys.T) { return c_T; }
                if (passedInput == keys.U) { return c_U; }
                if (passedInput == keys.V) { return c_V; }
                if (passedInput == keys.W) { return c_W; }
                if (passedInput == keys.X) { return c_X; }
                if (passedInput == keys.Y) { return c_Y; }
                if (passedInput == keys.Z) { return c_Z; }
                if (passedInput == keys.sp) { return c_sp; }
                if (passedInput == keys.En) { return c_En; }
                if (passedInput == keys.Bk) { return c_Bk; }
                if (passedInput == keys.LS) { return c_LS; }
                if (passedInput == keys.LC) { return c_LC; }
                if (passedInput == keys.LA) { return c_LA; }
                if (passedInput == keys.F1 ) { return c_F1 ; }
                if (passedInput == keys.F2 ) { return c_F2 ; }
                if (passedInput == keys.F3 ) { return c_F3 ; }
                if (passedInput == keys.F4 ) { return c_F4 ; }
                if (passedInput == keys.F5 ) { return c_F5 ; }
                if (passedInput == keys.F6 ) { return c_F6 ; }
                if (passedInput == keys.F7 ) { return c_F7 ; }
                if (passedInput == keys.F8 ) { return c_F8 ; }
                if (passedInput == keys.F9 ) { return c_F9 ; }
                if (passedInput == keys.F10) { return c_F10; }
                if (passedInput == keys.F11) { return c_F11; }
                if (passedInput == keys.F12) { return c_F12; }
                if (passedInput == keys.uA) { return c_uA; }
                if (passedInput == keys.lA) { return c_lA; }
                if (passedInput == keys.dA) { return c_dA; }
                if (passedInput == keys.rA) { return c_rA; }
                if (passedInput == keys.end ) { return c_end ; }
                if (passedInput == keys.PgUp) { return c_PgUp; }
                if (passedInput == keys.PgDn) { return c_PgDn; }
                else
                { Console.WriteLine("RegKbrd: Something went wrong."); return false; }
            }
            else
            { Console.WriteLine("RegKbrd: Something went wrong."); return false; }
        }
    }
}
