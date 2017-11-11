//C#
using System.Collections.Generic;
using System.IO                 ;
//Monogame
using Microsoft.Xna.Framework.Input;


namespace Dreams_in_Vapor.Options
{
    public class Controls
    {
        //Public
        public Controls()
        { startup(); }

        private void startup()
        { kbrdMenBinds = new Dictionary<string, Keys>(); getBindings(kbrdMenBinds); }

        private void getBindings(Dictionary<string, Keys> bindings)
        {
            string filePath = @"Users";

            filePath = Path.Combine(filePath, AbstractRealm.ProfileMngr.currentProfile.profileName);
            filePath = Path.Combine(filePath, "Options"                                           );
            filePath = Path.Combine(filePath, "Controls.txt"                                      );

            //IsolatedStorageFile dataFile = IsolatedStorageFile

            if (Directory.Exists(filePath))
            {
                foreach (string line in File.ReadLines(filePath))
                {
                    string name = line.Substring(0, 8);

                    //int bind = line.Substring(11, 16);

                    //bindings.Add(name, );
                }
            }
            else { }
        }

        //Private
        Dictionary<string, Keys> kbrdMenBinds;
    }
}
