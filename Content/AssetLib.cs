//C#
using System                    ;
using System.Collections.Generic;
using System.IO                 ;
//Monogame
using Microsoft.Xna.Framework.Graphics;


namespace Content
{
    public class AssetLib
    {
        private Dictionary<string, Asset> resources;   //Contains a collection of all nessescary information reguarding all resources used by the game.

        //Subclasses
        public class Asset   //A single indexed resource that can be used in the game.
        {
            public string Name     { get; set; }   //Stores the name of the resource.
            public Type   Type     { get; set; }   //Stores the type of the resource.
            public string Location { get; set; }   //Stores the path to the resrouce.
        }

        //Constructor
        public AssetLib()
        {
                                                                Console.WriteLine("Running Resource Library"+ "\n");
            resources = new Dictionary<string, Asset>();

            populateResources(resources);
            checkResource    (resources);
        }

        //Methods
        //Reguarding collection of resource information.
        private void populateResources(Dictionary<string, Asset> resoruces)   //Finds and audits all resources of the game.
        {
                                                                                                                Console.WriteLine("Populating resource dictionary.");
            string[] resourcesFound = Directory.GetFiles(@"Content", "*.*", SearchOption.AllDirectories);   //Finds every single file inside of the Content directory of the game.
                                                                                                                Console.WriteLine("\n" + "Resources Found: " + "\n");
            foreach (var file in resourcesFound)   //Uses the FileInfo class to generate a filename, filepath, and type for the resource found, then adds them to the resource dictionary.
            {
                FileInfo info     = new FileInfo     (file          );
                string   name     = info.Name                        ;
                string   filePath = info.ToString                  ();
                Type     type     = deterResourceType(filePath      );
                string   key      = generateKey      (filePath, name);                                          Console.Write("Name: "+ name+ " Path: "+ filePath+ " Type: "+ type);

                //Additional formating before storing
                name     = name.Replace    (".xnb"     , "" );
                filePath = filePath.Replace("Content\\", "" );
                filePath = filePath.Replace("\\"       , "/");
                filePath = filePath.Replace(".xnb"     , "" );

                resources.Add(key, new Asset { Name = name, Type = type, Location = filePath });             Console.Write    (" Added to resource library dictionary."+ "\n");
            }                                                                                                   Console.WriteLine                                              ();
        }

        private Type deterResourceType(string filePath)   //Used for determining the type of resource found.
        {
            Type type;

            if (filePath.Contains("Fonts"))
            {
                type = typeof(SpriteFont);

                return type;

            }
            if (filePath.Contains("Visuals"))
            {
                type = typeof(Texture2D);

                return type;
            }
            else
            {
                return null;
            }
        }

        public string generateKey(string filePath, string name)
        {
            string key;

            //Fonts
            if (filePath.Contains("Fonts")) { key = "font_"+ name; return key; }
            //Abstract Realm
            if (filePath.Contains("ar_adventure" )) { key = "ar_adventure_" + name; return key; }
            if (filePath.Contains("ar_conception")) { key = "ar_conception_"+ name; return key; }
            if (filePath.Contains("ar_continue"  )) { key = "ar_continue_"  + name; return key; }
            if (filePath.Contains("ar_intro"     )) { key = "ar_intro_"     + name; return key; }
            if (filePath.Contains("ar_leave"     )) { key = "ar_leave_"     + name; return key; }
            if (filePath.Contains("ar_main"      )) { key = "ar_main_"      + name; return key; }
            if (filePath.Contains("ar_options"   )) { key = "ar_options_"   + name; return key; }
            if (filePath.Contains("ar_profile"   )) { key = "ar_profile_"   + name; return key; }
            if (filePath.Contains("ar_start"     )) { key = "ar_start_"     + name; return key; }
            //Adventure
            if (filePath.Contains("slum"               )) { key = "slum_"         + name; return key; }
            if (filePath.Contains("female"))
            { if (filePath.Contains("no_clothes")) { key = "female_no_clothes_" + name; return key; } return ""; }

            else { return ""; }
        }

        //Reguarding information checking.
        private void checkResource(Dictionary<string, Asset> resources)   //Goes through each resource cataloged inside of the resource library and gets all information for each resource.
        {
            Console.WriteLine("Checking resource library..."+ "\n");
            foreach (KeyValuePair<string, Asset> resoruce in resources)
            {
                Console.WriteLine("Key     : "+ resoruce.Key                 );
                Console.WriteLine("Name    : "+ resoruce.Value.Name          );
                Console.WriteLine("Type    : "+ resoruce.Value.Type          );
                Console.WriteLine("Location: "+ resoruce.Value.Location+ "\n");
            }
        }

        //Reguarding giving of information.
        public string getResourceName(string key)
        {
            string name = resources[key].Name;

            return name;
        }

        public Type getResrouceType(string key)
        {
            Type type = resources[key].Type;

            return type;
        }

        public string getResrouceLocation(string name)
        {
            string location;

            if (resources.ContainsKey(name) == true)
            {
                location = resources[name].Location;

                return location;
            }
            else
            {
                return "Not Found";
            }
        }

        public List<Asset> getStateResource(string key)
        {
            List<Asset> stateResources = new List<Asset>();

            foreach (KeyValuePair<string, Asset> resoruce in resources)
            {
                if (resoruce.Key.Contains(key))
                {
                    stateResources.Add(resoruce.Value);
                }
            }
            return stateResources;
        }
    }
}
