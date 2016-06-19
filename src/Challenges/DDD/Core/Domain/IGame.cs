using DDD.Core.Domain.Models;

namespace DDD.Core.Domain
{
    public interface IGame
    {
        void RevealCell(Point point);
        void RevealCell(int row, int column);

        int Height { get; }
        int Width { get; }
        GameState State { get; }

        Cell this[int row, int column] { get; }
    }
}