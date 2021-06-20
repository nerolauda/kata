namespace Space
{
	public interface IPlanetGrid
	{
		Coords NextCoords(Coords coords, Direction direction, Versus versus);
		PlanetGrid AddObstacle(int obstacleX, int obstacleY);
		bool CheckObstacle(Coords checkCoords);
	}
}
