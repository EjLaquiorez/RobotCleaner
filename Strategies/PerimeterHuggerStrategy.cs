namespace RobotCleaner
{
    public class PerimeterHuggerStrategy : IStrategy
    {
        public void Clean(Robot robot)
        {
            // Start from top-left corner
            robot.Move(0, 0);
            robot.CleanCurrentSpot();

            // Clean the perimeter by following the walls
            CleanPerimeter(robot);
        }

        private void CleanPerimeter(Robot robot)
        {
            int width = robot.Map.Width;
            int height = robot.Map.Height;
            
            // Move right along the top edge
            for (int x = 1; x < width; x++)
            {
                if (robot.Move(x, 0))
                {
                    robot.CleanCurrentSpot();
                }
            }

            // Move down along the right edge
            for (int y = 1; y < height; y++)
            {
                if (robot.Move(width - 1, y))
                {
                    robot.CleanCurrentSpot();
                }
            }

            // Move left along the bottom edge
            for (int x = width - 2; x >= 0; x--)
            {
                if (robot.Move(x, height - 1))
                {
                    robot.CleanCurrentSpot();
                }
            }

            // Move up along the left edge
            for (int y = height - 2; y > 0; y--)
            {
                if (robot.Move(0, y))
                {
                    robot.CleanCurrentSpot();
                }
            }
        }
    }
}
