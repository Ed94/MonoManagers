//C#
using System;
using System.Collections.Generic      ;
//Monogame
using Microsoft.Xna.Framework.Content ;
using Microsoft.Xna.Framework.Graphics;
//Game
using static Content.AssetLib;

namespace Content
{
    public class AssetMngr
    {
        private        ContentManager manager        ;
        public  static GraphicsDevice gDevice        ;
        public  static SpriteBatch    spriteBatch    ;   //Handles sprites  in some unknown wa
        public  static SpriteEffects  spriteEffect   ;
        public  static BasicEffect    basicEffect    ;   //The spritebatch of 3D visual resources.
        private        AssetLib       resourceLibrary;

        public static Dictionary<string, SpriteFont> currentFonts   ;
        public static Dictionary<string, Texture2D>  currentTextures;

        //Constructor
        public AssetMngr(ContentManager manager, GraphicsDevice passedgDevice)
        {
            gDevice = passedgDevice;
                                                                        Console.WriteLine("Running Resource Manager."+ "\n"              );
            this.manager = manager;                                     Console.WriteLine("Passed ContentManger to the Resoruce Manager.");

            spriteBatch      = new SpriteBatch            (gDevice);    Console.WriteLine("Created SpritBatch."                          );
            spriteEffect     = new SpriteEffects                 ();
            basicEffect      = new BasicEffect            (gDevice);
            resourceLibrary  = new AssetLib                      ();
            currentFonts     = new Dictionary<string, SpriteFont>();
            currentTextures  = new Dictionary<string, Texture2D >();

            //basicEffect.GraphicsDevice.PresentationParameters.MultiSampleCount = 4;
        }

        //Reguarding the Loading of resources.
        public void  LoadResource(string key)   //Allows the loading of a single texture
        {                                                                               Console.WriteLine("Beginning to load texture from key: "+ key            ); Console.WriteLine("Getting resource type...");
            Type   type       = resourceLibrary.getResrouceType    (key);               Console.WriteLine(type); Console.WriteLine("Getting resource location...");
            string location   = resourceLibrary.getResrouceLocation(key);   //Need to fix the way location stores its paths.
                                                                                        Console.WriteLine(location            );     
            string identifier = key + resourceLibrary.getResourceName(key);             Console.WriteLine("Loading resource..");

            if (type.Equals(typeof(Texture2D )))
            {
                currentTextures.Add(identifier, manager.Load<Texture2D>(location));
            }
            if (type.Equals(typeof(SpriteFont)))
            {
                currentFonts   .Add(identifier, manager.Load<SpriteFont>(location));
            }
            checkLoad(identifier, type);
        }

        public void LoadStateResource(string partialKey)   //Allows the loading of all the textures related the partial key given.
        {                                                                                    Console.WriteLine("Loading textures with partial key: " + partialKey);
            List<Asset> stateResources = resourceLibrary.getStateResource(partialKey);       Console.WriteLine("Resources Received."                             );
            
            foreach (Asset resource in stateResources)
            {
                Console.WriteLine(resource.Name);
            }

            foreach (Asset resource in stateResources)
            {
                string name     = resource.Name    ;
                Type   type     = resource.Type    ;
                string location = resource.Location;

                string key = resourceLibrary.generateKey(location, name);

                if (type.Equals(typeof(SpriteFont)))
                {
                    currentFonts   .Add(key, manager.Load<SpriteFont>(location));
                }
                if (type.Equals(typeof(Texture2D )))
                {
                    currentTextures.Add(key, manager.Load<Texture2D >(location));
                }
                checkLoad(key, type);
            }
        }

        private void checkLoad(string key, Type type)
        {
            if (type.Equals(typeof(Texture2D)))
            {
                Console.WriteLine("Checking if resource was loaded." + "\n" + "Resoruce Loaded Key: " + key + "Texture: " + currentTextures[key].Name   );
            }
            if (type.Equals(typeof(SpriteFont)))
            {
                Console.WriteLine("Checking if resource was loaded." + "\n" + "Resoruce Loaded Key: " + key + "Font: "    + currentFonts   [key].Texture);
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
