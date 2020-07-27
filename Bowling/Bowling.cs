using Ardalis.GuardClauses;

namespace Bowling
{
    public class BowlingGame
    {
        private const int MinPinsPerBall = 0;
        private const int MaxPinsPerBall = 10;
        private const int MaxPinsPerFrame = 10;
        private int _score;

        public void Roll(int pins)
        {
            Guard.Against.OutOfRange(pins, $"pins ({MinPinsPerBall}-{MaxPinsPerBall})", MinPinsPerBall, MaxPinsPerBall);

            if (_score + pins > MaxPinsPerFrame)
                _score = MaxPinsPerFrame;
            else
                _score += pins;
        }

        public int Score()
        {
            return _score;
        }
    }
}