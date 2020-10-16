using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MonoMess
{
    public class Game1 : Game
    {

        Texture2D ballTexture;
        Texture2D backgroundTexture;
        Vector2 ballPosition = new Vector2 (0,0);

        int ballSpeed;


        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {

            //_graphics = new GraphicsDeviceManager(this);
            //_graphics.PreferredBackBufferHeight = 900;
            //_graphics.PreferredBackBufferWidth = 900;
            //Window.Title = "Idk what i'm doing YEET";
            //_graphics.ApplyChanges();

            //Content.RootDirectory = "Content";


            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            //change the screen size
            

            Window.Title = "Idk what i'm doing YEET";
            IsMouseVisible = true;
            

        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            //Changing window size
            _graphics.PreferredBackBufferHeight = 500;
            _graphics.PreferredBackBufferWidth = 900;
            _graphics.ApplyChanges();

            

            ballSpeed = 10;


            

            base.Initialize();

        }

        protected override void LoadContent()
        {

            // Create a new SpriteBatch, which can be used to draw textures.
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here   (GETS THE TEXTURES AND STUFF)
            ballTexture = Content.Load<Texture2D>("ball");
            ballPosition = new Vector2(_graphics.PreferredBackBufferWidth / 2 - ballTexture.Width/2, _graphics.PreferredBackBufferHeight / 2 - ballTexture.Height / 2);
            backgroundTexture = Content.Load<Texture2D>("download");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here


            //Gets keyboard stuff
            var kstate = Keyboard.GetState();

            //moves
            if (kstate.IsKeyDown(Keys.Up))
                ballPosition.Y -= ballSpeed;// * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Down))
                ballPosition.Y += ballSpeed;// * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Left))
                ballPosition.X -= ballSpeed;// * (float)gameTime.ElapsedGameTime.TotalSeconds;

            if (kstate.IsKeyDown(Keys.Right))
                ballPosition.X += ballSpeed;// * (float)gameTime.ElapsedGameTime.TotalSeconds;


            base.Update(gameTime);



            //NOPE

            //ballPosition.X += 1;
            //if (ballPosition.X > this.GraphicsDevice.Viewport.Width)
            //{
            //    ballPosition.X = 0;
            //}

            //ballPosition.Y += 1;
            //if (ballPosition.Y > this.GraphicsDevice.Viewport.Height)
            //{
            //    ballPosition.Y = 0;
            //}
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            // TODO: Add your drawing code here

            //Start
            _spriteBatch.Begin();


            //stretch img to size of screen
            _spriteBatch.Draw(backgroundTexture, GraphicsDevice.Viewport.Bounds, Color.White);


            //draws the ball

            //If you didnt remove the height before
            //_spriteBatch.Draw(ballTexture,ballPosition,null,Color.White,0f, new Vector2(ballTexture.Width /2 , ballTexture.Height /2), Vector2.One,SpriteEffects.None,0f);

            //if you did
            _spriteBatch.Draw(ballTexture, ballPosition, Color.White);

            //End
            _spriteBatch.End();

            //Load
            base.Draw(gameTime);



            //NOPE

            // _spriteBatch.Draw(ballTexture, new Vector2(0, 0), Color.White);
            //_spriteBatch.Draw(ballTexture, ballPosition, Color.White);
            //_spriteBatch.Draw(backgroundTexture, new Vector2(Window.ClientBounds.Width,Window.ClientBounds.Height), Color.White);
        }
    }
}
