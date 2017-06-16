//C#
using System;
using System.Collections.Generic;
using System.IO;
//AbstractRealm
using AbstractRealm.Options;
using Dreams_in_Vapor;

namespace AbstractRealm
{
    public class ProfileMngr   //Profile Managment Class
    {
        //Profile needs to have to significant sections to it. A local and section of computer configuration,
        //and a non-local section that stores profile info related to the game itself only that can be stored in the steam cloud.
        //Right now it needs a startup profile, which needs to be removed later.

        //Public
        public ProfileMngr()
        {
            profileLib = new Dictionary<string, Profile>();
            
            findProfiles(profileLib);
        }

        //Functions
        public bool checkForProfile(string passedKey)
        {
            if (profileLib.ContainsKey(passedKey))
                return true;

            return false;   
        }

        public int getProfileNum()
        {
            int numProfiles = 0;

            foreach (KeyValuePair<string, Profile> profile in profileLib)
            {
                numProfiles++;
            }

            return numProfiles;
        }

        public void createProfile(string name)   //Using startup needs to be removed, needs to remember settings of last user.
        {
            string path = @"Users\" + name;       //Console.WriteLine("Creating profile folder." + "\n");

            if (!profileLib.ContainsKey(name))
            {
                if   (!Directory.Exists(path))
                    Directory.CreateDirectory(path);
                else
                    throw new Exception("Profile directory already exists... But not in the profile registry.");

                profileLib.Add(name, new Profile { profileName = name, profilePath = path });
            }
            else
                throw new Exception("Profile already exists.");

            setProfile(name);

            StndOptions.createPaths();
            AR.display .saveDisplay();
        }

        public void deleteProfile(string name)
        {
            string path = @"Users\" + name;

            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
                profileLib.Remove(name);
            }
        }

        public void setProfile(string passedKey)
        {
            foreach (KeyValuePair<string, Profile> profile in profileLib)
                if (profileLib.ContainsKey(passedKey))
                    currentProfile = profile.Value;
        }


        public class Profile
        {
            public string profileName { get; set; }
            public string profilePath { get; set; }
        }

        public Dictionary<string, Profile> profileLib;

        public static Profile currentProfile;

        //Private
        private void findProfiles(Dictionary<string, Profile> passedProfiles)   //Lookup sql lite(sync qube), neutonsoft.jsoft
        {
            string[] profilesFound = Directory.GetDirectories(@"Users");

            foreach(var file in profilesFound)
            {
                FileInfo info   = new FileInfo(file);
                string name     = info.Name         ;   
                string filePath = info.ToString   ();

                passedProfiles.Add(name, new Profile { profileName = name, profilePath = filePath });
            }
        }
    }
}