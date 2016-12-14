using Bowling;
using Xunit;
using Assert = Xunit.Assert;

namespace BowlingTests
{
    public class FirstFrame
    {
        private readonly BowlingGame _game = new BowlingGame();

        [Theory]
        [InlineData(1)]
        [InlineData(5)]
        [InlineData(9)]
        public void FirstBallSingleDigitShouldScoreSingleDigit(int firstBallPins)
        {
            _game.Roll(firstBallPins);
            Assert.Equal(firstBallPins, _game.Score());
        }

        [Fact]
        public void FirstBallTenShouldScoreTen()
        {
            _game.Roll(10);
            Assert.Equal(10, _game.Score());
        }

        [Theory]
        [InlineData(1, 2)]
        [InlineData(5, 5)]
        public void SecondBallAddsToFirstBallScore(int firstBallPins, int secondBallPins)
        {
            _game.Roll(firstBallPins);
            _game.Roll(secondBallPins);
            Assert.Equal(firstBallPins + secondBallPins, _game.Score());
        }

        [Theory]
        [InlineData(1, 9)]
        [InlineData(5, 6)]
        [InlineData(8, 6)]
        public void FrameScoreCannotExceedTen(int firstBallPins, int secondBallPins)
        {
            _game.Roll(firstBallPins);
            _game.Roll(secondBallPins);
            Assert.InRange(_game.Score(),0,10);
        }
    }
}
