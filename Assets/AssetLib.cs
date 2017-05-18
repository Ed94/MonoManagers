using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Xna.Framework.Graphics;


namespace AbstractRealm.Assets
{
    public class AssetLib   //See to moving this inside Abstract Realm.
    {
        private Dictionary<string, Asset> assetsLibrary;   //Contains a collection of all nessescary information reguarding all resources used by the game.

        //Subclasses
        public class Asset   //A single indexed resource that can be used in the game.
        {
            public string Name     { get; set; }   //Stores the name of the resource.
            public Type   Type     { get; set; }   //Stores the type of the resource.
            public string Location { get; set; }   //Stores the path to the resrouce.
        }

        //Constructor
        public AssetLib()
        {                                                       //Console.WriteLine("Running Resource Library"+ "\n");
            assetsLibrary = new Dictionary<string, Asset>();

            populateAssetsLib(assetsLibrary);
            //checkAssets      (assetsLibrary);
        }

        //Methods
        //Reguarding collection of resource information.
        private void populateAssetsLib(Dictionary<string, Asset> assets)   //Finds and audits all resources of the game.
        {
                                                                                                                //Console.WriteLine("Populating resource dictionary.");
            string[] assetsFound = Directory.GetFiles(@"Content", "*.*", SearchOption.AllDirectories);   //Finds every single file inside of the Content directory of the game.
                                                                                                                //Console.WriteLine("\n" + "Resources Found: " + "\n");
            foreach (var file in assetsFound)   //Uses the FileInfo class to generate a filename, filepath, and type for the resource found, then adds them to the resource dictionary.
            {
                FileInfo info     = new FileInfo     (file          );
                string   name     = info.Name                        ;
                string   filePath = info.ToString                  ();
                Type     type     = deterAssetType   (filePath      );
                string   key      = generateKey      (filePath, name);                                          //Console.Write("Name: "+ name+ " Path: "+ filePath+ " Type: "+ type);

                //Additional formating before storing
                name     = name.Replace    (".xnb"     , "" );
                filePath = filePath.Replace("Content\\", "" );
                filePath = filePath.Replace("\\"       , "/");
                filePath = filePath.Replace(".xnb"     , "" );

                assetsLibrary.Add(key, new Asset { Name = name, Type = type, Location = filePath });             //Console.Write    (" Added to resource library dictionary."+ "\n");
            }                                                                                                    //Console.WriteLine                                              ();
        }

        private Type deterAssetType(string filePath)   //Used for determining the type of resource found.
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
            //Char Text
            if (filePath.Contains("selection"        )) { key = "miramo_chars_"      + name;  return key; }
            if (filePath.Contains("miramo_chars"     ))
            {
                if (filePath.Contains("caps"  )) { key = "miramo_chars_caps_"  + name; return key; }
                if (filePath.Contains("digits")) { key = "miramo_chars_digit_" + name; return key; }
                if (filePath.Contains("lows"  )) { key = "miramo_chars_lows_"  + name; return key; }
                if (filePath.Contains("blank" )) { key = "miramo_chars_"       + name; return key; }
                if (filePath.Contains("delete")) { key = "miramo_chars_"       + name; return key; }
                if (filePath.Contains("enter" )) { key = "miramo_chars_"       + name; return key; }
                return "";
            }
            if (filePath.Contains("miramo_chars/lows")) { key = "miramo_chars_lows"  + name;  return key; }
            //UI
            if(filePath.Contains("UI")) { key = "UI_" + name; return key; }

            else { return ""; }
        }

        //Reguarding information checking.
        private void checkAssets(Dictionary<string, Asset> assets)   //Goes through each resource cataloged inside of the resource library and gets all information for each resource.
        {
            Console.WriteLine("Checking asset library..."+ "\n");
            foreach (KeyValuePair<string, Asset> asset in assets)
            {
                Console.WriteLine("Key     : "+ asset.Key                 );
                Console.WriteLine("Name    : "+ asset.Value.Name          );
                Console.WriteLine("Type    : "+ asset.Value.Type          );
                Console.WriteLine("Location: "+ asset.Value.Location+ "\n");
            }
        }

        //Reguarding giving of information.
        public string getAssetName(string key)
        {
            string name = assetsLibrary[key].Name;

            return name;
        }

        public Type getAssetType(string key)
        {
            Type type = assetsLibrary[key].Type;

            return type;
        }

        public string getAssetLocation(string name)
        {
            string location;

            if (assetsLibrary.ContainsKey(name) == true)
            {
                location = assetsLibrary[name].Location;

                return location;
            }
            else
            {
                return "Not Found";
            }
        }

        public List<Asset> getStateAsset(string key)
        {
            List<Asset> stateAssets = new List<Asset>();

            foreach (KeyValuePair<string, Asset> asset in assetsLibrary)
            {
                if (asset.Key.Contains(key))
                {
                    stateAssets.Add(asset.Value);
                }
            }
            return stateAssets;
        }
    }
}