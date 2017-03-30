//C#
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//DIV
using AbstractRealm;

namespace AbstractRealm.Options
{
    class StndOptions  //Standard Options
    {
        //Constructor
        public StndOptions(bool firstRun, Profile profile)
        {
                                                                Console.WriteLine("Running Standard Options class.");
            if (firstRun == true)
            {
                                                                Console.WriteLine("Detected first run.");
                createPaths(profile);
            }
        }

        //Methods
        private void createPaths(Profile profile)
        {
            string OptionsPath = @"Users";
                   OptionsPath = Path.Combine(OptionsPath, profile.Name);
                   OptionsPath = Path.Combine(OptionsPath, "Options"   );       Console.WriteLine("Creating Options folder." + "\n");

            Directory.CreateDirectory(OptionsPath);
        }
    }
}