using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace PE_MarioWalking
{

    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // The Mario to draw depending on the current state
        private Mario mario;

        // Constructor
        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Sets up the mario location
            Vector2 marioLoc = new Vector2(GraphicsDevice.Viewport.Width / 2, GraphicsDevice.Viewport.Height / 2);

            // Load the single spritesheet and create a new Mario object
            Texture2D spriteSheet = Content.Load<Texture2D>("Mario");

            mario = new Mario(spriteSheet, marioLoc, MarioState.FaceRight);
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // Handles animation for you
            mario.UpdateAnimation(gameTime);

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-
            // PRACTICE EXERCISE: Add your finite state machine code (switch statement) here!
            // - Be sure to check the finite state machine's state first
            // - Then check for specific transitions inside each state (may require keyboard input)
            // - Update Mario's state as needed

            // Step 1: Grab user input

            KeyboardState kbs = Keyboard.GetState();

            // act based on current state
            switch (mario.State)
            {
                // facing right
                case MarioState.FaceRight:
                    // face left on left arrow
                    if (kbs.IsKeyDown(Keys.Left))
                    {
                        mario.State = MarioState.FaceLeft;
                    }
                    // walk right on right arrow
                    else if (kbs.IsKeyDown(Keys.Right))
                    {
                        mario.State = MarioState.WalkRight;
                    }
                    else if (kbs.IsKeyDown(Keys.Down))
                    {
                        mario.State = MarioState.CrouchRight;
                    }
                    break;

                case MarioState.WalkRight:
                    if (kbs.IsKeyDown(Keys.Right))
                    {
                        mario.X++;
                    }
                    else if (kbs.IsKeyUp(Keys.Right))
                    {
                        mario.State = MarioState.FaceRight;
                    }
                    break;

                case MarioState.CrouchRight:
                    if (kbs.IsKeyUp(Keys.Down))
                    {
                        mario.State = MarioState.FaceRight;
                    }
                    break;

                // facing left
                case MarioState.FaceLeft:
                    // face right on right arrow
                    if (kbs.IsKeyDown(Keys.Right))
                    {
                        mario.State = MarioState.FaceRight;
                    }
                    // walk left on left arrow
                    else if (kbs.IsKeyDown(Keys.Left))
                    {
                        mario.State = MarioState.WalkLeft;
                    }
                    else if (kbs.IsKeyDown(Keys.Down))
                    {
                        mario.State = MarioState.CrouchLeft;
                    }
                    break;

                case MarioState.WalkLeft:
                    if (kbs.IsKeyDown(Keys.Left))
                    {
                        mario.X--;
                    }
                    else if (kbs.IsKeyUp(Keys.Left))
                    {
                        mario.State = MarioState.FaceLeft;
                    }
                    break;

                case MarioState.CrouchLeft:
                    if (kbs.IsKeyUp(Keys.Down))
                    {
                        mario.State = MarioState.FaceLeft;
                    }
                    break;
            }

            // Step 2: Change state

            // Step 3: Move Mario only when walking

            // *-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-*-

            base.Update(gameTime);
        }



        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // Begin the sprite batch
            _spriteBatch.Begin();

            mario.Draw(_spriteBatch);

            // End the sprite batch
            _spriteBatch.End();

            base.Draw(gameTime);
        }

    }
}
