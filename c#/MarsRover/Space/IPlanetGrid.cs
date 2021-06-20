namespace Space
{
	public interface IPlanetGrid
	{
		Coords NextCoords(Coords coords, Direction direction, Versus versus);
		IPlanetGrid AddObstacle(int obstacleX, int obstacleY);
		bool CheckObstacle(Coords checkCoords);
	}
}
