using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

using NeonWars.Dependencies;

namespace NeonWars
{
	public class MenuParser
	{
		private String _path;
		public String Path
		{ 
			get{ return this._path; } 
			set{ this._path = value; }
		}
		private TextField[] textelements;

		public MenuParser(int menutype, String path)
		{
			throw new NotImplementedException();
		}

		public void Parse()
		{
			throw new NotImplementedException();
		}

		public void Draw()
		{
			throw new NotImplementedException();
		}

		public void Invoke(String method)
		{
			throw new NotImplementedException();
		}
	}
}
