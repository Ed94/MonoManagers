//C#
using System                    ;
using System.Collections.Generic;
//Monogame
using Microsoft.Xna.Framework         ;
using Microsoft.Xna.Framework.Graphics;
//AbstractRealm
using AbstractRealm.Interface  ;
using AbstractRealm.Realm_Space;


namespace AbstractRealm.States
{
    partial class AR_Launch : RealmControl
    {
        private void setupUI()
        {
            gridOne = new UiGrid            (assetMngr);
            OSTI    = new OnScreenTextInput          ();

            continueBtn = UiMngr.createUIObj(continueText, new InstructPtr(uiContinue), new Tuple<int, int>(0, -39), (SpaceMngr.scale / 23f));
            
            //Profile Select Test
            profileSelBtn    = UiMngr.createUIObj(blank       , new InstructPtr(uiSelectList ), new Tuple<int, int>(0,  30), (SpaceMngr.scale /   2f));
            createProfileBtn = UiMngr.createUIObj(continueText, new InstructPtr(createProfile), new Tuple<int, int>(0, -50), (SpaceMngr.scale /  23f));
        }

        //Grid Setup per focus in scene.
        //Profile Check
        private void setProfileCheckUI()
        {
            gridOne.createGrid(1, 1);

            gridOne.setGrid(continueBtn, 0, 0);

            firstPass = false;
        }

        //Base Profile Selection
        private void setProfileSelUI()
        {
            gridOne.createGrid(1, 2);

            gridOne.setGrid(profileSelBtn   , 0, 0);
            gridOne.setGrid(createProfileBtn, 0, 1);

            firstPass = false;
        }
        
        //Profile Selection List
        private void setProfileSelListUI()
        {
            uiProfilePtr profileFunc = new uiProfilePtr(uiProfile);
            
            gridProfileSel = new UiGrid(assetMngr);

            gridProfileSel.createGrid(1, profileMngr.getProfileNum()); Console.WriteLine("profile num: ");

            int profilePos = 0 ;
            int position   = 50;

            foreach(KeyValuePair<string, ProfileMngr.Profile> profile in profileMngr.profileLib)
            {
                string         profileName        = profile.Value.profileName                       ;
                RenderTarget2D renderTargetString = new RenderTarget2D(assetMngr.gDevice, 2500, 200);

                assetMngr.spriteBatch.Begin                                                                                                   ();
                assetMngr.spriteBatch.DrawString(miramo, profileName, Vector2.Zero, Color.White, 0f, Vector2.Zero, 10f, new SpriteEffects(), 0f);

                assetMngr.gDevice.SetRenderTarget(renderTargetString);

                Texture2D profileNameText = (Texture2D)renderTargetString;

                assetMngr.gDevice    .Clear(new Color(0, 0, 0, 0));
                assetMngr.spriteBatch.End                       ();

                UIObj profileBtn = UiMngr.createUIObj(profileName, profileNameText, profileFunc, new Tuple<int, int>(0, position), (SpaceMngr.scale / 23f));

                gridProfileSel.setGrid(profileBtn, 0, profilePos);

                profilePos = profilePos + 1 ;
                position   = position   - 10;
            }

            assetMngr.gDevice.SetRenderTarget(null); 

            firstPass = false;
        }

        //Ui object fucntions for scene.

        //Profile Check
        private void uiContinue()
        {
            firstPass    = true      ;
            currentFocus = focus.osti;

            OSTI.setActive(true);
        }

        //Profile Select
        private void uiSelectList()
        {
            firstPass       =                    true;
            subCurrentFocus = subFocus.profileSelList;
        }

        private void uiProfile(string name)
        {
            profileMngr.setProfile (name                                       );
            stateMngr  .setCRTState(States.StateMngr.ARstate.AR_Main, assetMngr);
        }

        private void createProfile()
        {
            firstPass    = true      ;
            currentFocus = focus.osti;

            OSTI.setActive(true);
        }


        private Texture2D continueText;
        private Texture2D blank       ;
        private UiGrid    gridOne     ;

        //Function Pointers
        private delegate void InstructPtr            ();
        private delegate void uiProfilePtr(string name);
        //OSTI
        private OnScreenTextInput OSTI;
        //ProfileCheck
        private UIObj continueBtn;
        //Profile Selection;
        private UiGrid gridProfileSel ;
        private UIObj createProfileBtn;
        private UIObj  profileSelBtn  ;
    }
}
