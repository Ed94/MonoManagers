//C#
using System   ;
using System.IO;


namespace AbstractRealm.Options
{
    public class StndOptions  //Standard Options
    {
        //Public
        public StndOptions()
        { setup(); }


        public static void createPaths()
        {
            string OptionsPath = @"Users"                                                         ;
                   OptionsPath = Path.Combine(OptionsPath, ProfileMngr.currentProfile.profileName);
                   OptionsPath = Path.Combine(OptionsPath, "Options"                             );         

            Directory.CreateDirectory(OptionsPath);
        }

        public ushort updateRate { get; set; }

        //Private
        private void setup()
        { updateRate = 1000; }
    }
}