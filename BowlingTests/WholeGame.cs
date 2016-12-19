using Bowling;
using Xunit;

namespace BowlingTests
{

    public class WholeGame
    {
        private readonly BowlingGame _game = new BowlingGame();

        [Theory]
        [InlineData(1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 0, 0, 0, 18)]
        public void ScoredCorrectly(int f1b1, int f1b2, int f2b1, int f2b2, int f3b1, int f3b2,
            int f4b1, int f4b2, int f5b1, int f5b2, int f6b1, int f6b2,
            int f7b1, int f7b2, int f8b1, int f8b2, int f9b1, int f9b2,
            int f10b1, int f10b2, int f10b3, int expectedScore)
        {
            // first frame
            _game.Roll(f1b1);
            _game.Roll(f1b2);

            // second frame
            _game.Roll(f2b1);
            _game.Roll(f2b2);

            // third frame
            _game.Roll(f3b1);
            _game.Roll(f3b2);

            // fourth frame
            _game.Roll(f4b1);
            _game.Roll(f4b2);

            // fifth frame
            _game.Roll(f5b1);
            _game.Roll(f5b2);

            // sixth frame
            _game.Roll(f6b1);
            _game.Roll(f6b2);

            // seventh frame
            _game.Roll(f7b1);
            _game.Roll(f7b2);

            // eights frame
            _game.Roll(f8b1);
            _game.Roll(f8b2);

            // ninth frame
            _game.Roll(f9b1);
            _game.Roll(f9b2);

            // tenth frame
            _game.Roll(f10b1);
            _game.Roll(f10b2);
            _game.Roll(f10b3);

            Assert.Equal(expectedScore, _game.Score());

        }

        [Theory]
        [InlineData(10, 10, 10, 10, 9, 0, 0, 0, 2, 1, 8, 0, 1, 2, 0, 0, 0, 131)]
        // first four frames are strikes - no second ball thrown.
        public void ScoredCorrectlyWhenFirstBallIsAStrike(int f1b1, int f2b1, int f3b1,
            int f4b1, int f5b1, int f5b2, int f6b1, int f6b2,
            int f7b1, int f7b2, int f8b1, int f8b2, int f9b1, int f9b2,
            int f10b1, int f10b2, int f10b3, int expectedScore)
        {
            // first frame
            _game.Roll(f1b1);

            // second frame
            _game.Roll(f2b1);

            // third frame
            _game.Roll(f3b1);

            // fourth frame
            _game.Roll(f4b1);

            // fifth frame
            _game.Roll(f5b1);
            _game.Roll(f5b2);

            // sixth frame
            _game.Roll(f6b1);
            _game.Roll(f6b2);

            // seventh frame
            _game.Roll(f7b1);
            _game.Roll(f7b2);

            // eights frame
            _game.Roll(f8b1);
            _game.Roll(f8b2);

            // ninth frame
            _game.Roll(f9b1);
            _game.Roll(f9b2);

            // tenth frame
            _game.Roll(f10b1);
            _game.Roll(f10b2);
            _game.Roll(f10b3);

            Assert.Equal(expectedScore, _game.Score());


        }


        [Theory]
        [InlineData(10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 300)]
        public void ScoredCorrectlyAllStrikes(int f1b1, int f2b1, int f3b1, 
            int f4b1, int f5b1, int f6b1, int f7b1, int f8b1, int f9b1, int f10b1, int f10b2, int f10b3, int expectedScore)
        {
            // first frame
            _game.Roll(f1b1);

            // second frame
            _game.Roll(f2b1);

            // third frame
            _game.Roll(f3b1);

            // fourth frame
            _game.Roll(f4b1);

            // fifth frame
            _game.Roll(f5b1);

            // sixth frame
            _game.Roll(f6b1);

            // seventh frame
            _game.Roll(f7b1);

            // eights frame
            _game.Roll(f8b1);

            // ninth frame
            _game.Roll(f9b1);

            // tenth frame
            _game.Roll(f10b1);
            _game.Roll(f10b2);
            _game.Roll(f10b3);

            Assert.Equal(expectedScore, _game.Score());

        }
    }
}