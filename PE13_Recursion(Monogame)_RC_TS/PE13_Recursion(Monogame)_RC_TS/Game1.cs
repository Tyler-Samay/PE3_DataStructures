using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace PE13_Recursion_Monogame__RC_TS
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

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

            System.Diagnostics.Debug.WriteLine("Tacocat: " + IsPalindrome("tacocat", 0, 6));
            System.Diagnostics.Debug.WriteLine("Cat: " + IsPalindrome("cat", 0, 2));
            System.Diagnostics.Debug.WriteLine("Banana: " + IsPalindrome("banana", 0, 5));
            System.Diagnostics.Debug.WriteLine("Radar: " + IsPalindrome("radar", 0, 4));
            System.Diagnostics.Debug.WriteLine("Refer: " + IsPalindrome("refer", 0, 4));
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            ShapeBatch.Begin(GraphicsDevice);
            RecursiveTree(new Vector2(50, 50), 50f, 0f);
            ShapeBatch.End();

            base.Draw(gameTime);
        }

        private bool IsPalindrome(string phrase, int startIndex, int endIndex)
        {

            //Base case
            //When letter at start and end index are the same
            if (phrase[startIndex] != phrase[endIndex])
            {
                return false;
            }
            else if(phrase[startIndex] >= phrase[endIndex])
            {
                return true;
            }

            //Recursive Case
            //If the letter at start and index are the same
            else if (phrase[startIndex] == phrase[endIndex])
            {
                //State Change
                return IsPalindrome(phrase, startIndex + 1, endIndex - 1);
            }
            return false;
        }
        private void RecursiveTree(Vector2 position, float length, float angle)
        {
            ShapeBatch.Line(position, length, angle, Color.White);
            if (length < 5f)
            {
                ShapeBatch.Line(position, length, angle, Color.White);
            }
            else
            {
                RecursiveTree(position, 0.8f * length, 0.3f * angle);
                
            }
        }
    }
}
