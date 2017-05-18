//C#
using System;
using System.IO;

//DIV

namespace AbstractRealm.Options
{
    public class StndOptions  //Standard Options
    {
        //Constructor
        public StndOptions()
        {
            Console.WriteLine("Running Standard Options class.");
        }

        //Methods
        public static void createPaths()
        {                                               Console.WriteLine("Creating Options folder." + "\n");
            string OptionsPath = @"Users";
                   OptionsPath = Path.Combine(OptionsPath, ProfileMngr.currentProfile.profileName);
                   OptionsPath = Path.Combine(OptionsPath, "Options"                             );         

            Directory.CreateDirectory(OptionsPath);
        }
    }
}