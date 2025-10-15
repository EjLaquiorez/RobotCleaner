using System;

namespace RobotCleaner
{
	public class ZigzagStrategy : IStrategy
	{
		public void Clean(Robot robot)
		{
			if (robot == null) return;

			int width = robot.Map.Width;
			int height = robot.Map.Height;

			int direction = 1; // 1 = right, -1 = left
			for (int y = 0; y < height; y++)
			{
				int startX = (direction == 1) ? 0 : width - 1;
				int endX = (direction == 1) ? width : -1;

				for (int x = startX; x != endX; x += direction)
				{
					if (!robot.Map.IsObstacle(x, y))
					{
						robot.Move(x, y);
						robot.CleanCurrentSpot();
					}
				}
				direction *= -1; // Reverse direction for the next row
			}
		}
	}
}