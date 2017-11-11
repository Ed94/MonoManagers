//C#
using System.Collections.Generic;
//Monogame
using Microsoft.Xna.Framework         ;
using Microsoft.Xna.Framework.Graphics;
//AbstractRealm
using AbstractRealm.Assets     ;
using AbstractRealm.Realm_Space;


namespace AbstractRealm.States   //Consider this a example class for making a state.
{
    partial class AR_Launch : RealmControl
    {
        //Public
        public AR_Launch()
        {
            assetMngr.LoadStateResource("ar_intro"              );
            assetMngr.LoadStateResource("font"                  );
            assetMngr.LoadResource     ("miramo_chars_blank.xnb");

            foreach (KeyValuePair<string, SpriteFont> font in AssetMngr.currentFonts)
            {
                if (font.Key.Contains("Miramo"))
                    miramo = font.Value;
            }

            foreach (KeyValuePair<string, Texture2D> texture in AssetMngr.currentTextures)
            {
                if (texture.Key.Contains("IntroTextTemp"))
                    introText    = texture.Value;
                if (texture.Key.Contains("continue"     ))
                    continueText = texture.Value;
                if (texture.Key.Contains("blank"        ))
                    blank        = texture.Value;
            }

            IntroStatement = new RigidBillboard(introText);

            IntroStatement.scaleBillboard(SpaceMngr.scale / 23 );
            IntroStatement.moveBillboard (new Vector3(0, 24, 0));

            setupUI();
        }

        //Private
        private bool   firstPass = true;
        private string profileName     ;

        private RigidBillboard IntroStatement; private Texture2D introText;
        private SpriteFont     miramo        ;
    }
}