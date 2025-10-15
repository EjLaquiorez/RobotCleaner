namespace RobotCleaner
{
    public class Robot
    {
        private readonly Map _map;
        private readonly IStrategy _strategy;

        public int X { get; set; }
        public int Y { get; set; }

        public Map Map { get { return _map; } }

        public Robot(Map map, IStrategy strategy)
        {
            _map = map;
            _strategy = strategy;
            X = 0;
            Y = 0;
        }

        public bool Move(int newX, int newY)
        {
            if (_map.IsInBounds(newX, newY) && !_map.IsObstacle(newX, newY))
            {
                // set the new location
                X = newX;
                Y = newY;
                // display the map with the robot in its location in the grid
                _map.Display(X, Y);
                return true;
            }
            // it cannot move
            return false;
        }// Move method

        public void CleanCurrentSpot()
        {
            if (_map.IsDirt(X, Y))
            {
                _map.Clean(X, Y);
                _map.Display(X, Y);
            }
        }

        public void StartCleaning()
        {
            _strategy.Clean(this);
        }
    }
}
