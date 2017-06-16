//Monogame
using Microsoft.Xna.Framework;
//AbstractRealm
using AbstractRealm.Interface;

namespace AbstractRealm.States
{
    partial class AR_Launch : RealmControl
    {
        public override void Draw()
        {
            assetMngr.gDevice.Clear(new Color(20, 20, 20));

            switch (currentFocus)
            {
                case focus.osti:
                    OSTI.Draw();
                    break;

                case focus.profileCheck:
                    IntroStatement.draw  (assetMngr.basicEffect         );
                    uiMngr        .drawUi(gridOne, assetMngr.basicEffect);
                    break;

                case focus.profileSel:
                    switch (subCurrentFocus)
                    {
                        case subFocus.profileSel:
                            uiMngr.drawUi(gridOne       , assetMngr.basicEffect);
                            uiMngr.drawUi(gridProfileSel, assetMngr.basicEffect);
                            break;

                        case subFocus.profileSelList:
                            uiMngr.drawUi(gridOne       , assetMngr.basicEffect);
                            uiMngr.drawUi(gridProfileSel, assetMngr.basicEffect);
                            break;
                    }
                    break;
            }
        }
    }
}
