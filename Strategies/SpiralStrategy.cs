using System.Collections.Generic;

namespace RobotCleaner
{
    public class SpiralStrategy : IStrategy
    {
        public void Clean(Robot robot)
        {
            // Directions: Right, Down, Left, Up
            int[] dx = new int[] { 1, 0, -1, 0 };
            int[] dy = new int[] { 0, 1, 0, -1 };

            int directionIndex = 0; // start moving Right
            int segmentLength = 1;   // initial segment length
            int stepsTakenOnSegment = 0;
            int completedTurns = 0;  // after every two completed turns, segmentLength increases
            int steps = 0;
            int maxSteps = robot.Map.Width * robot.Map.Height * 50; // generous safety cap
            int reachableCells = CountCleanable(robot.Map); // all non-obstacle cells are reachable due to Move semantics
            HashSet<(int, int)> visited = new HashSet<(int, int)>();

            // Clean starting cell if dirty
            robot.CleanCurrentSpot();
            visited.Add((robot.X, robot.Y));

            while (steps < maxSteps && visited.Count < reachableCells)
            {
                // Try to step; if blocked, rotate without counting a completed side.
                int attempts = 0;
                bool moved = false;
                while (attempts < 4 && !moved)
                {
                    int nextX = robot.X + dx[directionIndex];
                    int nextY = robot.Y + dy[directionIndex];

                    if (robot.Move(nextX, nextY))
                    {
                        moved = true;
                        robot.CleanCurrentSpot();
                        steps++;
                        visited.Add((robot.X, robot.Y));
                        stepsTakenOnSegment++;

                        if (stepsTakenOnSegment == segmentLength)
                        {
                            stepsTakenOnSegment = 0;
                            directionIndex = (directionIndex + 1) % 4;
                            completedTurns++;
                            if (completedTurns == 2)
                            {
                                segmentLength++;
                                completedTurns = 0;
                            }
                        }
                    }
                    else
                    {
                        // rotate and try a different direction
                        directionIndex = (directionIndex + 1) % 4;
                        attempts++;
                    }
                }

                if (!moved)
                {
                    // All four directions blocked from current position
                    break;
                }
            }

            // Return to origin (0,0) if possible
            if (robot.Map.IsInBounds(0, 0) && !robot.Map.IsObstacle(0, 0))
            {
                robot.Move(0, 0);
                robot.CleanCurrentSpot();
            }
        }

        private static int CountCleanable(Map map)
        {
            int width = map.Width;
            int height = map.Height;
            int count = 0;
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    if (map.IsInBounds(x, y) && !map.IsObstacle(x, y))
                    {
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
