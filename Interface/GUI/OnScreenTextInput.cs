using AbstractRealm.Input;
using AbstractRealm.Realm_Space;
using AbstractRealm.Assets;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace AbstractRealm.Interface
{
    class OnScreenTextInput : RealmControl
    {
        RigidBillboard background; Texture2D background_Text;

        RigidBillboard slot_0 ; Texture2D A; Texture2D s;
        RigidBillboard slot_1 ; Texture2D B; Texture2D t;
        RigidBillboard slot_2 ; Texture2D C; Texture2D u;
        RigidBillboard slot_3 ; Texture2D D; Texture2D v;
        RigidBillboard slot_4 ; Texture2D E; Texture2D w;
        RigidBillboard slot_5 ; Texture2D F; Texture2D x;
        RigidBillboard slot_6 ; Texture2D G; Texture2D y;
        RigidBillboard slot_7 ; Texture2D H; Texture2D z;
        RigidBillboard slot_8 ; Texture2D I;
        RigidBillboard slot_9 ; Texture2D K; Texture2D digit_0;
        RigidBillboard slot_10; Texture2D J; Texture2D digit_1;
        RigidBillboard slot_11; Texture2D L; Texture2D digit_2;
        RigidBillboard slot_12; Texture2D M; Texture2D digit_3;
        RigidBillboard slot_13; Texture2D N; Texture2D digit_4;
        RigidBillboard slot_14; Texture2D O; Texture2D digit_5;
        RigidBillboard slot_15; Texture2D P; Texture2D digit_6;
        RigidBillboard slot_16; Texture2D Q; Texture2D digit_7;
        RigidBillboard slot_17; Texture2D R; Texture2D digit_8;
        RigidBillboard slot_18; Texture2D S; Texture2D digit_9;
        RigidBillboard slot_19; Texture2D T;
        RigidBillboard slot_20; Texture2D U; Texture2D blank ;
        RigidBillboard slot_21; Texture2D V; Texture2D delete;
        RigidBillboard slot_22; Texture2D W; Texture2D enter ;
        RigidBillboard slot_23; Texture2D X;
        RigidBillboard slot_24; Texture2D Y;
        RigidBillboard slot_25; Texture2D Z;
        RigidBillboard slot_26; Texture2D a; 
        RigidBillboard slot_27; Texture2D b; 
        RigidBillboard slot_28; Texture2D c; 
        RigidBillboard slot_29; Texture2D d; 
        RigidBillboard slot_30; Texture2D e; 
        RigidBillboard slot_31; Texture2D f; 
        RigidBillboard slot_32; Texture2D g; 
        RigidBillboard slot_33; Texture2D h; 
        RigidBillboard slot_34; Texture2D i; 
        RigidBillboard slot_35; Texture2D j; 
        RigidBillboard slot_36; Texture2D k; 
        RigidBillboard slot_37; Texture2D l; 
        RigidBillboard slot_38; Texture2D m; 
        RigidBillboard slot_39; Texture2D n; 
        RigidBillboard slot_40; Texture2D o;
        RigidBillboard slot_41; Texture2D p;
        RigidBillboard slot_42; Texture2D q;
        RigidBillboard slot_43; Texture2D r;

        RigidBillboard out0 ;
        RigidBillboard out1 ;
        RigidBillboard out2 ;
        RigidBillboard out3 ;
        RigidBillboard out4 ;
        RigidBillboard out5 ;
        RigidBillboard out6 ;
        RigidBillboard out7 ;
        RigidBillboard out8 ;
        RigidBillboard out9 ;
        RigidBillboard out10;

        RigidBillboard selection; Texture2D selectionText;

        bool[,] textGrid = new bool[23, 7];

        int []  xPos = new int[11] { 50,  40, 30, 20, 10, 0, -10, -20, -30, -40, -50 };
        int []  yPos = new int[ 5] { 20, 10, 0, -10, -25 };

        int cX = 5; int cY = 2; //Current position

        int offsetX;  int offsetY;
        
        enum chars { caps, lows, number, special } chars currentChars; int charsPos = 0;

        string text = "";

        bool active = false;
        bool done   = false;

        public OnScreenTextInput()
        {
            currentChars = chars.caps;

            loadTextures();
            initialize  ();
        }

        //Producing String
        void selectText()
        {
            switch (currentChars)
            {
                case chars.caps:
                    if (textGrid[ 0, 0] == true) { text = text + "A"; int position = text.Length - 1; setOutput(position, A); }
                    if (textGrid[ 1, 0] == true) { text = text + "B"; int position = text.Length - 1; setOutput(position, B); }
                    if (textGrid[ 2, 0] == true) { text = text + "C"; int position = text.Length - 1; setOutput(position, C); }
                    if (textGrid[ 3, 0] == true) { text = text + "D"; int position = text.Length - 1; setOutput(position, D); }
                    if (textGrid[ 4, 0] == true) { text = text + "E"; int position = text.Length - 1; setOutput(position, E); }
                    if (textGrid[ 5, 0] == true) { text = text + "F"; int position = text.Length - 1; setOutput(position, F); }
                    if (textGrid[ 6, 0] == true) { text = text + "G"; int position = text.Length - 1; setOutput(position, G); }
                    if (textGrid[ 7, 0] == true) { text = text + "H"; int position = text.Length - 1; setOutput(position, H); }
                    if (textGrid[ 8, 0] == true) { text = text + "I"; int position = text.Length - 1; setOutput(position, I); }
                    if (textGrid[ 9, 0] == true) { text = text + "J"; int position = text.Length - 1; setOutput(position, J); }
                    if (textGrid[10, 0] == true) { text = text + "K"; int position = text.Length - 1; setOutput(position, K); }
                    if (textGrid[ 0, 1] == true) { text = text + "L"; int position = text.Length - 1; setOutput(position, L); }
                    if (textGrid[ 1, 1] == true) { text = text + "M"; int position = text.Length - 1; setOutput(position, M); }
                    if (textGrid[ 2, 1] == true) { text = text + "N"; int position = text.Length - 1; setOutput(position, N); }
                    if (textGrid[ 3, 1] == true) { text = text + "O"; int position = text.Length - 1; setOutput(position, O); }
                    if (textGrid[ 4, 1] == true) { text = text + "P"; int position = text.Length - 1; setOutput(position, P); }
                    if (textGrid[ 5, 1] == true) { text = text + "Q"; int position = text.Length - 1; setOutput(position, Q); }
                    if (textGrid[ 6, 1] == true) { text = text + "R"; int position = text.Length - 1; setOutput(position, R); }
                    if (textGrid[ 7, 1] == true) { text = text + "S"; int position = text.Length - 1; setOutput(position, S); }
                    if (textGrid[ 8, 1] == true) { text = text + "T"; int position = text.Length - 1; setOutput(position, T); }
                    if (textGrid[ 9, 1] == true) { text = text + "U"; int position = text.Length - 1; setOutput(position, U); }
                    if (textGrid[10, 1] == true) { text = text + "V"; int position = text.Length - 1; setOutput(position, V); }
                    if (textGrid[ 0, 2] == true) { text = text + "W"; int position = text.Length - 1; setOutput(position, W); }
                    if (textGrid[ 1, 2] == true) { text = text + "X"; int position = text.Length - 1; setOutput(position, X); }
                    if (textGrid[ 2, 2] == true) { text = text + "Y"; int position = text.Length - 1; setOutput(position, Y); }
                    if (textGrid[ 3, 2] == true) { text = text + "Z"; int position = text.Length - 1; setOutput(position, Z); }
                    if (textGrid[ 4, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 5, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 6, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 7, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 8, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 9, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[10, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 0, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 1, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 2, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 3, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 4, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 5, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 6, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 7, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 8, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    break;
                case chars.lows:
                    if (textGrid[ 0, 0] == true) { text = text + "a"; int position = text.Length - 1; setOutput(position, a); }
                    if (textGrid[ 1, 0] == true) { text = text + "b"; int position = text.Length - 1; setOutput(position, b); }
                    if (textGrid[ 2, 0] == true) { text = text + "c"; int position = text.Length - 1; setOutput(position, c); }
                    if (textGrid[ 3, 0] == true) { text = text + "d"; int position = text.Length - 1; setOutput(position, d); }
                    if (textGrid[ 4, 0] == true) { text = text + "e"; int position = text.Length - 1; setOutput(position, e); }
                    if (textGrid[ 5, 0] == true) { text = text + "f"; int position = text.Length - 1; setOutput(position, f); }
                    if (textGrid[ 6, 0] == true) { text = text + "g"; int position = text.Length - 1; setOutput(position, g); }
                    if (textGrid[ 7, 0] == true) { text = text + "h"; int position = text.Length - 1; setOutput(position, h); }
                    if (textGrid[ 8, 0] == true) { text = text + "i"; int position = text.Length - 1; setOutput(position, i); }
                    if (textGrid[ 9, 0] == true) { text = text + "j"; int position = text.Length - 1; setOutput(position, j); }
                    if (textGrid[10, 0] == true) { text = text + "k"; int position = text.Length - 1; setOutput(position, k); }
                    if (textGrid[ 0, 1] == true) { text = text + "l"; int position = text.Length - 1; setOutput(position, l); }
                    if (textGrid[ 1, 1] == true) { text = text + "m"; int position = text.Length - 1; setOutput(position, m); }
                    if (textGrid[ 2, 1] == true) { text = text + "n"; int position = text.Length - 1; setOutput(position, n); }
                    if (textGrid[ 3, 1] == true) { text = text + "o"; int position = text.Length - 1; setOutput(position, o); }
                    if (textGrid[ 4, 1] == true) { text = text + "p"; int position = text.Length - 1; setOutput(position, p); }
                    if (textGrid[ 5, 1] == true) { text = text + "q"; int position = text.Length - 1; setOutput(position, q); }
                    if (textGrid[ 6, 1] == true) { text = text + "r"; int position = text.Length - 1; setOutput(position, r); }
                    if (textGrid[ 7, 1] == true) { text = text + "s"; int position = text.Length - 1; setOutput(position, s); }
                    if (textGrid[ 8, 1] == true) { text = text + "t"; int position = text.Length - 1; setOutput(position, t); }
                    if (textGrid[ 9, 1] == true) { text = text + "u"; int position = text.Length - 1; setOutput(position, u); }
                    if (textGrid[10, 1] == true) { text = text + "v"; int position = text.Length - 1; setOutput(position, v); }
                    if (textGrid[ 0, 2] == true) { text = text + "w"; int position = text.Length - 1; setOutput(position, w); }
                    if (textGrid[ 1, 2] == true) { text = text + "x"; int position = text.Length - 1; setOutput(position, x); }
                    if (textGrid[ 2, 2] == true) { text = text + "y"; int position = text.Length - 1; setOutput(position, y); }
                    if (textGrid[ 3, 2] == true) { text = text + "z"; int position = text.Length - 1; setOutput(position, z); }
                    if (textGrid[ 4, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 5, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 6, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 7, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 8, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 9, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[10, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 0, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 1, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 2, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 3, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 4, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 5, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 6, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 7, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 8, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    break;
                case chars.number:
                    if (textGrid[ 0, 0] == true) { text = text + "0"; int position = text.Length - 1; setOutput(position, digit_0); }
                    if (textGrid[ 1, 0] == true) { text = text + "1"; int position = text.Length - 1; setOutput(position, digit_1); }
                    if (textGrid[ 2, 0] == true) { text = text + "2"; int position = text.Length - 1; setOutput(position, digit_2); }
                    if (textGrid[ 3, 0] == true) { text = text + "3"; int position = text.Length - 1; setOutput(position, digit_3); }
                    if (textGrid[ 4, 0] == true) { text = text + "4"; int position = text.Length - 1; setOutput(position, digit_4); }
                    if (textGrid[ 5, 0] == true) { text = text + "5"; int position = text.Length - 1; setOutput(position, digit_5); }
                    if (textGrid[ 6, 0] == true) { text = text + "6"; int position = text.Length - 1; setOutput(position, digit_6); }
                    if (textGrid[ 7, 0] == true) { text = text + "7"; int position = text.Length - 1; setOutput(position, digit_7); }
                    if (textGrid[ 8, 0] == true) { text = text + "8"; int position = text.Length - 1; setOutput(position, digit_8); }
                    if (textGrid[ 9, 0] == true) { text = text + "9"; int position = text.Length - 1; setOutput(position, digit_9); }
                    if (textGrid[10, 1] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 0, 1] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 1, 1] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 2, 1] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 3, 1] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 4, 1] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 5, 1] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 6, 1] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 7, 1] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 8, 1] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 9, 1] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[10, 1] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 0, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 1, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 2, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 3, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 4, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 5, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 6, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 7, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 8, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 8, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 9, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[10, 2] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 0, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 1, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 2, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 3, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 4, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 5, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 6, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 7, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    if (textGrid[ 8, 3] == true) { text = text + " "; int position = text.Length - 1; setOutput(position, blank); }
                    break;
                case chars.special:
                    break;
            }
            if (textGrid[ 9, 3] == true)
            {
                if (text.Length > 0)
                {
                    setOutput(text.Length - 1, blank);

                    text = text.Substring(0, text.Length - 1);
                }
            }
            if (textGrid[10, 3] == true)
            {
                if (text.Length > 0)
                {
                    done = true;
                }
            }
        }

        //Moving selection
        void checkPosition()
        {
            int posX;
            int posY;

            for (int column = 0; column < 11; column++)
            {
                posX = xPos[column];

                if (column == cX)
                {
                    for (int row = 0; row < 4; row++)
                    {
                        posY = yPos[row];

                        if (row == cY)
                        {
                            if (textGrid[column, row] == true) { selection.setPosition(new Vector3(posX, posY, 0)); }
                        }
                    }
                }
            }
        }

        void setOutput(int position, Texture2D charText)
        {
            if (position ==  0) { out0 .setTexture(charText); }
            if (position ==  1) { out1 .setTexture(charText); }
            if (position ==  2) { out2 .setTexture(charText); }
            if (position ==  3) { out3 .setTexture(charText); }
            if (position ==  4) { out4 .setTexture(charText); }
            if (position ==  5) { out5 .setTexture(charText); }
            if (position ==  6) { out6 .setTexture(charText); }
            if (position ==  7) { out7 .setTexture(charText); }
            if (position ==  8) { out8 .setTexture(charText); }
            if (position ==  9) { out9 .setTexture(charText); }
            if (position == 10) { out10.setTexture(charText); }
        }

        void checkCharsPos()
        {
            if (charsPos == 0)
            {
                slot_0 .setTexture(A);
                slot_1 .setTexture(B);
                slot_2 .setTexture(C);
                slot_3 .setTexture(D);
                slot_4 .setTexture(E);
                slot_5 .setTexture(F);
                slot_6 .setTexture(G);
                slot_7 .setTexture(H);
                slot_8 .setTexture(I);
                slot_9 .setTexture(J);
                slot_10.setTexture(K);
                slot_11.setTexture(L);
                slot_12.setTexture(M);
                slot_13.setTexture(N);
                slot_14.setTexture(O);
                slot_15.setTexture(P);
                slot_16.setTexture(Q);
                slot_17.setTexture(R);
                slot_18.setTexture(S);
                slot_19.setTexture(T);
                slot_20.setTexture(U);
                slot_21.setTexture(V);
                slot_22.setTexture(W);
                slot_23.setTexture(X);
                slot_24.setTexture(Y);
                slot_25.setTexture(Z);

                currentChars = chars.caps;
            }
            if (charsPos == 1)
            {
                slot_0 .setTexture(a);
                slot_1 .setTexture(b);
                slot_2 .setTexture(c);
                slot_3 .setTexture(d);
                slot_4 .setTexture(e);
                slot_5 .setTexture(f);
                slot_6 .setTexture(g);
                slot_7 .setTexture(h);
                slot_8 .setTexture(i);
                slot_9 .setTexture(j);
                slot_10.setTexture(k);
                slot_11.setTexture(l);
                slot_12.setTexture(m);
                slot_13.setTexture(n);
                slot_14.setTexture(o);
                slot_15.setTexture(p);
                slot_16.setTexture(q);
                slot_17.setTexture(r);
                slot_18.setTexture(s);
                slot_19.setTexture(t);
                slot_20.setTexture(u);
                slot_21.setTexture(v);
                slot_22.setTexture(w);
                slot_23.setTexture(x);
                slot_24.setTexture(y);
                slot_25.setTexture(z);

                currentChars = chars.lows;
            }
            if (charsPos == 2)
            {
                slot_0 .setTexture(digit_0);
                slot_1 .setTexture(digit_1);
                slot_2 .setTexture(digit_2);
                slot_3 .setTexture(digit_3);
                slot_4 .setTexture(digit_4);
                slot_5 .setTexture(digit_5);
                slot_6 .setTexture(digit_6);
                slot_7 .setTexture(digit_7);
                slot_8 .setTexture(digit_8);
                slot_9 .setTexture(digit_9);
                slot_10.setTexture(blank);
                slot_11.setTexture(blank);
                slot_12.setTexture(blank);
                slot_13.setTexture(blank);
                slot_14.setTexture(blank);
                slot_15.setTexture(blank);
                slot_16.setTexture(blank);
                slot_17.setTexture(blank);
                slot_18.setTexture(blank);
                slot_19.setTexture(blank);
                slot_20.setTexture(blank);
                slot_21.setTexture(blank);
                slot_22.setTexture(blank);
                slot_23.setTexture(blank);
                slot_24.setTexture(blank);
                slot_25.setTexture(blank);

                currentChars = chars.number;
            }
            if (charsPos == 3) { currentChars = chars.special; }
        }

        private enum move { up, right, left, down } void moveSelection(move selected)
        {
            if (selected == move.right)
            {
                if (cX < 10) { int x = cX + 1; textGrid[cX, cY] = false; textGrid[x, cY] = true; cX = cX + 1; checkPosition(); }
            } 
            if (selected == move.left)
            {
                if (cX >  0) { int x = cX - 1; textGrid[cX, cY] = false; textGrid[x, cY] = true; cX = cX - 1; checkPosition(); }
            }
            if (selected == move.up)
            {
                if (cY >  0) { int y = cY - 1; textGrid[cX, cY] = false; textGrid[cX, y] = true; cY = cY - 1; checkPosition(); }
            }
            if (selected == move.down)
            {
                if (cY <  3) { int y = cY + 1; textGrid[cX, cY] = false; textGrid[cX, y] = true; cY = cY + 1; checkPosition(); }
            }
        }

        private enum tabSel { right, left } void changeTab(tabSel selected)
        {
            switch (selected)
            {
                case tabSel.right:
                    if (charsPos < 3)
                    {
                        charsPos++;
                    }
                    checkCharsPos();
                    break;
                case tabSel.left:
                    if (charsPos > 0)
                    {
                        charsPos--;
                    }
                    checkCharsPos();
                    break;
            }
        }

        //General
        void initialize()
        {
            background = new RigidBillboard(background_Text); background.scaleBillboard(0.03f);

            slot_0  = new RigidBillboard(A     ); slot_0 .scaleBillboard(0.05f); slot_0 .setPosition(new Vector3(xPos[ 0], yPos[0], 0));
            slot_1  = new RigidBillboard(B     ); slot_1 .scaleBillboard(0.05f); slot_1 .setPosition(new Vector3(xPos[ 1], yPos[0], 0));
            slot_2  = new RigidBillboard(C     ); slot_2 .scaleBillboard(0.05f); slot_2 .setPosition(new Vector3(xPos[ 2], yPos[0], 0));
            slot_3  = new RigidBillboard(D     ); slot_3 .scaleBillboard(0.05f); slot_3 .setPosition(new Vector3(xPos[ 3], yPos[0], 0));
            slot_4  = new RigidBillboard(E     ); slot_4 .scaleBillboard(0.05f); slot_4 .setPosition(new Vector3(xPos[ 4], yPos[0], 0));
            slot_5  = new RigidBillboard(F     ); slot_5 .scaleBillboard(0.05f); slot_5 .setPosition(new Vector3(xPos[ 5], yPos[0], 0));
            slot_6  = new RigidBillboard(G     ); slot_6 .scaleBillboard(0.05f); slot_6 .setPosition(new Vector3(xPos[ 6], yPos[0], 0));
            slot_7  = new RigidBillboard(H     ); slot_7 .scaleBillboard(0.05f); slot_7 .setPosition(new Vector3(xPos[ 7], yPos[0], 0));
            slot_8  = new RigidBillboard(I     ); slot_8 .scaleBillboard(0.05f); slot_8 .setPosition(new Vector3(xPos[ 8], yPos[0], 0));
            slot_9  = new RigidBillboard(J     ); slot_9 .scaleBillboard(0.05f); slot_9 .setPosition(new Vector3(xPos[ 9], yPos[0], 0));
            slot_10 = new RigidBillboard(K     ); slot_10.scaleBillboard(0.05f); slot_10.setPosition(new Vector3(xPos[10], yPos[0], 0));
            slot_11 = new RigidBillboard(L     ); slot_11.scaleBillboard(0.05f); slot_11.setPosition(new Vector3(xPos[ 0], yPos[1], 0));
            slot_12 = new RigidBillboard(M     ); slot_12.scaleBillboard(0.05f); slot_12.setPosition(new Vector3(xPos[ 1], yPos[1], 0));
            slot_13 = new RigidBillboard(N     ); slot_13.scaleBillboard(0.05f); slot_13.setPosition(new Vector3(xPos[ 2], yPos[1], 0));
            slot_14 = new RigidBillboard(O     ); slot_14.scaleBillboard(0.05f); slot_14.setPosition(new Vector3(xPos[ 3], yPos[1], 0));
            slot_15 = new RigidBillboard(P     ); slot_15.scaleBillboard(0.05f); slot_15.setPosition(new Vector3(xPos[ 4], yPos[1], 0));
            slot_16 = new RigidBillboard(Q     ); slot_16.scaleBillboard(0.05f); slot_16.setPosition(new Vector3(xPos[ 5], yPos[1], 0));
            slot_17 = new RigidBillboard(R     ); slot_17.scaleBillboard(0.05f); slot_17.setPosition(new Vector3(xPos[ 6], yPos[1], 0));
            slot_18 = new RigidBillboard(S     ); slot_18.scaleBillboard(0.05f); slot_18.setPosition(new Vector3(xPos[ 7], yPos[1], 0));
            slot_19 = new RigidBillboard(T     ); slot_19.scaleBillboard(0.05f); slot_19.setPosition(new Vector3(xPos[ 8], yPos[1], 0));
            slot_20 = new RigidBillboard(U     ); slot_20.scaleBillboard(0.05f); slot_20.setPosition(new Vector3(xPos[ 9], yPos[1], 0));
            slot_21 = new RigidBillboard(V     ); slot_21.scaleBillboard(0.05f); slot_21.setPosition(new Vector3(xPos[10], yPos[1], 0));
            slot_22 = new RigidBillboard(W     ); slot_22.scaleBillboard(0.05f); slot_22.setPosition(new Vector3(xPos[ 0], yPos[2], 0));
            slot_23 = new RigidBillboard(X     ); slot_23.scaleBillboard(0.05f); slot_23.setPosition(new Vector3(xPos[ 1], yPos[2], 0));
            slot_24 = new RigidBillboard(Y     ); slot_24.scaleBillboard(0.05f); slot_24.setPosition(new Vector3(xPos[ 2], yPos[2], 0));
            slot_25 = new RigidBillboard(Z     ); slot_25.scaleBillboard(0.05f); slot_25.setPosition(new Vector3(xPos[ 3], yPos[2], 0));
            slot_26 = new RigidBillboard(blank ); slot_26.scaleBillboard(0.04f); slot_26.setPosition(new Vector3(xPos[ 4], yPos[2], 0));
            slot_27 = new RigidBillboard(blank ); slot_27.scaleBillboard(0.04f); slot_27.setPosition(new Vector3(xPos[ 5], yPos[2], 0));
            slot_28 = new RigidBillboard(blank ); slot_28.scaleBillboard(0.04f); slot_28.setPosition(new Vector3(xPos[ 6], yPos[2], 0));
            slot_29 = new RigidBillboard(blank ); slot_29.scaleBillboard(0.04f); slot_29.setPosition(new Vector3(xPos[ 7], yPos[2], 0));
            slot_30 = new RigidBillboard(blank ); slot_30.scaleBillboard(0.04f); slot_30.setPosition(new Vector3(xPos[ 8], yPos[2], 0));
            slot_31 = new RigidBillboard(blank ); slot_31.scaleBillboard(0.04f); slot_31.setPosition(new Vector3(xPos[ 9], yPos[2], 0));
            slot_32 = new RigidBillboard(blank ); slot_32.scaleBillboard(0.04f); slot_32.setPosition(new Vector3(xPos[10], yPos[2], 0));
            slot_33 = new RigidBillboard(blank ); slot_33.scaleBillboard(0.04f); slot_33.setPosition(new Vector3(xPos[ 0], yPos[3], 0));
            slot_34 = new RigidBillboard(blank ); slot_34.scaleBillboard(0.04f); slot_34.setPosition(new Vector3(xPos[ 1], yPos[3], 0));
            slot_35 = new RigidBillboard(blank ); slot_35.scaleBillboard(0.04f); slot_35.setPosition(new Vector3(xPos[ 2], yPos[3], 0));
            slot_36 = new RigidBillboard(blank ); slot_36.scaleBillboard(0.04f); slot_36.setPosition(new Vector3(xPos[ 3], yPos[3], 0));
            slot_37 = new RigidBillboard(blank ); slot_37.scaleBillboard(0.04f); slot_37.setPosition(new Vector3(xPos[ 4], yPos[3], 0));
            slot_38 = new RigidBillboard(blank ); slot_38.scaleBillboard(0.04f); slot_38.setPosition(new Vector3(xPos[ 5], yPos[3], 0));
            slot_39 = new RigidBillboard(blank ); slot_39.scaleBillboard(0.04f); slot_39.setPosition(new Vector3(xPos[ 6], yPos[3], 0));
            slot_40 = new RigidBillboard(blank ); slot_40.scaleBillboard(0.04f); slot_40.setPosition(new Vector3(xPos[ 7], yPos[3], 0));
            slot_41 = new RigidBillboard(blank ); slot_41.scaleBillboard(0.04f); slot_41.setPosition(new Vector3(xPos[ 8], yPos[3], 0));
            slot_42 = new RigidBillboard(delete); slot_42.scaleBillboard(0.04f); slot_42.setPosition(new Vector3(xPos[ 9], yPos[3], 0));
            slot_43 = new RigidBillboard(enter ); slot_43.scaleBillboard(0.04f); slot_43.setPosition(new Vector3(xPos[10], yPos[3], 0));

            out0  = new RigidBillboard(blank); out0 .scaleBillboard(0.025f); out0 .setPosition(new Vector3(xPos[ 0], yPos[4], 0));
            out1  = new RigidBillboard(blank); out1 .scaleBillboard(0.025f); out1 .setPosition(new Vector3(xPos[ 1], yPos[4], 0));
            out2  = new RigidBillboard(blank); out2 .scaleBillboard(0.025f); out2 .setPosition(new Vector3(xPos[ 2], yPos[4], 0));
            out3  = new RigidBillboard(blank); out3 .scaleBillboard(0.025f); out3 .setPosition(new Vector3(xPos[ 3], yPos[4], 0));
            out4  = new RigidBillboard(blank); out4 .scaleBillboard(0.025f); out4 .setPosition(new Vector3(xPos[ 4], yPos[4], 0));
            out5  = new RigidBillboard(blank); out5 .scaleBillboard(0.025f); out5 .setPosition(new Vector3(xPos[ 5], yPos[4], 0));
            out6  = new RigidBillboard(blank); out6 .scaleBillboard(0.025f); out6 .setPosition(new Vector3(xPos[ 6], yPos[4], 0));
            out7  = new RigidBillboard(blank); out7 .scaleBillboard(0.025f); out7 .setPosition(new Vector3(xPos[ 7], yPos[4], 0));
            out8  = new RigidBillboard(blank); out8 .scaleBillboard(0.025f); out8 .setPosition(new Vector3(xPos[ 8], yPos[4], 0));
            out9  = new RigidBillboard(blank); out9 .scaleBillboard(0.025f); out9 .setPosition(new Vector3(xPos[ 9], yPos[4], 0));
            out10 = new RigidBillboard(blank); out10.scaleBillboard(0.025f); out10.setPosition(new Vector3(xPos[10], yPos[4], 0));

            selection = new RigidBillboard(selectionText); selection.scaleBillboard(0.04f);

            textGrid[cX, cY] = true; checkPosition();
        }

        void loadTextures()
        {
            assetMngr.LoadStateResource("miramo_chars");
            assetMngr.LoadStateResource("background"  );

            foreach (KeyValuePair<string, Texture2D> asset in AssetMngr.currentTextures)
            {
                if (asset.Key.Contains("background")) { background_Text = asset.Value; }

                if (asset.Key.Contains("caps_A")) { A = asset.Value; }
                if (asset.Key.Contains("caps_B")) { B = asset.Value; }
                if (asset.Key.Contains("caps_C")) { C = asset.Value; }
                if (asset.Key.Contains("caps_D")) { D = asset.Value; }
                if (asset.Key.Contains("caps_E")) { E = asset.Value; }
                if (asset.Key.Contains("caps_F")) { F = asset.Value; }
                if (asset.Key.Contains("caps_G")) { G = asset.Value; }
                if (asset.Key.Contains("caps_H")) { H = asset.Value; }
                if (asset.Key.Contains("caps_I")) { I = asset.Value; }
                if (asset.Key.Contains("caps_J")) { J = asset.Value; }
                if (asset.Key.Contains("caps_K")) { K = asset.Value; }
                if (asset.Key.Contains("caps_L")) { L = asset.Value; }
                if (asset.Key.Contains("caps_M")) { M = asset.Value; }
                if (asset.Key.Contains("caps_N")) { N = asset.Value; }
                if (asset.Key.Contains("caps_O")) { O = asset.Value; }
                if (asset.Key.Contains("caps_P")) { P = asset.Value; }
                if (asset.Key.Contains("caps_Q")) { Q = asset.Value; }
                if (asset.Key.Contains("caps_R")) { R = asset.Value; }
                if (asset.Key.Contains("caps_S")) { S = asset.Value; }
                if (asset.Key.Contains("caps_T")) { T = asset.Value; }
                if (asset.Key.Contains("caps_U")) { U = asset.Value; }
                if (asset.Key.Contains("caps_V")) { V = asset.Value; }
                if (asset.Key.Contains("caps_W")) { W = asset.Value; }
                if (asset.Key.Contains("caps_X")) { X = asset.Value; }
                if (asset.Key.Contains("caps_Y")) { Y = asset.Value; }
                if (asset.Key.Contains("caps_Z")) { Z = asset.Value; }

                if (asset.Key.Contains("lows_a")) { a = asset.Value; }
                if (asset.Key.Contains("lows_b")) { b = asset.Value; }
                if (asset.Key.Contains("lows_c")) { c = asset.Value; }
                if (asset.Key.Contains("lows_d")) { d = asset.Value; }
                if (asset.Key.Contains("lows_e")) { e = asset.Value; }
                if (asset.Key.Contains("lows_f")) { f = asset.Value; }
                if (asset.Key.Contains("lows_g")) { g = asset.Value; }
                if (asset.Key.Contains("lows_h")) { h = asset.Value; }
                if (asset.Key.Contains("lows_i")) { i = asset.Value; }
                if (asset.Key.Contains("lows_j")) { j = asset.Value; }
                if (asset.Key.Contains("lows_k")) { k = asset.Value; }
                if (asset.Key.Contains("lows_l")) { l = asset.Value; }
                if (asset.Key.Contains("lows_m")) { m = asset.Value; }
                if (asset.Key.Contains("lows_n")) { n = asset.Value; }
                if (asset.Key.Contains("lows_o")) { o = asset.Value; }
                if (asset.Key.Contains("lows_p")) { p = asset.Value; }
                if (asset.Key.Contains("lows_q")) { q = asset.Value; }
                if (asset.Key.Contains("lows_r")) { r = asset.Value; }
                if (asset.Key.Contains("lows_s")) { s = asset.Value; }
                if (asset.Key.Contains("lows_t")) { t = asset.Value; }
                if (asset.Key.Contains("lows_u")) { u = asset.Value; }
                if (asset.Key.Contains("lows_v")) { v = asset.Value; }
                if (asset.Key.Contains("lows_w")) { w = asset.Value; }
                if (asset.Key.Contains("lows_x")) { x = asset.Value; }
                if (asset.Key.Contains("lows_y")) { y = asset.Value; }
                if (asset.Key.Contains("lows_z")) { z = asset.Value; }

                if (asset.Key.Contains("digit_0")) { digit_0 = asset.Value; }
                if (asset.Key.Contains("digit_1")) { digit_1 = asset.Value; }
                if (asset.Key.Contains("digit_2")) { digit_2 = asset.Value; }
                if (asset.Key.Contains("digit_3")) { digit_3 = asset.Value; }
                if (asset.Key.Contains("digit_4")) { digit_4 = asset.Value; }
                if (asset.Key.Contains("digit_5")) { digit_5 = asset.Value; }
                if (asset.Key.Contains("digit_6")) { digit_6 = asset.Value; }
                if (asset.Key.Contains("digit_7")) { digit_7 = asset.Value; }
                if (asset.Key.Contains("digit_8")) { digit_8 = asset.Value; }
                if (asset.Key.Contains("digit_9")) { digit_9 = asset.Value; }

                if (asset.Key.Contains("blank" )) { blank  = asset.Value; }
                if (asset.Key.Contains("delete")) { delete = asset.Value; }
                if (asset.Key.Contains("enter" )) { enter  = asset.Value; }

                if (asset.Key.Contains("sel")) { selectionText = asset.Value; }
            }
        }
        
        //Navigation
        private void navigateOCT(InputMngr inputMngr)
        {
            if (inputMngr.checkInput (InputMngr.controls.pressRight))
            {
                moveSelection(move.right);
            }
            if (inputMngr.checkInput (InputMngr.controls.pressLeft ))
            {
                moveSelection(move.left );
            }
            if (inputMngr.checkInput (InputMngr.controls.pressUp   ))
            {
                moveSelection(move.up  );
            }
            if (inputMngr.checkInput (InputMngr.controls.pressDown ))
            {
                moveSelection(move.down);
            }
            if (inputMngr.checkInput (InputMngr.controls.pressEnter  ))
            {
                selectText();
            }
            if (inputMngr.checkInput(InputMngr.controls.pressTabRight))
            {
                changeTab(tabSel.right);
            }
            if (inputMngr.checkInput(InputMngr.controls.pressTabLeft ))
            {
                changeTab(tabSel.left );
            }
        }

        //Scene Transition
        private void navigateMenu(InputMngr inputMngr)
        {
            if (inputMngr.checkInput(InputMngr.controls.pressBack))
            {
                stateMngr.setCRTState(States.StateMngr.ARstate.AR_Launch, assetMngr);
            }
        }

        public void setActive(bool value)
        {
            active = value;
        }

        public string getText()
        {
            return text;
        }

        public bool getDone()
        {
            return done;
        }

        //Realm Control
        public override void Update(InputMngr inputMngr)
        {
            navigateOCT (inputMngr);
            navigateMenu(inputMngr);

            selection.Update();
        }

        public override void Draw()
        {
            if (active == true)
            {
                background.Draw(assetMngr.basicEffect);

                slot_0 .Draw(assetMngr.basicEffect);
                slot_1 .Draw(assetMngr.basicEffect);
                slot_2 .Draw(assetMngr.basicEffect);
                slot_3 .Draw(assetMngr.basicEffect);
                slot_4 .Draw(assetMngr.basicEffect);
                slot_5 .Draw(assetMngr.basicEffect);
                slot_6 .Draw(assetMngr.basicEffect);
                slot_7 .Draw(assetMngr.basicEffect);
                slot_8 .Draw(assetMngr.basicEffect);
                slot_9 .Draw(assetMngr.basicEffect);
                slot_10.Draw(assetMngr.basicEffect);
                slot_11.Draw(assetMngr.basicEffect);
                slot_12.Draw(assetMngr.basicEffect);
                slot_13.Draw(assetMngr.basicEffect);
                slot_14.Draw(assetMngr.basicEffect);
                slot_15.Draw(assetMngr.basicEffect);
                slot_16.Draw(assetMngr.basicEffect);
                slot_17.Draw(assetMngr.basicEffect);
                slot_18.Draw(assetMngr.basicEffect);
                slot_19.Draw(assetMngr.basicEffect);
                slot_20.Draw(assetMngr.basicEffect);
                slot_21.Draw(assetMngr.basicEffect);
                slot_22.Draw(assetMngr.basicEffect);
                slot_23.Draw(assetMngr.basicEffect);
                slot_24.Draw(assetMngr.basicEffect);
                slot_25.Draw(assetMngr.basicEffect);
                slot_26.Draw(assetMngr.basicEffect);
                slot_27.Draw(assetMngr.basicEffect);
                slot_28.Draw(assetMngr.basicEffect);
                slot_29.Draw(assetMngr.basicEffect);
                slot_30.Draw(assetMngr.basicEffect);
                slot_31.Draw(assetMngr.basicEffect);
                slot_32.Draw(assetMngr.basicEffect);
                slot_33.Draw(assetMngr.basicEffect);
                slot_34.Draw(assetMngr.basicEffect);
                slot_35.Draw(assetMngr.basicEffect);
                slot_36.Draw(assetMngr.basicEffect);
                slot_37.Draw(assetMngr.basicEffect);
                slot_38.Draw(assetMngr.basicEffect);
                slot_39.Draw(assetMngr.basicEffect);
                slot_40.Draw(assetMngr.basicEffect);
                slot_41.Draw(assetMngr.basicEffect);
                slot_42.Draw(assetMngr.basicEffect);
                slot_43.Draw(assetMngr.basicEffect);

                out0 .Draw(assetMngr.basicEffect);
                out1 .Draw(assetMngr.basicEffect);
                out2 .Draw(assetMngr.basicEffect);
                out3 .Draw(assetMngr.basicEffect);
                out4 .Draw(assetMngr.basicEffect);
                out5 .Draw(assetMngr.basicEffect);
                out6 .Draw(assetMngr.basicEffect);
                out7 .Draw(assetMngr.basicEffect);
                out8 .Draw(assetMngr.basicEffect);
                out9 .Draw(assetMngr.basicEffect);
                out10.Draw(assetMngr.basicEffect);

                selection.Draw(assetMngr.basicEffect);
            }
        }
    }
}