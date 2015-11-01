using System;
using System.Collections.Generic;
using System.Text;

namespace NeonWars
{
	public class PlayerTank : Tank
	{
        private int _armor;
        public int Armor
		{ 
			get{ return this._armor; } 
			set{ this._armor = value; }
		}

		public PlayerTank(int health, int armor)
		{
			throw new NotImplementedException();
		}

		public int getArmor()
		{
			throw new NotImplementedException();
		}

		public void setArmor()
		{
			throw new NotImplementedException();
		}
	}
}
