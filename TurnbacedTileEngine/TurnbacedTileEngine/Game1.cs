using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace TurnbacedTileEngine
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        public static Map Map;
        Inspector Inspector;
        int xOffset = 500;
        int yOffset = 200;
        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);

            Content.RootDirectory = "Content";
            graphics.PreferredBackBufferHeight = 1080;
            graphics.PreferredBackBufferWidth = 1920;
            graphics.PreferMultiSampling = false;
            graphics.IsFullScreen = false;
            
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
            TextureDictionary.AddTexture(Content.Load<Texture2D>("Blank"), "Blank");
            TextureDictionary.AddTexture(Content.Load<Texture2D>("Rough"), "Rough");
            TextureDictionary.AddTexture(Content.Load<Texture2D>("Land"), "Land");
            TextureDictionary.AddTexture(Content.Load<Texture2D>("Power"), "Power");
            TextureDictionary.AddTexture(Content.Load<Texture2D>("Post"), "Post");
            TextureDictionary.AddTexture(Content.Load<Texture2D>("B1"), "B1");
            TextureDictionary.AddTexture(Content.Load<Texture2D>("B2"), "B2");
            TextureDictionary.AddTexture(Content.Load<Texture2D>("B3"), "B3");
            TextureDictionary.AddTexture(Content.Load<Texture2D>("B4"), "B4");
            TextureDictionary.AddTexture(Content.Load<Texture2D>("B5"), "B5");
            TextureDictionary.AddTexture(Content.Load<Texture2D>("B6"), "B6");
            TextureDictionary.AddTexture(Content.Load<Texture2D>("Outline"), "Outline");
            TextureDictionary.AddTexture(Content.Load<Texture2D>("interface"), "Interface");
            TextureDictionary.AddTexture(Content.Load<Texture2D>("bar"), "Bar");
            FontDictionary.Addfont(Content.Load<SpriteFont>("Times New Roman"), "Times New Roman");
            Map = new Map(9, 10, xOffset, yOffset);
           // Map = new Map(8, 10, 200, 200);
            Player.xoffset = xOffset;
            Player.yoffset = yOffset;
            Player.CurrentMap = Map;
            Inspector.currentMap = Map;
            Inspector = new Inspector(xOffset + 10 * 64 + 50, yOffset);
            // TODO: use this.Content to load your game content here
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
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

            // TODO: Add your update logic here
            Player.Update();
            Map.Update();
            Inspector.Update();
            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            spriteBatch.Begin();
            spriteBatch.Draw(TextureDictionary.FindTexture("B1"), /*new Rectangle(0,0,TextureDictionary.FindTexture("B1").Width,TextureDictionary.FindTexture("B1").Height)*/ new Rectangle(0,0,1920,1080), Color.White);
            Map.Draw(spriteBatch);
            Player.Draw(spriteBatch);
            Inspector.Draw(spriteBatch);
            Console.Draw(spriteBatch);
            // TODO: Add your drawing code here
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
