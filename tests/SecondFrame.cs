using Bowling;
using Xunit;

namespace Tests
{
    public class SecondFrame
    {
        private readonly BowlingGame _game = new BowlingGame();

        [Theory]
        [InlineData(3, 5, 4, 12)]
        [InlineData(5, 6, 4, 14)]
        [InlineData(6, 5, 9, 28)] // spare
        public void FirstBallShouldAddToFirstFrame(int frameOneBallOne, int frameOneBallTwo, int frameTwoBallOne,
            int expectedScore)
        {
            //first frame
            _game.Roll(frameOneBallOne);
            _game.Roll(frameOneBallTwo);
            //second frame
            _game.Roll(frameTwoBallOne);

            Assert.Equal(expectedScore, _game.Score());
        }
    }
}