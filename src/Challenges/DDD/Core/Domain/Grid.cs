using System;
using System.Linq;
using DDD.Core.Domain.Models;
using DDD.Core.Infrastructure;

namespace DDD.Core.Domain
{
    public class Grid
    {
        private readonly Cell[,] _grid;
 
        public Grid(int height, int width)
        {
            Height = height;
            Width = width;
            MinesCount = 0;
            CellsCount = height*width;

            _grid = new Cell[Height, Width];

            for (int i = 0; i < Height; ++i)
            {
                for (int j = 0; j < Width; ++j)
                {
                    _grid[i, j] = new Cell();
                }
            }
        }

        public int Height { get; }
        public int Width  { get; }
        public int CellsCount { get; }
        public int MinesCount { get; private set; }

        public Cell this[int row, int column] => this[new Point(row, column)];

        public Cell this[Point point]
        {
            get
            {
                CheckPosition(point);
                return _grid[point.Row, point.Column];
            }
        }

        public void SetMine(int row, int column) => SetMine(new Point(row, column));

        public void SetMine(Point point)
        {
            CheckPosition(point);

            this[point].SetMine();
            MinesCount++;

            var neighbours = point
                .GetNeighbours()
                .Where(neighbour => neighbour.InArray(Height, Width) && !this[neighbour].HasMine);

            foreach (var neigbor in neighbours)
            {
                this[neigbor].Digit++;
            }
        }

        private void CheckPosition(Point point)
        {
            if (!point.InArray(Height, Width))
            {
                throw new ArgumentException($"Position is out of range. { nameof(point.Row) } = { point.Row }, { nameof(point.Column) } = { point.Column }");
            }  
        } 
    }
}