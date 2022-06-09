using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
namespace SummativeAssignment
{
    public class SummativeAssignment : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        enum Screen
        {
            Intro,
            Main,
            Outro
        }
        Screen screen;
        MouseState mouseState;
        KeyboardState keyboardState;
        Texture2D PineappleTexture;
        Texture2D KrustyKrabTexture;
        Texture2D KrustyKitchenTexture;
        SpriteFont SpongeBobIntroText;

        Texture2D SpongeBobTexture;
        Rectangle SpongeBobRect;
        Vector2 SpongeBobSpeed;

        Texture2D PatrickTexture;
        Rectangle PatrickRect;
        Vector2 PatrickSpeed;

        Texture2D SquidwardTexture;
        Rectangle SquidwardRect;
        Vector2 SquidwardSpeed;

        Texture2D MrKrabsTexture;
        Rectangle MrKrabsRect;
        Texture2D KnifeTexture;
        Rectangle KnifeRect;

        Random generator = new Random();


        public SummativeAssignment()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }
        protected override void Initialize()
        {
            _graphics.PreferredBackBufferWidth = 800; // Sets the width of the window
            _graphics.PreferredBackBufferHeight = 500; // Sets the height of the window
            _graphics.ApplyChanges(); // Applies the new dimensions
            // TODO: Add your initialization logic here
            SpongeBobRect = new Rectangle(300, 10, 100, 100);
            SpongeBobSpeed = new Vector2(0, 100);

            PatrickRect = new Rectangle(300, 10, 100, 100);
            PatrickSpeed = new Vector2(6, 0);

            SquidwardRect = new Rectangle(300, 10, 100, 100);
            SquidwardSpeed = new Vector2(0, 0);

            MrKrabsRect = new Rectangle(300, 10, 100, 100);
            KnifeRect = new Rectangle(300, 10, 100, 100);



            screen = Screen.Intro;

            base.Initialize();
        }
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            // TODO: use this.Content to load your game content here
            SpongeBobTexture = Content.Load<Texture2D>("SpongeBob");
            SpongeBobRect = new Rectangle(0, 0, 150, 150);

            PatrickTexture = Content.Load<Texture2D>("Patrick");
            PatrickRect = new Rectangle(0, 300, 150, 150);

            SquidwardTexture = Content.Load<Texture2D>("Squidward");
            SquidwardRect = new Rectangle(200, 200, 150, 150);

            SpongeBobIntroText = Content.Load<SpriteFont>("SpongeBobIntroText");
            KrustyKrabTexture = Content.Load<Texture2D>("KrustyKrab");

            PineappleTexture = Content.Load <Texture2D>("PineappleHouse");
            KrustyKitchenTexture = Content.Load<Texture2D>("Kitchen");

            MrKrabsTexture = Content.Load<Texture2D>("MrKrabs");
            MrKrabsRect = new Rectangle(250, 200, 150, 150);

            KnifeTexture = Content.Load<Texture2D>("Knife");
            KnifeRect = new Rectangle(250, 200, 50, 50);
        }
        protected override void Update(GameTime gameTime)
        {
            keyboardState = Keyboard.GetState();
            mouseState = Mouse.GetState();
            if (screen == Screen.Intro)
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                    screen = Screen.Main;
            }
            else if (screen == Screen.Main)
            {
                // TODO: Add your update logic here
                SpongeBobRect.X += (int)SpongeBobSpeed.X;
                SpongeBobRect.Y += (int)SpongeBobSpeed.Y;
                if (SpongeBobRect.Bottom > _graphics.PreferredBackBufferHeight || SpongeBobRect.Top < 0)
                {
                    SpongeBobSpeed.Y *= -1;
                    SpongeBobRect.X = generator.Next(1, 650);
                }
                PatrickRect.X += (int)PatrickSpeed.X;
                PatrickRect.Y += (int)PatrickSpeed.Y;
                if (PatrickRect.Right > _graphics.PreferredBackBufferWidth || PatrickRect.Left < 0)
                {
                    PatrickSpeed.X *= -1;

                }
                SquidwardRect.X += (int)SquidwardSpeed.X;
                SquidwardRect.Y += (int)SquidwardSpeed.Y;
                //if (SquidwardRect.Left > _graphics.PreferredBackBufferWidth)
                //{
                 //   SquidwardSpeed.Y *= -1;
                   // wallHit = true;
               // }
                //if (wallHit == true)
            }
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
            base.Update(gameTime);
        }
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Transparent);
            // TODO: Add your drawing code here
            _spriteBatch.Begin();
            if (screen == Screen.Outro)
            {
                _spriteBatch.Draw(KrustyKitchenTexture, new Rectangle(0, 0, 800, 500), Color.White);
                _spriteBatch.DrawString(SpongeBobIntroText, "OUTRO SCREEN", new Vector2(0, 10), Color.Red);
                _spriteBatch.Draw(MrKrabsTexture, MrKrabsRect, Color.White);
                _spriteBatch.Draw(KnifeTexture, KnifeRect, Color.White);
            }
            else if (screen == Screen.Intro)
            {
                _spriteBatch.Draw(PineappleTexture, new Rectangle(0, 0, 800, 500), Color.White);
                _spriteBatch.DrawString(SpongeBobIntroText, "CLICK ANYWHERE TO CONTINUE", new Vector2(0, 10), Color.White);
            }
            else if (keyboardState.IsKeyDown(Keys.Space))
            {
                screen = Screen.Outro;
            }
            else if (screen == Screen.Main)
            {
                _spriteBatch.Draw(KrustyKrabTexture, new Rectangle(0, 0, 800, 500), Color.White);
                _spriteBatch.DrawString(SpongeBobIntroText, "PRESS SPACE FOR OUTRO SCREEN", new Vector2(0, 10), Color.White);
                _spriteBatch.Draw(SquidwardTexture, SquidwardRect, Color.White);
                _spriteBatch.Draw(PatrickTexture, PatrickRect, Color.White);
                _spriteBatch.Draw(SpongeBobTexture, SpongeBobRect, Color.White);
            }
            _spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
