using System;

namespace RobotCleaner
{
	public class PerimeterHuggerStrategy : IStrategy
	{
		public void Clean(Robot robot)
		{
			if (robot == null) return;

			int width = robot.Map.Width;
			int height = robot.Map.Height;

			// Top edge: left -> right on y = 0
			for (int x = 0; x < width; x++)
			{
				robot.Move(x, 0);
				robot.CleanCurrentSpot();
			}

			// Right edge: top -> bottom on x = width - 1 (skip the top corner)
			for (int y = 1; y < height; y++)
			{
				robot.Move(width - 1, y);
				robot.CleanCurrentSpot();
			}

			// Bottom edge: right -> left on y = height - 1 (skip bottom-right corner)
			if (height > 1)
			{
				for (int x = width - 2; x >= 0; x--)
				{
					robot.Move(x, height - 1);
					robot.CleanCurrentSpot();
				}
			}

			// Left edge: bottom -> top on x = 0 (skip bottom-left and top-left corners)
			if (width > 1)
			{
				for (int y = height - 2; y > 0; y--)
				{
					robot.Move(0, y);
					robot.CleanCurrentSpot();
				}
			}
		}
	}
}