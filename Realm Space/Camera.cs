//Monogame
using Microsoft.Xna.Framework.Input;
//BEPU
using BEPUutilities;


namespace AbstractRealm.Realm_Space //Taken from BEPU's getting started demo. Needs to be heavily refactored.
{
    public class Camera
    {
        //Public
        /// <summary>
        /// Constructs a new camera.
        /// </summary>
        /// <param name="position">Initial position of the camera.</param>
        /// <param name="speed">Initial movement speed of the camera.</param>
        public Camera(Vector3 position, float speed)
        {
            this.position    = position;
            this.speed       = speed   ;

            projectionMatrix = Matrix.CreatePerspectiveFieldOfViewRH(MathHelper.PiOver4, 4f / 3f, .1f, 10000.0f);

            Mouse.SetPosition(200, 200);
        }
        /// <summary>
        /// Moves the camera forward using its speed.
        /// </summary>
        /// <param name="dt">Timestep duration.</param>
        public void MoveForward(float deltaTime)
        { position += worldMatrix.Forward * (deltaTime * speed);}
        /// <summary>
        /// Moves the camera right using its speed.
        /// </summary>
        /// <param name="dt">Timestep duration.</param>
        /// 
        public void MoveRight(float deltaTime)
        { position += worldMatrix.Right * (deltaTime * speed); }
        /// <summary>
        /// Moves the camera up using its speed.
        /// </summary>
        /// <param name="dt">Timestep duration.</param>
        /// 
        public void MoveUp(float deltaTime)
        { position += new Vector3(0, (deltaTime * speed), 0); }
        /// <summary>
        /// Updates the camera's view matrix.
        /// </summary>
        /// <param name="dt">Timestep duration.</param>
        public void Update(float deltaTime)
        {   //Turn based on mouse input.
            //Yaw   += (200 - Game.MouseState.X) * dt * .12f;
            //Pitch += (200 - Game.MouseState.Y) * dt * .12f;
            //Mouse.SetPosition(200, 200);
            worldMatrix = Matrix.CreateFromAxisAngle(Vector3.Right, Pitch) * Matrix.CreateFromAxisAngle(Vector3.Up, Yaw);

            float distance = speed * deltaTime;
            //Scoot the camera around depending on what keys are pressed.
            //if (Game.KeyboardState.IsKeyDown(Keys.E))
            //    MoveForward(distance);
            //if (Game.KeyboardState.IsKeyDown(Keys.D))
            //    MoveForward(-distance);
            //if (Game.KeyboardState.IsKeyDown(Keys.S))
            //    MoveRight(-distance);
            //if (Game.KeyboardState.IsKeyDown(Keys.F))
            //    MoveRight(distance);
            //if (Game.KeyboardState.IsKeyDown(Keys.A))
            //    MoveUp(distance);
            //if (Game.KeyboardState.IsKeyDown(Keys.Z))
            //    MoveUp(-distance);

            worldMatrix = worldMatrix * Matrix.CreateTranslation(position);
            viewMatrix = Matrix.Invert(worldMatrix);
        }


        public float   speed            { get; set; }
        public Matrix  projectionMatrix { get; set; }
        public Vector3 position         { get; set; }

        public float Pitch { get { return pitch; } set { pitch = MathHelper.Clamp    (value, -MathHelper.PiOver2, MathHelper.PiOver2); } }
        public float Yaw   { get { return yaw  ; } set { yaw   = MathHelper.WrapAngle(value                                         ); } }

        //Private
        float yaw  ;
        float pitch;

        public Matrix viewMatrix  { get; private set; }
        public Matrix worldMatrix { get; private set; }
    }
}