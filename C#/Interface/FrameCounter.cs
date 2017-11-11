//C#
using System                    ;
using System.Collections.Generic;
using System.Linq               ;
using System.Text               ;
using System.Threading.Tasks    ;
//Monogame
using Microsoft.Xna.Framework         ;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input   ;
//AbstractRealm
using Game                 ;
using AbstractRealm.Options;
using AbstractRealm.Assets ;
using AbstractRealm.Input  ;

namespace AbstractRealm.Interface   //Need to get rid of this and implement a better performance statistics handler.
{
    public class FrameCounter : RealmControl   //Based on: http://stackoverflow.com/questions/20676185/xna-monogame-getting-the-frames-per-second
    {
        public const int MAXIMUM_SAMPLES = 4096;

        private static Queue<double> sampleBuffer   = new Queue<double>();

        public static long   totalFrames  { get; private set; }
        public static double totalSeconds { get; private set; }
        public static double averageFPS   { get; private set; }
        public static double currentFPS   { get; private set; }


        public static bool updateFps(float deltaTime)
        {
            currentFPS = 1.0d / deltaTime;

            sampleBuffer.Enqueue(currentFPS);

            if (sampleBuffer.Count > MAXIMUM_SAMPLES)
            {
                sampleBuffer.Dequeue();

                averageFPS = sampleBuffer.Average(i => i);
            }
            else
                averageFPS = currentFPS;

            totalFrames++            ;
            totalSeconds += deltaTime;

            return true;
        }

        public override void Update(InputMngr inputMngr)
        {

        }

        public void Draw(SpriteBatch spriteBatch, BasicEffect basicEffect, float deltaTime)
        {
            spriteBatch.Begin();

            foreach (KeyValuePair<string, SpriteFont> font in AssetMngr.currentFonts)
            {
                var fps = string.Format("FPS: {0}", currentFPS);

                spriteBatch.DrawString(font.Value, fps, new Vector2(1, 1), Color.HotPink);
            }

            spriteBatch.End();

            FrameCounter.updateFps(deltaTime);
        }

        public override void Draw()
        {

        }
    }
}