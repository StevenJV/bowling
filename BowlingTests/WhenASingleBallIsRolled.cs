using System;
using Bowling;
using Xunit;
using Xunit.Should;

namespace BowlingTests
{
  public class BowlingGameTests
  {
    private BowlingGame game = new BowlingGame();

    [Fact]
    public void SingleDigitPinsAreScoredCorrectly()
    {
      game.Roll(1);
      game.Score().ShouldBe(1);

    }
  }
}
