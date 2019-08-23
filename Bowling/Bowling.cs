using System;
using System.Net.NetworkInformation;

namespace Bowling
{
    public class BowlingGame
    {
        private int _score = 0;
        public void Roll(int pins)
        {
            var MinPinsPerBall = 0;
            if (pins < MinPinsPerBall)
            {
                pins = MinPinsPerBall;
            }

            var MaxPinsPerBall = 10;
            if (pins > MaxPinsPerBall)
            {
                pins = MaxPinsPerBall;
            }
            _score += pins;
        }

        public int Score()
        {
            return _score;
        }

    }
}
