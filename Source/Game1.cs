using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace NeonWars
{
	/// <summary>
	/// This is the main type for your game.
	/// </summary>
	public class Game1 : Game
	{
		private static GraphicsDeviceManager _graphics;
		public static GraphicsDeviceManager Graphics
		{ 
			get{ return _graphics; } 
			private set{ _graphics = value; }
		}
		private static SpriteBatch _spritebatch;
		public static SpriteBatch SpriteBatch
		{ 
			get{ return _spritebatch; } 
			private set{ _spritebatch = value; }
		}

		private PlayerTank _playertank;
		public PlayerTank Player1_Tank
		{ 
			get{ return this._playertank; } 
			set{ this._playertank = value; }
		}

		public Game1()
		{
			_graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			
			this._playertank = new PlayerTank(100,100);
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
			_spritebatch = new SpriteBatch(GraphicsDevice);
			this._playertank.Load(this);
		}

		/// <summary>
		/// UnloadContent will be called once per game and is the place to unload
		/// game-specific content.
		/// </summary>
		protected override void UnloadContent()
		{
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
			
			if (GamePad.GetState(PlayerIndex.One).Triggers.Left >= 0.5f)
			{
				Player1_Tank.Fire();
			} 
			
//  #if DEBUG || Debug
//              System.Console.WriteLine("{0} {1} , {2} {3} :: {4} , {5}",
//                                       GamePad.GetState(PlayerIndex.One, GamePadDeadZone.None).ThumbSticks.Left.X,
//                                       GamePad.GetState(PlayerIndex.One, GamePadDeadZone.None).ThumbSticks.Left.Y,
//                                       GamePad.GetState(PlayerIndex.One, GamePadDeadZone.None).ThumbSticks.Right.X,
//                                       GamePad.GetState(PlayerIndex.One, GamePadDeadZone.None).ThumbSticks.Right.Y,
//                                       GamePad.GetState(PlayerIndex.One, GamePadDeadZone.None).Triggers.Left,
//                                       GamePad.GetState(PlayerIndex.One, GamePadDeadZone.None).Triggers.Right);
//  #endif
			Player1_Tank.UpdatePostion(GamePad.GetState(PlayerIndex.One, GamePadDeadZone.None).ThumbSticks.Left,gameTime,2);
			Player1_Tank.UpdateGunDirection(GamePad.GetState(PlayerIndex.One, GamePadDeadZone.None).ThumbSticks.Right,gameTime);

			base.Update(gameTime);
		}

		/// <summary>
		/// This is called when the game should draw itself.
		/// </summary>
		/// <param name="gameTime">Provides a snapshot of timing values.</param>
		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.Black);

			this._playertank.Draw();
			
			base.Draw(gameTime);
		}
	}
}
