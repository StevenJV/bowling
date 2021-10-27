using Bowling;
using Xunit;

namespace BowlingTests
{
  public class BowlingGameTests
  {
    private BowlingGame game = new BowlingGame();

    [Theory]
    [InlineData(0, 0)]
    [InlineData(1, 1)]
    [InlineData(2, 2)]
    [InlineData(3, 3)]
    [InlineData(4, 4)]
    [InlineData(5, 5)]
    [InlineData(6, 6)]
    [InlineData(7, 7)]
    [InlineData(8, 8)]
    [InlineData(9, 9)]
    [InlineData(10, 10)]
    public void SingleDigitPinsAreScoredCorrectly(int value1, int expected)
    {
      game.Roll(value1);
      Assert.Equal(expected, game.Score());

    }
  }
}
