//C#
using System                    ;
using System.Collections.Generic;
using System.IO                 ;
//Monogame
using Microsoft.Xna.Framework         ;
using Microsoft.Xna.Framework.Graphics;
using AbstractRealm.Interface         ;
//AbstractRealm
using AbstractRealm.Input;


namespace AbstractRealm.Options
{
    public class Display   //Manages Things related to videocard output.
    {
        //Public
        public Display(GraphicsDeviceManager passedGDevice)
        {
            gDevice                    = passedGDevice;
            gDevice.HardwareModeSwitch = false;

            getSupportedRes             ();
            update         (passedGDevice);

            framerate = 144;
        }

        //General
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

        public void updatePPS(InputMngr inputMngr)
        { framecounter.Update(inputMngr); }

        public void draw(SpriteBatch spriteBatch, BasicEffect basicEffect, float deltaTime)
        {
            if (display[6].Contains("true"))
                framecounter.Draw(spriteBatch, basicEffect, deltaTime);
        }
        //Class I/O functions
        public void saveDisplay()
        {
            saveConfig     ();
            getSupportedRes();
        }

        private void readConfig()
        {
            String filePath = @"Users"                                                       ;
                   filePath = Path.Combine(filePath, ProfileMngr.currentProfile.profileName );
                   filePath = Path.Combine(filePath, "Options"                              );
                   filePath = Path.Combine(filePath, "Display.txt"                          );

            int index = 0;

            foreach (string line in File.ReadLines(filePath))
                display[index++] = line;
        }

        public void changeDisplay()
        {
            display[1] =  "1024";
            display[2] =   "768";
            display[3] = "Fullscreen = false";

            update(gDevice);
        }

        public void saveConfig()
        {
            String displayPath = @"Users"                                                         ;
                   displayPath = Path.Combine(displayPath, ProfileMngr.currentProfile.profileName);
                   displayPath = Path.Combine(displayPath, "Options"                             );
                   displayPath = Path.Combine(displayPath, "Display.txt"                         );

            String spResPath = @"Users"                                                       ;
                   spResPath = Path.Combine(spResPath, ProfileMngr.currentProfile.profileName);
                   spResPath = Path.Combine(spResPath, "Options"                             );
                   spResPath = Path.Combine(spResPath, "Supported Resolutions.txt"           );

            using (StreamWriter file = new StreamWriter(displayPath))
            {
                foreach (string      line in display     )
                    file.WriteLine(line);
                foreach (DisplayMode line in supportedRes)
                    file.WriteLine(line);
            }
        }
        //Managing Supported Resolutions
        private void getSupportedRes()
        {                                                                                     
            foreach (DisplayMode mode in GraphicsAdapter.DefaultAdapter.SupportedDisplayModes)
                supportedRes.Add(mode);
        }

        public static int getRes(string side)   //Get values related to resoltuion.
        {
            if      (side.Equals("height"))
                return Int32.Parse(display[1]);
            else if (side.Equals("width" ))
                return Int32.Parse(display[1]);
            else
                return -1;
        }

        public static bool  showFPS      = false;
        public FrameCounter framecounter = new FrameCounter();

        public ulong       framerate { get; set; }


        //Private
        private GraphicsDeviceManager gDevice;

        private List<DisplayMode> supportedRes = new List<DisplayMode>();

        private static string[] display =   //Holds display settings while program is running.
        {                              //Index
            "Resolution:"          ,   //0
            "1280"                 ,   //1
            "720"                  ,   //2
            "Fullscreen    = false",   //3
            "VSync         = false",   //4
            "Multisampling = false",   //5
            "ShowFPS       = true ",   //6
            "Borderless    = false",   //7
            "frameRate     = 144  ",   //8
        };

        //this.TargetElapsedTime = new System.TimeSpan(0, 0, 0, 0, 33);   // 30 FPS
    }
}