//C#
using System;
using System.Collections.Generic;
using System.IO;
//Monogame
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
//Game
using AbstractRealm.Interface;
using Content;

namespace AbstractRealm.Options
{
    class Display   //Manages Things related to videocard output.
    {
        public static bool               showFPS      = false                  ;
        public static FrameCounter       framecounter = new FrameCounter     ();
        private static List<DisplayMode> supportedRes = new List<DisplayMode>();   //Holds supportedDisplayResolutions while program is running.
        private GraphicsDeviceManager gDevice;

        private static string[] display =   //Holds display settings while program is running.
        {                              //Index
            "Resolution:"          ,   //0
            "1280"                 ,   //1
            "720"                  ,   //2
            "Fullscreen    = false",   //3
            "VSync         = false",   //4
            "Multisampling = false",   //5
            "ShowFPS       = true",    //6
        };

        //Other things...
        //this.TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 33);   // 30 FPS

        //Constructor
        public Display(bool firstRun, Profile profile, GraphicsDeviceManager passedGDevice)
        {                                       Console.WriteLine("Running Display          class."+ "\n");
            gDevice = passedGDevice;

            gDevice.HardwareModeSwitch = false;

            if (firstRun == true)
            {
                saveDisplay(profile);

            }

            getSupportedRes  (profile );
            readDisplay      (profile );
            update(passedGDevice);
        }

        //General Methods
        public void update(GraphicsDeviceManager gDeviceMngr)
        {
            //Resolution
            int width  = gDeviceMngr.PreferredBackBufferWidth  = Int32.Parse(display[1]);
            int height = gDeviceMngr.PreferredBackBufferHeight = Int32.Parse(display[2]);
            //Fullscreen
            if   (display[3].Contains("true")) { gDeviceMngr.IsFullScreen = true ; }
            else                               { gDeviceMngr.IsFullScreen = false; }
            //VSync
            if   (display[4].Contains("true")) { gDeviceMngr.SynchronizeWithVerticalRetrace = true ; }
            else                               { gDeviceMngr.SynchronizeWithVerticalRetrace = false; }
            //Multisampling
            if   (display[5].Contains("true")) { gDeviceMngr.PreferMultiSampling = true ; }
            else                               { gDeviceMngr.PreferMultiSampling = false; }

            gDeviceMngr.ApplyChanges();
        }

        public void updatePPS()
        {
            framecounter.Update();
        }

        public void draw(SpriteBatch spriteBatch, BasicEffect basicEffect, float deltaTime)
        {
            //ShowFPS
            if (display[6].Contains("true")) { framecounter.Draw(spriteBatch, basicEffect, deltaTime); }
        }

        //Class I/O functions
        private void readDisplay(Profile profile)
        {
                                                                            Console.WriteLine("Getting display settings."+ "\n");
            String filePath = @"Users"                             ;
                   filePath = Path.Combine(filePath, profile.Name );
                   filePath = Path.Combine(filePath, "Options"    );
                   filePath = Path.Combine(filePath, "Display.txt");

            int index = 0;

            foreach (string line in File.ReadLines(filePath))
            {
                display[index] = line;
                                                                            Console.WriteLine(line);

                index++;
            }
                                                                            Console.WriteLine();
        }

        public void changeDisplay()
        {
            display[1] = "640";
            display[2] =  "480";
            display[3] = "Fullscreen    = false";

            update(gDevice);
        }

        private void saveDisplay(Profile profile)
        {
                                                                            Console.WriteLine("Saving Display Settings.");
            String filePath = @"Users"                             ;
                   filePath = Path.Combine(filePath, profile.Name );
                   filePath = Path.Combine(filePath, "Options"    );
                   filePath = Path.Combine(filePath, "Display.txt");

            using (StreamWriter file = new StreamWriter(filePath))
            {
                foreach (string line in display)
                    {
                        file.WriteLine(line);
                    }
            }
        }
        //Managing Supported Resolutions
        private void getSupportedRes(Profile profile)
        {
                                                                                                    Console.WriteLine("Getting supported resolutions."+ "\n");
            foreach (DisplayMode mode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
            {
                supportedRes.Add(mode);
            }

            String filePath = @"Users"                                           ;
                   filePath = Path.Combine(filePath, profile.Name               );
                   filePath = Path.Combine(filePath, "Options"                  );
                   filePath = Path.Combine(filePath, "Supported Resolutions.txt");
            
            using (StreamWriter file = new StreamWriter(filePath))
            {
                foreach (DisplayMode line in supportedRes)
                {
                    Console.WriteLine(line);
                    file.WriteLine(line);
                }
            }
            Console.WriteLine();
        }
        public static int getRes(string side)   //Get values related to resoltuion.
        {
            if      (side.Equals("height"))
            {
                return Int32.Parse(display[1]);
            }
            else if (side.Equals("width"))
            {
                return Int32.Parse(display[1]);
            }
            else
            {
                return 0;
            }
        }
    }
}
