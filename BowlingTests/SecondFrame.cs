using Bowling;
using Xunit;
using Assert = Xunit.Assert;

namespace BowlingTests
{
    public class SecondFrame
    {
        private readonly BowlingGame _game = new BowlingGame();

        [Theory]
        [InlineData(3, 5, 4, 12)]
        [InlineData(5, 6, 4, 18)] // spare
        [InlineData(6, 5, 9, 28)] // spare
        [InlineData(10, 0, 9, 28)] // strike
        [InlineData(10, 2, 9, 28)] // strike, mis-recorded
        public void FirstBallShouldAddToFirstFrame(int frameOneBallOne, int frameOneBallTwo, int frameTwoBallOne, int expectedScore)
        {
            //first frame
            _game.Roll(frameOneBallOne);
            _game.Roll(frameOneBallTwo);
            //second frame 
            _game.Roll(frameTwoBallOne);

            Assert.Equal(expectedScore, _game.Score());
        }

        [Theory]
        [InlineData(3, 5, 4, 5, 17)]
        [InlineData(5, 5, 5, 4, 24)] //spare plus first ball = 15 first frame, plus second frame's 9 = 24 
        public void SecondBallShouldAddToFirstFrame(int frameOneBallOne, int frameOneBallTwo, int frameTwoBallOne,
            int frameTwoBallTwo, int expectedScore)
        {
            //first frame
            _game.Roll(frameOneBallOne);
            _game.Roll(frameOneBallTwo);
            //second frame 
            _game.Roll(frameTwoBallOne);
            _game.Roll(frameTwoBallTwo);

            Assert.Equal(expectedScore, _game.Score());
        }

    }
}
