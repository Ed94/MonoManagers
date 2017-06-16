//C#
using System;
//Monogame
using Microsoft.Xna.Framework;
//BEPU
using BEPUphysics;

namespace AbstractRealm.Realm_Space
{
    public class SpaceMngr
    {
        //Public
        public SpaceMngr()
        {
            fieldOfView   = MathHelper.ToRadians(90f);

            nearPlaneDist =  .0001f;
            farPlaneDist  =  10000f;

            camTarget     = Vector3.Zero               ;
            camPosition   = new Vector3(0f, 0f,  -100f);   //3D position of the player's perspective view for monogame.

            center      = new Vector2(AR.assetMngr.gDevice.Viewport.Width / 2, AR.assetMngr.gDevice.Viewport.Height / 2);

            aspectRatio = (float)AR.assetMngr.gDevice.Viewport.Width / (float)AR.assetMngr.gDevice.Viewport.Height;

            scale       = (float)Math.Pow(1, aspectRatio);

            Console.WriteLine(aspectRatio);
            camPerception = Matrix.CreatePerspectiveFieldOfView(fieldOfView, AR.assetMngr.gDevice.Viewport.AspectRatio, nearPlaneDist, farPlaneDist);
            view          = Matrix.CreateLookAt                (camPosition, camTarget                                   , Vector3.Up                 );
            area          = Matrix.CreateWorld                 (camTarget  , Vector3.Forward                             , Vector3.Up                 );

            spacetest = new Space();

            BEPUutilities.Vector3 camPos = new BEPUutilities.Vector3(0f, 0f, -100f);
      
            camera = new Camera(camPos, 0.1f);
        }


        public Matrix getCamPerception()
        { return camPerception; }


        public static float scale ;
        public static float scaleY;

        public static Vector2 center    ;
        public static Vector2 scaleVec2D;

        public static Vector3 camPosition;
        public static Vector3 camTarget  ;
        public static Vector3 scaleVec3D ;

        public static Matrix view         ;   //ViewMatrix       Equivalent
        public static Matrix camPerception;   //ProjectionMatrix Equivalent
        public static Matrix area         ;   //Considered the world matrix by monogame. 

        public Camera camera   ;
        public Space  spacetest;

        //Private
        private float aspectRatio  ;
        private float farPlaneDist ;
        private float fieldOfView  ;
        private float nearPlaneDist;
    }
}