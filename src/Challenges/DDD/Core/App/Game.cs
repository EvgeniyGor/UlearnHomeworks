using System.Collections.Generic;
using System.Linq;
using DDD.Core.Domain;
using DDD.Core.Domain.Models;
using DDD.Core.Infrastructure;

namespace DDD.Core.App
{
    public class Game : IGame
    {
        private int _revealCellsCount;
        private readonly Grid _grid;
        private readonly Queue<Point> _queue;

        public Game(Grid grid)
        {
            _revealCellsCount = 0;
            _grid = grid;
            _queue = new Queue<Point>();

            State = GameState.Continued;
        }

        public int Height => _grid.Height;
        public int Width  => _grid.Width;
        public GameState State { get; private set; }

        public Cell this[int row, int column] => _grid[row, column];

        public void RevealCell(int row, int column) => RevealCell(new Point(row, column));

        public void RevealCell(Point point)
        {
            if (State != GameState.Continued || _grid[point].Revealed)
            {
                return;
            }

            _grid[point].Reveal();
            _revealCellsCount++;

            if (_grid[point].HasMine)
            {
                State = GameState.PlayerLose;
                return;
            }

            if (_grid[point].Empty)
            {
                RevealEmptyNeigborCells(point);
            }

            if (_revealCellsCount == _grid.CellsCount - _grid.MinesCount)
            {
                State = GameState.PlayerWon;
            }
        }

        private void RevealEmptyNeigborCells(Point point)
        {
            _queue.Enqueue(point);

            while (_queue.Count != 0)
            {
                var sourcePoint = _queue.Dequeue();

                var neighbours = sourcePoint
                    .GetNeighbours()
                    .Where(neighbour => ShouldBeRevealed(sourcePoint, neighbour));

                foreach (var neighbour in neighbours)
                {
                    _grid[neighbour].Reveal();
                    _revealCellsCount++;
                    _queue.Enqueue(neighbour);
                }
            }
        }

        private bool ShouldBeRevealed(Point sourcePoint, Point currentPoint)
        {
            return currentPoint.InArray(_grid.Height, _grid.Width) &&
                   !_grid[currentPoint].Revealed &&
                   !_grid[currentPoint].HasMine &&
                   (_grid[sourcePoint].Empty ||
                    _grid[currentPoint].Empty);
        }
    }
}