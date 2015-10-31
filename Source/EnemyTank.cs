using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;

namespace NeonWars
{
	public class EnemyTank : Tank
	{
		private Color _color;
		public Color Color
		{ 
			get{ return this._color; } 
			set{ this._color = value; }
		}

		private int _weapontype;
		public int WeaponType
		{ 
			get{ return this._weapontype; } 
			set{ this._weapontype = value; }
		}

		public EnemyTank(Color color, int WeaponType)
		{
			throw new NotImplementedException();
		}
	}
}
