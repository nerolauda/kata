using Space;

namespace MarsRover
{
    public interface IRover
    {
        Coords Position { get; }

        MoveResult Move(Versus versus);
        void Rotate(Rotation rotation);
    }
}