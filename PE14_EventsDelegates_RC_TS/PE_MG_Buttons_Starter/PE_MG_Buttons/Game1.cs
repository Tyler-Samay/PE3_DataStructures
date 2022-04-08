using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;
using System;

namespace PE_MG_Buttons
{
    public class Game1 : Game
    {
        // Fields created by the MG template
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        // The list of buttons and setup for random bg color
        private SpriteFont font;
        private List<Button> buttons = new List<Button>();
        private Color bgColor = Color.White;
        private Random rng = new Random();

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // ADD Your new fields here!
        private int leftClicks;
        private int rightClicks;
        private List<Vector2> circles;
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            leftClicks = 0;
            rightClicks = 0;
            circles = new List<Vector2>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            font = Content.Load<SpriteFont>("buttonFont");

            // Create a few 100x200 buttons down the left side
            buttons.Add(new Button(
                    _graphics.GraphicsDevice,           // device to create a custom texture
                    new Rectangle(10, 40, 200, 100),    // where to put the button
                    "Random BG",                        // button label
                    font,                               // label font
                    Color.Purple));                     // button color
            buttons[0].OnLeftButtonClick += this.RandomizeBackground;
            buttons[0].OnRightButtonClick += this.RandomizeBackground;
            //Connect ButtonClicked Method to OnButtonClick Event
            buttons[0].OnLeftButtonClick += this.LeftButtonClicked;
            buttons[0].OnRightButtonClick += this.RightButtonClicked;

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Add your additional button setup code here!
            //Create Circle Button Under RandomBG Button
            buttons.Add(new Button(
                _graphics.GraphicsDevice,
                new Rectangle(10, 150, 200, 100),
                "Circle",
                font,
                Color.Red));
            //Connect DrawCircle Method to OnButtonClick Event
            buttons[1].OnLeftButtonClick += this.AddCircle;
            buttons[1].OnRightButtonClick += this.AddCircle;
            //Connect ButtonClicked to OnButtonClick Event
            buttons[1].OnLeftButtonClick += this.LeftButtonClicked;
            buttons[1].OnRightButtonClick += this.RightButtonClicked;

            //Create Ew Circle Button Under Circle Button
            buttons.Add(new Button(
                _graphics.GraphicsDevice,
                new Rectangle(10, 260, 200, 100),
                "Ew Circle",
                font,
                Color.Blue));
            //Connect DrawCircle Method to OnButtonClick Event
            buttons[2].OnLeftButtonClick += this.RemoveCircle;
            buttons[2].OnRightButtonClick += this.RemoveCircle;
            //Connect ButtonClicked to OnButtonClick Event
            buttons[2].OnLeftButtonClick += this.LeftButtonClicked;
            buttons[2].OnRightButtonClick += this.RightButtonClicked;
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        }

        // There is no need to add anything to Game1's Update method!
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            foreach (Button b in buttons)
            {
                b.Update();
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(bgColor);

            //Draw Circles
            ShapeBatch.Begin(_graphics.GraphicsDevice);
            for (int i = 0; i < circles.Count; i++)
            {
                ShapeBatch.Circle(circles[i], 50f, Color.OrangeRed);
            }
            ShapeBatch.End();
            _spriteBatch.Begin();

            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
            // Add your additional drawing code here!
            //Draw Num of Clicks
            _spriteBatch.DrawString(
                font,
                "Left Clicks: " + leftClicks + " Right Clicks: " + rightClicks,
                new Vector2(0, 0),
                Color.Black);
            // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

            // Draw the buttons last.
            foreach (Button b in buttons)
            {
                b.Draw(_spriteBatch);
            }

            _spriteBatch.End();

            base.Draw(gameTime);
        }

        // Button click handlers!

        // Leave this one alone
        public void RandomizeBackground()
        {
            bgColor = new Color(rng.Next(0, 256), rng.Next(0, 256), rng.Next(0, 256));
        }

        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
        // Add your new button click handlers here!
        //LeftButtonClicked Method
        public void LeftButtonClicked()
        {
            leftClicks++;
        }
        //RightButtonClicked Method
        public void RightButtonClicked()
        {
            rightClicks++;
        }
        //AddCircle Method
        public void AddCircle()
        {
            float xValue = rng.Next(_graphics.GraphicsDevice.Viewport.Width);
            float yValue = rng.Next(_graphics.GraphicsDevice.Viewport.Height);
            circles.Add(new Vector2(xValue, yValue));
        }
        //RemoveCircle Method
        public void RemoveCircle()
        {
            circles.RemoveAt(rng.Next(circles.Count));
        }
        // ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
    }
}
