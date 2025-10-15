namespace RobotCleaner
{
    public class SpiralStrategy : IStrategy
    {
        public void Clean(Robot robot)
        {
            int width = robot.Map.Width;
            int height = robot.Map.Height;
            
            int top = 0, bottom = height - 1;
            int left = 0, right = width - 1;
            
            while (top <= bottom && left <= right)
            {
                // Move right along the top row
                for (int x = left; x <= right; x++)
                {
                    if (robot.Move(x, top))
                    {
                        robot.CleanCurrentSpot();
                    }
                }
                top++;

                // Move down along the right column
                for (int y = top; y <= bottom; y++)
                {
                    if (robot.Move(right, y))
                    {
                        robot.CleanCurrentSpot();
                    }
                }
                right--;

                // Move left along the bottom row (if there are rows left)
                if (top <= bottom)
                {
                    for (int x = right; x >= left; x--)
                    {
                        if (robot.Move(x, bottom))
                        {
                            robot.CleanCurrentSpot();
                        }
                    }
                    bottom--;
                }

                // Move up along the left column (if there are columns left)
                if (left <= right)
                {
                    for (int y = bottom; y >= top; y--)
                    {
                        if (robot.Move(left, y))
                        {
                            robot.CleanCurrentSpot();
                        }
                    }
                    left++;
                }
            }
        }
    }
}
