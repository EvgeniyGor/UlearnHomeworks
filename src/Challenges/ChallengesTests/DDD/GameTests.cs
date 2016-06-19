using DDD.Core.App;
using DDD.Core.Domain;
using NUnit.Framework;

namespace ChallengesTests.DDD
{
    public class GameTests : TestBase
    {
        [Test]
        public void GameCreationTest()
        {
            var game = GameBuilder
                .CreateGrid(2, 2)
                .SetMine(0, 0)
                .SetMine(1, 1)
                .Build();

            Assert.True(game[0, 0].HasMine);
            Assert.True(game[1, 1].HasMine);

            Assert.Equals(2, game[0, 1].Digit);
            Assert.Equals(2, game[1, 0].Digit);
        }

        [Test]
        public void PlayerLoseTest()
        {
            var game = GameBuilder
                .CreateGrid(1, 1)
                .SetMine(0, 0)
                .Build();

            game.RevealCell(0, 0);

            Assert.True(game.State == GameState.PlayerLose);
        }


        [Test]
        public void PlayerWonTest()
        {
            var game = GameBuilder
                .CreateGrid(1, 2)
                .SetMine(0, 0)
                .Build();

            game.RevealCell(0, 1);

            Assert.True(game.State == GameState.PlayerWon);
        }

        [Test]
        public void RevealEmptyCellsTest()
        {
            var game = GameBuilder
                .CreateGrid(3, 3)
                .SetMine(0, 0)
                .Build();

            game.RevealCell(2, 2);

            for (int i = 0; i < game.Height; ++i)
            {
                for (int j = 0; j < game.Width; ++j)
                {
                    if (game[i, j].Empty && !game[i, j].HasMine)
                    {
                        Assert.True(game[i, j].Revealed, $"Cell at ({ i }, { j }) closed");
                    }
                }
            }

            Assert.True(game[0, 1].Revealed);
            Assert.True(game[1, 1].Revealed);
            Assert.True(game[1, 0].Revealed);

            Assert.True(!game[0, 0].Revealed);
        }
    }
}