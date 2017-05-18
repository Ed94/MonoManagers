﻿using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AbstractRealm.Assets
{
    public class AssetMngr   //See to moving this inside abstract realm.
    {
        private        ContentManager manager     ;
        public  static GraphicsDevice gDevice     ;
        public         SpriteBatch    spriteBatch ;   //Handles sprites  in some unknown wa
        public  static SpriteEffects  spriteEffect;   //Believed to be used for shaders. Still unsure of its exact nature.
        public         BasicEffect    basicEffect ;   //The spritebatch of 3D visual resources. (I think.)
        private        AssetLib       assetLibrary;

        public static Dictionary<string, SpriteFont> currentFonts   ;
        public static Dictionary<string, Texture2D>  currentTextures;

        //Constructor
        public AssetMngr(ContentManager manager, GraphicsDevice passedgDevice)
        {
            gDevice = passedgDevice;
                                                                        Console.WriteLine("Running asset Manager."+ "\n"              );
            this.manager = manager;                                     Console.WriteLine("Passed ContentManger to the asset Manager.");

            spriteBatch     = new SpriteBatch            (gDevice);     Console.WriteLine("Created SpriteBatch."                          );
            spriteEffect    = new SpriteEffects                 ();
            basicEffect     = new BasicEffect            (gDevice);
            assetLibrary    = new AssetLib                      ();
            currentFonts    = new Dictionary<string, SpriteFont>();
            currentTextures = new Dictionary<string, Texture2D >();
        }

        //Reguarding the Loading of resources.
        public void  LoadAsset(string key)   //Allows the loading of a single texture
        {                                                                               //Console.WriteLine("Beginning to load texture from key: "+ key); Console.WriteLine("Getting resource type...");
            Type   type     = assetLibrary.getAssetType    (key);                       //Console.WriteLine(type); Console.WriteLine("Getting asset location...");
            string location = assetLibrary.getAssetLocation(key);   //Need to fix the way location stores its paths.
                                                                                        //Console.WriteLine(location            );     
            string identifier = key + assetLibrary.getAssetName(key);                   //Console.WriteLine("Loading resource..");

            if (type.Equals(typeof(Texture2D )))
            {
                currentTextures.Add(identifier, manager.Load<Texture2D>(location));
            }
            if (type.Equals(typeof(SpriteFont)))
            {
                currentFonts   .Add(identifier, manager.Load<SpriteFont>(location));
            }
            //checkLoad(identifier, type);
        }

        public void LoadStateAsset(string partialKey)   //Allows the loading of all the textures related the partial key given.
        {                                                                                    //Console.WriteLine("Loading textures with partial key: " + partialKey);
            List<AssetLib.Asset> stateAssets = assetLibrary.getStateAsset(partialKey);             //Console.WriteLine("Resources Received."                             );
            
            //foreach (Asset resource in stateResources)
            //{
            //    Console.WriteLine(resource.Name);
            //}

            foreach (AssetLib.Asset resource in stateAssets)
            {
                string name     = resource.Name    ;
                Type   type     = resource.Type    ;
                string location = resource.Location;

                string key = assetLibrary.generateKey(location, name);

                if (type.Equals(typeof(SpriteFont)))
                {
                    if (currentFonts.ContainsKey(key) == false)
                    {
                        currentFonts.Add(key, manager.Load<SpriteFont>(location));
                    }
                }
                if (type.Equals(typeof(Texture2D )))
                {
                    if (currentTextures.ContainsKey(key) == false)
                    {
                        currentTextures.Add(key, manager.Load<Texture2D>(location));
                    }
                }
                //checkLoad(key, type);
            }
        }

        private void checkLoad(string key, Type type)
        {
            if (type.Equals(typeof(Texture2D)))
            {
                Console.WriteLine("Checking if asset was loaded." + "\n" + "Resoruce Loaded Key: " + key + "Texture: " + currentTextures[key].Name   );
            }
            if (type.Equals(typeof(SpriteFont)))
            {
                Console.WriteLine("Checking if asset was loaded." + "\n" + "Resoruce Loaded Key: " + key + "Font: "    + currentFonts   [key].Texture);
            }
        }

        public void unload()
        {
            manager        .Unload();
            currentFonts   .Clear ();
            currentTextures.Clear ();
        }
    }
}