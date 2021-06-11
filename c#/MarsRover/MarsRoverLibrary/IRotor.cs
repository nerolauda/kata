namespace MarsRover
{
    public interface IRotor
    {
        Direction Direction { get; }

        Direction RotateLeft();
        Direction RotateRight();
    }
}