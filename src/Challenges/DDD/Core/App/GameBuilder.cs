using System;
using DDD.Core.Domain;

namespace DDD.Core.App
{
    public class GameBuilder
    {
        private readonly Grid _grid;

        private GameBuilder(Grid grid)
        {
            _grid = grid;
        }

        public static GameBuilder CreateGrid(int height, int width) => new GameBuilder(new Grid(height, width));

        public IGame Build() => new Game(_grid);

        public GameBuilder SetMine(int row, int column)
        {
            _grid.SetMine(row, column);
            return this;
        }

        public GameBuilder SetRandomMines(int count)
        {
            throw new NotImplementedException();
        }
    }
}