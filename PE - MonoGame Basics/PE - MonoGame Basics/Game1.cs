using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PE___MonoGame_Basics
{
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
        private KeyboardState prevKbs;
        private SpriteFont LabelFont;
        private SpriteFont BounceFont;

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

            // set Texture2D to RITlogo
            image = Content.Load<Texture2D>("RITlogo");

            // set Vector2 position
            position = new Vector2(10f, 50f);

            // set width and height of window
            _graphics.PreferredBackBufferWidth = 1000;
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

            // move image
            position += new Vector2(horizontalMovement, verticalMovement);

            // check if image hits either horizontal border
            if (image.Width + position.X >= _graphics.PreferredBackBufferWidth || position.X <= 0)
            {
                // switch horizontal direction
                horizontalMovement *= -1;
            }
            // check if image hits either vertical border
            if (image.Height + position.Y >= _graphics.PreferredBackBufferHeight || position.Y <= 0)
            {
                // switch vertical direction
                verticalMovement *= -1;
            }

            // process keyboard input
            ProcessInput();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            // set background color to gray
            GraphicsDevice.Clear(Color.Gray);

            // TODO: Add your drawing code here

            _spriteBatch.Begin();

            // draw image at position with no tint
            _spriteBatch.Draw(image, position, Color.White);

            // draw rectangle image, red tint
            _spriteBatch.Draw(image, rectangle, Color.Red);

            // 
            _spriteBatch.DrawString(LabelFont, "sample text", new Vector2(10, 10), Color.Black);

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        private void ProcessInput()
        {
            // init Keyboard.GetState
            KeyboardState kbs = Keyboard.GetState();

            if (kbs.IsKeyDown(Keys.Space) && prevKbs.IsKeyUp(Keys.Space))
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

            prevKbs = kbs;
        }
    }
}
