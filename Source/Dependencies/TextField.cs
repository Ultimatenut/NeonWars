using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace NeonWars.Dependencies
{
	public class TextField
	{
        private int _x_pos;
        public int X
		{ 
			get{ return this._x_pos; } 
			set{ this._x_pos = value; }
		}
		private int _y_pos;
        public int Y
		{ 
			get{ return this._y_pos; } 
			set{ this._y_pos = value; }
		}
		
		private int _length;
        public int Length{ get; set; }
		private int _width;
        public int Width{ get; set; }

		private String _text;
		public String Text{ get; set; }
		private Color _text_color;
		public Color Text_Color{ get; set; }
		private int _text_size;
		public int Text_Size{ get; set; }

		private Color _outline_color;
		public Color Outline_Color{ get; set; }

		private bool _is_button;
		public bool Is_Button{ get; set; }

        public TextField(int x_pos, int y_pos, int length, int width, String Text)
		{
			throw new NotImplementedException();
		}

		public void Draw()
		{
			throw new NotImplementedException();
		}

		public bool is_Clicked(int mouseX, int mouseY)
		{
			if( (mouseX >= this._x_pos) && mouseX <= (this._x_pos + this._width) )
			{
				if(mouseY >= this._y_pos && mouseY <= (this._y_pos + this._length) )
				{
                    return true;
                }
			}
            return false;
        }
	}
}
