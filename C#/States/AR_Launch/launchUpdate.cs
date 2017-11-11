//C#
using System;
//AbstractRealm
using AbstractRealm.Input    ;
using AbstractRealm.Interface;


namespace AbstractRealm.States
{
    partial class AR_Launch : RealmControl
    {
        enum focus    { profileSel, profileCheck  , osti } focus    currentFocus    = focus   .profileCheck ;
        enum subFocus { profileSel, profileSelList       } subFocus subCurrentFocus = subFocus.profileSel   ;

        public override void Update(InputMngr inputMngr)
        {
            switch (currentFocus)
            {
                case focus.profileCheck:
                    {
                        if (profileMngr.getProfileNum() > 0)
                        {
                            currentFocus = focus.profileSel;
                            break;
                        }

                        if (ProfileMngr.currentProfile == null)
                        {
                            if (firstPass == true)
                                setProfileCheckUI();

                            UiMngr.checkInput(gridOne, inputMngr);
                        }
                        else
                            throw new Exception("Something went wrong with the profile manager.");
                    }
                    break;

                case focus.profileSel:
                    {
                        if (firstPass == true)
                        {
                            setProfileSelUI    ();
                            setProfileSelListUI();
                        }

                        switch (subCurrentFocus)
                        {
                            case subFocus.profileSel:
                                {
                                    UiMngr.checkInput(gridOne, inputMngr);

                                    if (inputMngr.checkInput(controls.goTestTri) == true)
                                        stateMngr.setCRTState(States.StateMngr.ARstate.AR_Launch, assetMngr);

                                    if (inputMngr.checkInput(controls.pressEnd ) == true)
                                        display.changeDisplay();
                                }
                                break;

                            case subFocus.profileSelList:
                                {
                                    UiMngr.checkInput(gridProfileSel, inputMngr);

                                    if (inputMngr.checkInput(controls.pressBack) == true)
                                        subCurrentFocus = subFocus.profileSel;
                                }
                                break;
                        }
                    }
                    break;
                
                case focus.osti:
                    {
                        OSTI.Update(inputMngr);

                        if (OSTI.getDone() == true)
                        {
                            profileName = OSTI.getText();

                            OSTI.setActive(false);

                            if (profileMngr.checkForProfile(profileName) == false)
                            { profileMngr.createProfile(profileName); currentFocus = focus.profileSel; }

                            else
                            {
                                Console.WriteLine("Profile Already Exists.");
                                OSTI = new OnScreenTextInput(); OSTI.setActive(true);
                            }
                        }
                    }
                    break;
            }
        }
    }
}
