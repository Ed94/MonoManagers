//C#
using System;
using System.Collections.Generic;
using System.IO;
//Monogame
using Microsoft.Xna.Framework.Graphics;


namespace AbstractRealm.Assets
{
    public class AssetLib   //See to moving this inside Abstract Realm.
    {
        //Public
        public AssetLib()
        {                                                       //Console.WriteLine("Running Resource Library"+ "\n");
            assetsLibrary = new Dictionary<string, Asset>();

            populateAssetsLib(assetsLibrary);
            //checkAssets      (assetsLibrary);
        }


        public class Asset   //A single indexed resource that can be used in the game.
        {
            public string Name     { get; set; }   //Stores the name of the resource.
            public string Location { get; set; }   //Stores the path to the resrouce.
            public Type   Type     { get; set; }   //Stores the type of the resource.
        }


        public string generateKey(string filePath, string name)   //Current Method for indexing all assets for the game.
        {
            string key;   //In order for a asset to be used, it must be organized in a content folder and 
                          //able organized in similar fasion as below.
                          //Key creation can either be manually done as below or use the else uses the filePath which may be less ideal.

            //Fonts
            if (filePath.Contains("Fonts")) { key = "font_"+ name; return key; }
            //Char Text
            if (filePath.Contains("selection"   )) { key = "miramo_chars_"      + name;  return key; }
            if (filePath.Contains("miramo_chars"))
            {
                if (filePath.Contains("caps"  )) { key = "miramo_chars_caps_"  + name; return key; }
                if (filePath.Contains("digits")) { key = "miramo_chars_digit_" + name; return key; }
                if (filePath.Contains("lows"  )) { key = "miramo_chars_lows_"  + name; return key; }
                if (filePath.Contains("blank" )) { key = "miramo_chars_"       + name; return key; }
                if (filePath.Contains("delete")) { key = "miramo_chars_"       + name; return key; }
                if (filePath.Contains("enter" )) { key = "miramo_chars_"       + name; return key; }
                return "";
            }
            else    return filePath;
        }

        //Reguarding giving of information.
        public string getAssetName (string key)
        { return assetsLibrary[key].Name; }

        public string getAssetLocation(string name)
        {
            if   (assetsLibrary.ContainsKey(name) == true) return assetsLibrary[name].Location;
            else                                           return "Not Found"                 ;
        }

        public Type getAssetType(string key)
        { return assetsLibrary[key].Type; }

        public List<Asset> getStateAsset(string key)
        {
            List<Asset> stateAssets = new List<Asset>();

            foreach (KeyValuePair<string, Asset> asset in assetsLibrary)
                if (asset.Key.Contains(key))
                    stateAssets.Add(asset.Value);

            return stateAssets;
        }

        //Private
        private void checkAssets(Dictionary<string, Asset> assets)   //Goes through each resource cataloged inside of the resource library and gets all information for each resource.
        {
            Console.WriteLine("Checking resource library..." + "\n");

            foreach (KeyValuePair<string, Asset> asset in assets)
            {
                Console.WriteLine("Key     : " + asset.Key);
                Console.WriteLine("Name    : " + asset.Value.Name);
                Console.WriteLine("Type    : " + asset.Value.Type);
                Console.WriteLine("Location: " + asset.Value.Location + "\n");
            }
        }

        private Type deterAssetType(string filePath)   //Used for determining the type of resource found.
        {
            if   (filePath.Contains("Fonts"  )) return typeof(SpriteFont);
            if   (filePath.Contains("Visuals")) return typeof(Texture2D );
            else                                return null              ;
        }

        private void populateAssetsLib(Dictionary<string, Asset> assets)   //Finds and audits all resources of the game.
        {                                                                                                       //Console.WriteLine("Populating resource dictionary.");
            string[] assetsFound = Directory.GetFiles(@"Content", "*.*", SearchOption.AllDirectories);   //Finds every single file inside of the Content directory of the game.
                                                                                                                //Console.WriteLine("\n" + "Resources Found: " + "\n");
            foreach (var file in assetsFound)   //Uses the FileInfo class to generate a filename, filepath, and type for the resource found, then adds them to the resource dictionary.
            {
                FileInfo info     = new FileInfo  (file          );
                string   name     = info.Name                     ;
                string   filePath = info.ToString               ();
                string   key      = generateKey   (filePath, name);
                Type     type     = deterAssetType(filePath      );                                             //Console.Write("Name: "+ name+ " Path: "+ filePath+ " Type: "+ type);

                //Additional formating before storing
                name     = name    .Replace(".xnb"     , "" );
                filePath = filePath.Replace("Content\\", "" );
                filePath = filePath.Replace("\\"       , "/");
                filePath = filePath.Replace(".xnb"     , "" );

                assetsLibrary.Add(key, new Asset { Name = name, Type = type, Location = filePath });             //Console.Write    (" Added to resource library dictionary."+ "\n");
            }                                                                                                    //Console.WriteLine                                              ();
        }
        private Dictionary<string, Asset> assetsLibrary;   //Contains a collection of all nessescary information reguarding all resources used by the game.
    }
}