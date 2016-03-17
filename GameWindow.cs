using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Oztroja.Entities;
using Oztroja.Sprites;

namespace Oztroja
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class GameWindow : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        RenderTarget2D target;

        public GameWindow()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 800;
            graphics.PreferredBackBufferHeight = 800;
            graphics.ApplyChanges();
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
            // TODO: Add your initialization logic here

            base.Initialize();

        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            target = new RenderTarget2D(GraphicsDevice, 320, 320);

            Sound.Initialize(Content);
            SpriteSheet.Initialize(spriteBatch, Content);
            Tile.Initialize();
            Animation.Initialize();

            GameManager.Setup(this);           

            Level.GenNextLevel();

        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
            GameManager.Teardown();
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            if (Sound.music.State == SoundState.Stopped)
                Sound.music.Play();

            GameManager.Instance.Tick();

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            this.GraphicsDevice.SetRenderTarget(target);
            GraphicsDevice.Clear(Color.Black);

            GameManager.Instance.Render();

            this.GraphicsDevice.SetRenderTarget(null);
            GraphicsDevice.Clear(Color.Black);

            var xo = (graphics.PreferredBackBufferWidth - target.Width * Config.SCALE) / 2;
            var yo = (graphics.PreferredBackBufferHeight - target.Height * Config.SCALE) / 2;

            spriteBatch.Begin();
            spriteBatch.Draw(target, new Rectangle(xo, yo, target.Width * Config.SCALE, target.Height * Config.SCALE), Color.White);
            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
