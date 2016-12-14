using System;

namespace Bowling
{
    public class BowlingGame
    {
        private int _score = 0;
        public void Roll(int pins)
        {
            _score += pins;
            if (_score > 10)
            {
                _score = 10;
            }
        }

        public int Score()
        {
            return _score;
        }

    }
}
