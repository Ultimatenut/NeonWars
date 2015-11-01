using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeonWars
{
	public class Tank
	{
        private int _health;
        public int Health
		{ 
			get{ return this._health; } 
			set{ this._health = value; }
		}
        private Vector2 _position;
        public Vector2 Position
		{ 
			get{ return this._position; } 
			set{ this._position = value; }
		}
        private int _speed;
        public int Speed
		{ 
			get{ return this._speed; } 
			set{ this._speed = value; }
		}

        public Tank()
		{
			throw new NotImplementedException();
		}

		protected void UpdatePosition()
		{
			throw new NotImplementedException();
		}

		protected void Fire()
		{
			throw new NotImplementedException();
		}

		protected void Draw(SpriteBatch spritebatch)
		{
			throw new NotImplementedException();
		}
	}
}
