using Ardalis.GuardClauses;

namespace Bowling
{
    public class BowlingGame
    {
        private const int MinPinsPerBall = 0;
        private const int MaxPinsPerBall = 10;
        private const int MaxPinsPerFrame = 10;
        private int _score;
        private int _frame = 1;
        private int _rollInFrame = 1;
        private int _frameScore = 0;

        public void Roll(int pins)
        {
            Guard.Against.OutOfRange(pins, $"pins ({MinPinsPerBall}-{MaxPinsPerBall})", MinPinsPerBall, MaxPinsPerBall);

            if (_frameScore + pins > MaxPinsPerFrame)
                pins = MaxPinsPerFrame - _frameScore;
            else
                _frameScore += pins;

            _score += pins;
            _rollInFrame++;
            if (_rollInFrame > 2)
            {
                _rollInFrame = 1;
                _frame++;
                _frameScore = 0;
            }
        }

        public int Score()
        {
            return _score;
        }
    }
}