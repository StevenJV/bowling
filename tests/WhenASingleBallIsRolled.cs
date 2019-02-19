using Bowling;
using Xunit;

namespace BowlingTests
{
  public class BowlingGameTests
  {
    private BowlingGame game = new BowlingGame();

    [Fact]
    public void SingleDigitPinsAreScoredCorrectly()
    {
      game.Roll(1);
      Assert.Equal(1, game.Score());

    }
  }
}
