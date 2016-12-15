using Bowling;
using Xunit;
using Assert = Xunit.Assert;

namespace BowlingTests
{
    public class ThirdFrame
    {
        private readonly BowlingGame _game = new BowlingGame();

        [Theory]
        [InlineData(1, 1, 1, 1, 1, 5)]
        [InlineData(6, 6, 6, 6, 6, 38)]
        [InlineData(10, 6, 6, 6, 6, 42)]
        public void FirstBallShouldAddToSecondFrame(int f1b1, int f1b2, int f2b1, int f2b2, int f3b1, int expectedScore)
        {
            // first frame
            _game.Roll(f1b1);
            _game.Roll(f1b2);

            // second frame
            _game.Roll(f2b1);
            _game.Roll(f2b2);

            //third frame
            _game.Roll(f3b1);

            Assert.Equal(expectedScore, _game.Score());
        }


        [Theory]
        [InlineData(1, 1, 1, 1, 1, 1, 6)]
        [InlineData(6, 6, 6, 6, 6, 6, 42)]
        [InlineData(10, 6, 6, 6, 6, 6, 46)]
        [InlineData(10, 0, 10, 0, 10, 0, 60)]
        public void SecondBallShouldAddToSecondFrame(int f1b1, int f1b2, int f2b1, int f2b2, int f3b1, int f3b2, int expectedScore)
        {
            // first frame
            _game.Roll(f1b1);
            _game.Roll(f1b2);

            // second frame
            _game.Roll(f2b1);
            _game.Roll(f2b2);

            //third frame
            _game.Roll(f3b1);
            _game.Roll(f3b2);

            Assert.Equal(expectedScore, _game.Score());
        }
    }
}