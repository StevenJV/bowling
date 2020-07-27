using System.Runtime.CompilerServices;
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

        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 2)]
        [InlineData(5, 5)]
        public void SecondBallAddsToFirstBallScore(int firstBallPins, int secondBallPins)
        {
            _game.Roll(firstBallPins);
            _game.Roll(secondBallPins);
            Assert.Equal(firstBallPins + secondBallPins, _game.Score());
        }

        [Theory]
        [InlineData(1, 10)]
        public void TwoBallsCannotScoreMoreThanTen(int firstBallPins, int secondBallPins)
        {
            _game.Roll(firstBallPins);
            _game.Roll(secondBallPins);
            Assert.InRange(_game.Score(), 0, 10);
        }
    }
}