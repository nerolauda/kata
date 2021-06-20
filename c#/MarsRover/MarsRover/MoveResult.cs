using Space;

namespace MarsRover
{
    public class MoveResult
    {
        public Coords? ObstaclePosition { get; private set; }

        public MoveResult()
        {
            ObstaclePosition = null;
        }

        public void ObstacledAt(Coords position)
        {
            ObstaclePosition = position;
        }

        public bool ObstacleFound()
        {
            return ObstaclePosition != null;
        }
    }
}