﻿using System;

namespace NeonWars
{
#if WINDOWS || LINUX
	public static class Program
	{
		[STAThread]
		static void Main()
		{
			using (var game = new Game1())
				game.Run();
		}
	}
#endif
}
