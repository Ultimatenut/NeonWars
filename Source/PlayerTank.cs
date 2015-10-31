using System;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using NeonWars.Dependencies;


namespace NeonWars
{
	public class PlayerTank
	{
		//if in DEBUG mode then load the DEV sprites, else load the release sprites
#if DEBUG || Debug
		private const string bitmap_base_path = "Dev/Player_tank/Player_Tank_Base";
		private const string bitmap_head_path = "Dev/Player_tank/Player_Tank_Head";

#else
		private const string bitmap_base_path = "Player_tank/Player_Tank_base";
		private const string bitmap_base_path = "Player_tank/Player_Tank_Head";
#endif
		//used for offsetting the display coordinates to make the tank pos refer to the center and not the top left corner
		private Vector2 bitmap_base_center;
		private Vector2 bitmap_head_center;

		private int _armor;
		public int Armor
		{
			get { return this._armor; }
			set { this._armor = value; }
		}

		private int _health;
		public int Health
		{
			get { return this._health; }
			set { this._health = value; }
		}

		private Texture2D _tank_base;
		public Texture2D Tank_Base
		{
			get { return this._tank_base; }
			//this should only be set once and only in this file
			private set { this._tank_base = value; }
		}

		private Texture2D _tank_head;
		public Texture2D Tank_Head
		{
			get { return this._tank_head; }
			//this should only be set once and only in this file
			private set { this._tank_head = value; }
		}

		private float _x_pos;
		public float X
		{
			get { return this._x_pos; }
			set { _x_pos = value; }
		}
		private float _y_pos;
		public float Y
		{
			get { return this._y_pos; }
			set { _y_pos = value; }
		}

		private double _base_rotation; //will always be stored in Rad's
		public double BaseAngle_Deg
		{
			get { return MathHelper.ToDegrees((float)_base_rotation); }
			set { _base_rotation = MathHelper.ToRadians((float)value); }
		}
		public double BaseAngle_Rad
		{
			get { return _base_rotation; }
			set { _base_rotation = value; }
		}

		private double _head_rotation; //will always be stored in Rad's
		public double HeadAngle_Deg
		{
			get { return MathHelper.ToDegrees((float)_head_rotation); }
			set { _head_rotation = MathHelper.ToRadians((float)value); }
		}
		public double HeadAngle_Rad
		{
			get { return _head_rotation; }
			set { _head_rotation = value; }
		}

		public PlayerTank(int health, int armor)
		{
			this._health = health;
			this._armor = armor;
			this._x_pos = 300;
			this._y_pos = 300;
		}
		public void Load(Game1 game)
		{
			//load the bitmaps associated with the "base" and "head of the tank
			this._tank_base = game.Content.Load<Texture2D>(bitmap_base_path);
			this._tank_head = game.Content.Load<Texture2D>(bitmap_head_path);
			
			bitmap_base_center = new Vector2(13, 20);
			bitmap_head_center = new Vector2(9, 21);
		}

		public void UpdatePostion(Vector2 controllerCOORD, GameTime gametime, int driveStyle)
		{
			//TODO: Calibrate these values
			float multiplier_pos = 80f;
			float Deadzone = 0.2f;
			//values from the controller range from -1 to 1
			if (driveStyle == 1)
			{
				int demultiplier_rot = 30;
				
				//**Default**//
				//pushing forward on the left stick moves the tank forward in the current direction
				//moveing the stick left or right turn the tank left and right respectively

				if (Math.Abs(controllerCOORD.Y) > Deadzone)
				{
					this._x_pos += ((float)Math.Sin(this.BaseAngle_Rad) * 
									(multiplier_pos * (float)gametime.ElapsedGameTime.TotalSeconds)); //x component vector of movement
					this._y_pos -= ((float)Math.Cos(this.BaseAngle_Rad) * 
									(multiplier_pos * (float)gametime.ElapsedGameTime.TotalSeconds)); //y component vector of movement
				}
				if (Math.Abs(controllerCOORD.X) > Deadzone)
				{
					this.BaseAngle_Rad += (controllerCOORD.X / demultiplier_rot);
				}
			}
			else if (driveStyle == 2)
			{
				float rot_multiplier = 2.5f;
				
				if (Math.Abs(controllerCOORD.Y) > Deadzone || Math.Abs(controllerCOORD.X) > Deadzone)
				{
					double intended_angle = Math.Atan2(controllerCOORD.X, controllerCOORD.Y);
					double current_angle = this.BaseAngle_Rad % MathHelper.TwoPi;
					if (intended_angle > current_angle + MathHelper.Pi)
					{
						intended_angle -= 2 * MathHelper.Pi;
					}
					else if (intended_angle < current_angle - MathHelper.Pi)
					{
						intended_angle += 2 * MathHelper.Pi;
					}
					this.BaseAngle_Rad = MathHelper.Lerp((float)current_angle,
														(float)intended_angle,
														rot_multiplier * (float)gametime.ElapsedGameTime.TotalSeconds);
					this._x_pos += ((float)Math.Sin(this.BaseAngle_Rad) * 
									(multiplier_pos * (float)gametime.ElapsedGameTime.TotalSeconds)); //x component vector of movement
					this._y_pos -= ((float)Math.Cos(this.BaseAngle_Rad) * 
									(multiplier_pos * (float)gametime.ElapsedGameTime.TotalSeconds)); //y component vector of movement
				}

			}
		}

		public void UpdateGunDirection(Vector2 controllerCOORD, GameTime gametime)
		{
			//TODO calibrate these values
			float Deadzone = 0.5f;
			float rot_multiplier = 5f;

			//control style//
			//the gun will rotate to face in the direction of the right joystick

			if (Math.Abs(controllerCOORD.Y) > Deadzone || Math.Abs(controllerCOORD.X) > Deadzone)
			{
				double intended_angle = Math.Atan2(controllerCOORD.X, controllerCOORD.Y);
				double current_angle = this.HeadAngle_Rad % MathHelper.TwoPi;
				if (intended_angle > current_angle + MathHelper.Pi)
					intended_angle -= 2 * MathHelper.Pi;
				else if (intended_angle < current_angle - MathHelper.Pi)
					intended_angle += 2 * MathHelper.Pi;
				this.HeadAngle_Rad = MathHelper.Lerp((float)current_angle,
													(float)intended_angle,
													rot_multiplier * (float)gametime.ElapsedGameTime.TotalSeconds);
			}
		}

		public void Fire()
		{
			throw new NotImplementedException();
		}

		public void Draw()
		{
			Game1.SpriteBatch.Begin(); //begin drawing this sprite
									//tank base
			Game1.SpriteBatch.Draw(this._tank_base,
									new Vector2(this._x_pos,
												this._y_pos),
									null,
									null,
									this.bitmap_base_center,
									((float)this.BaseAngle_Rad),
									null,
									Color.Blue,
									SpriteEffects.None,
									0);
			//tank head
			Game1.SpriteBatch.Draw(this._tank_head,
									new Vector2(this._x_pos,
												this._y_pos),
									null,
									null,
									this.bitmap_head_center,
									((float)this.HeadAngle_Rad),
									null,
									Color.Blue,
									SpriteEffects.None,
									0);
			Game1.SpriteBatch.End();   //end drawing this sprite
		}
	}
}
