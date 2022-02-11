using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PE___MonoGame_Basics
{
    // create enum for game states
    public enum GameStates
    {
        MainMenu,
        BounceMode,
        UserControlMode,
    }
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private Texture2D image;
        private Rectangle rectangle;
        private Vector2 position;
        // amount image moves
        private int horizontalMovement = 2;
        private int verticalMovement = 1;
        // speed at which rectangle moves
        private int speed = 1;
        private int bounce = 0;
        private KeyboardState prevKbs;
        private SpriteFont LabelFont;
        private SpriteFont BounceFont;
        private GameStates currentState = GameStates.MainMenu;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            base.Initialize();

            this.IsMouseVisible = true;

            // set Texture2D to RITlogo
            image = Content.Load<Texture2D>("RITlogo");

            // set Vector2 position
            position = new Vector2(10f, 50f);

            // set width and height of window
            _graphics.PreferredBackBufferWidth = 600;
            _graphics.PreferredBackBufferHeight = 600;

            // initialize rectangle, center of window, half width/height of image
            rectangle = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - (image.Width / 4),
                (_graphics.PreferredBackBufferHeight / 2) - (image.Height / 4), image.Width / 2, image.Height / 2);

            _graphics.ApplyChanges();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            LabelFont = Content.Load<SpriteFont>("LabelFont");
            BounceFont = Content.Load<SpriteFont>("BounceFont");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            // get current device states
            KeyboardState kbs = Keyboard.GetState();
            MouseState mState = Mouse.GetState();

            // different process based on current state
            switch (currentState)
            {
                case GameStates.MainMenu:
                    ProcessMainMenu(kbs);
                    break;

                case GameStates.BounceMode:
                    ProcessBounceMode(kbs, mState);
                    break;

                case GameStates.UserControlMode:
                    ProcessUserMode(kbs, mState);
                    break;

                default:
                    break;
            }

            // store as previous keyboard state
            prevKbs = kbs;

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // set background color to gray
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            // draw based on different states
            switch (currentState)
            {
                case GameStates.MainMenu:
                    // display instructions at bottom
                    _spriteBatch.DrawString(BounceFont,
                        "Welcome to Jack and Tyler's MonoGame Demo!\nPress B to see some bouncing.\nPress U to control the image yourself.",
                        new Vector2(0, _graphics.PreferredBackBufferHeight * 0.8f), Color.Black);
                    break;

                case GameStates.BounceMode:
                    // draw image at position with no tint
                    _spriteBatch.Draw(image, position, Color.White);

                    // display bounce count
                    _spriteBatch.DrawString(BounceFont, "" + bounce,
                        new Vector2(_graphics.PreferredBackBufferWidth / 2,
                        _graphics.PreferredBackBufferHeight / 2), Color.Black);

                    // display instructions at bottom
                    _spriteBatch.DrawString(BounceFont,
                        "Press M to go back to the main menu.\nPress the right mouse button to reset.",
                        new Vector2(0, _graphics.PreferredBackBufferHeight * 0.8f), Color.Black);
                    break;

                case GameStates.UserControlMode:
                    // draw rectangle image, red tint
                    _spriteBatch.Draw(image, rectangle, Color.Red);

                    // display name, speed and X/Y positions of keyboard controlled image
                    _spriteBatch.DrawString(LabelFont, "jack  " + speed + "(" + rectangle.X
                        + ", " + rectangle.Y + ")", new Vector2(10, 10), Color.Black);

                    // display instructions at bottom
                    _spriteBatch.DrawString(BounceFont,
                        "Press M to go back to the main menu.\nPress the right mouse button to reset.",
                        new Vector2(0, _graphics.PreferredBackBufferHeight * 0.8f), Color.Black);
                    break;

                default:
                    break;
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        /// receives key, keyboard state as params
        /// returns if key was just pressed
        private bool SingleKeyPress(Keys key, KeyboardState currentKbs)
        {
            return currentKbs.IsKeyDown(key) && prevKbs.IsKeyUp(key);
        }

        private void ProcessMainMenu(KeyboardState kbs)
        {
            // change to appropriate state if B or U pressed
            if (SingleKeyPress(Keys.B, kbs))
                currentState = GameStates.BounceMode;
            if (SingleKeyPress(Keys.U, kbs))
                currentState = GameStates.UserControlMode;
        }
        private void ProcessBounceMode(KeyboardState kbs, MouseState mState)
        {
            // move image
            position += new Vector2(horizontalMovement, verticalMovement);

            // check if image hits either horizontal border
            if (image.Width + position.X >= _graphics.PreferredBackBufferWidth || position.X <= 0)
            {
                // switch horizontal direction
                horizontalMovement *= -1;
                bounce++;
            }
            // check if image hits either vertical border
            if (image.Height + position.Y >= _graphics.PreferredBackBufferHeight || position.Y <= 0)
            {
                // switch vertical direction
                verticalMovement *= -1;
                bounce++;
            }

            if (SingleKeyPress(Keys.M, kbs))
                currentState = GameStates.MainMenu;

            // check if right mouse button pressed
            //   then reset position, bounce count
            if (mState.RightButton == ButtonState.Pressed)
            {
                position = new Vector2(0, 0);
                bounce = 0;
            }
        }
        private void ProcessUserMode(KeyboardState kbs, MouseState mState)
        {
            // increase speed if space pressed
            if (SingleKeyPress(Keys.Space, kbs))
            {
                speed++;
            }

            // move up
            if (kbs.IsKeyDown(Keys.W))
            {
                rectangle.Y -= speed;
            }
            // move left
            if (kbs.IsKeyDown(Keys.A))
            {
                rectangle.X -= speed;
            }
            // move down
            if (kbs.IsKeyDown(Keys.S))
            {
                rectangle.Y += speed;
            }
            // move right
            if (kbs.IsKeyDown(Keys.D))
            {
                rectangle.X += speed;
            }

            // if M pressed, go to Main Menu state
            if (SingleKeyPress(Keys.M, kbs))
                currentState = GameStates.MainMenu;

            // check if right mouse button pressed
            //   then reset speed, position
            if (mState.RightButton == ButtonState.Pressed)
            {
                rectangle = new Rectangle((_graphics.PreferredBackBufferWidth / 2) - (image.Width / 4),
                (_graphics.PreferredBackBufferHeight / 2) - (image.Height / 4), image.Width / 2, image.Height / 2);
                speed = 1;
            }
        }
        
    }
}
