﻿        //This is a massive WIP. Learning 3D implamentation for this game.
//Monogame
using Microsoft.Xna.Framework;
//DIV
using AbstractRealm.Assets;
using Microsoft.Xna.Framework.Graphics;
using System;
using Dreams_in_Vapor;

namespace AbstractRealm.Realm_Space
{
    public class SpaceMngr
    {

        //Related to the Camera.
        private float   farPlaneDist;
        private float   fieldOfView  ;
        private float   nearPlaneDist;
        public static  float scale;
        public static float scaleY;
        
        

        public static Vector2 center;
        public static Vector2 scaleVec2D;

        public static Vector3 camPosition;
        public static Vector3 camTarget  ;
        public static Vector3 scaleVec3D;

        public static Matrix view         ;   //ViewMatrix       Equivalent
        public static Matrix camPerception;   //ProjectionMatrix Equivalent
        public static Matrix area         ;   //Considered the world matrix by monogame. 

        
        private float  aspectRatio;



        public SpaceMngr()
        {
            Console.WriteLine("We are in space manaer");
            fieldOfView   = MathHelper.ToRadians(90f);

            nearPlaneDist =  .0001f;
            farPlaneDist  =  10000f;

            camTarget     = Vector3.Zero;
            camPosition   = new Vector3(0f, 0f,  -100f);   //3D position of the player's perspective view for monogame.

            center = new Vector2(AssetMngr.gDevice.Viewport.Width / 2, AssetMngr.gDevice.Viewport.Height / 2);

            aspectRatio = (float)AssetMngr.gDevice.Viewport.Width / (float)AssetMngr.gDevice.Viewport.Height;           Console.WriteLine(aspectRatio);
            
            scale     = (float)Math.Pow(1, aspectRatio);

            Console.WriteLine(aspectRatio);
            camPerception = Matrix.CreatePerspectiveFieldOfView(fieldOfView, AssetMngr.gDevice.Viewport.AspectRatio, nearPlaneDist, farPlaneDist);
            view          = Matrix.CreateLookAt                (camPosition, camTarget                                   , Vector3.Up                 );
            area          = Matrix.CreateWorld                 (camTarget  , Vector3.Forward                             , Vector3.Up                 );
        }

        public Matrix getCamPerception()
        {
            return camPerception;
        }
    }
}

//General Stuff here.
//private static float   angleInRadians;
//private static float   pitch;
//private static float   roll;
//private static float   yaw;
//private static Vector3 axis;
//private static Vector3 position;

//private static Matrix translation = Matrix.CreateTranslation     (position            ); A way to create a world matrix according to: http://rbwhitaker.wikidot.com/monogame-basic-matrices
//private static Matrix rotationX   = Matrix.CreateRotationX       (angleInRadians      );
//private static Matrix rotationY   = Matrix.CreateRotationY       (angleInRadians      );
//private static Matrix rotationZ   = Matrix.CreateRotationZ       (angleInRadians      );
//private static Matrix axisAngle   = Matrix.CreateFromAxisAngle   (axis, angleInRadians);
//private static Matrix YPR         = Matrix.CreateFromYawPitchRoll(yaw , pitch, roll   );
//private static Matrix rotMov = rotationX * translation;