namespace RobotCleaner
{
    public class SomeStrategy : IStrategy
    {
        public void Clean(Robot robot)
        {
            int direction = 1; // 1 = right, -1 = left
            for (int y = 0; y < robot.Map.Height; y++)
            {
                int startX = (direction == 1) ? 0 : robot.Map.Width - 1;
                int endX = (direction == 1) ? robot.Map.Width : -1;
                
                for (int x = startX; x != endX; x += direction)
                {
                    robot.Move(x, y);
                    robot.CleanCurrentSpot();
                }
                direction *= -1; // Reverse direction for the next row
            }
        }
    }
}
