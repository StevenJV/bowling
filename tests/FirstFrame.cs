using Bowling;
using Xunit;
using Xunit.Sdk;

namespace Tests
{
    public class FirstFrame
    {
        private readonly BowlingGame _game = new BowlingGame();

        [Theory]
        [InlineData(0)]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(9)]
        [InlineData(10)]
        public void FirstBallIsScoredAsThrown(int firstBallPins)
        {
            _game.Roll(firstBallPins);
            Assert.Equal(firstBallPins, _game.Score());
        }

    }
}