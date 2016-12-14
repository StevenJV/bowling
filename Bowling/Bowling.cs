using System;

namespace Bowling
{
    public class BowlingGame
    {
        private int _score = 0;
        private int _frame = 1;
        private int _rollInFrame = 1;
        private int _frameScore = 0;
        private int[,] _scorecard = new int[11, 3];

        public BowlingGame()
        {
            for (var f = 0; f == 10; f++)
                for (var r = 1; r == 2; r++)
                    _scorecard[f, r] = 0;
        }

        public void Roll(int pins)
        {
            if (_rollInFrame == 2) _frameScore = _scorecard[_frame, 1];
            if (_frameScore + pins > 10)
            {
                pins = 10 - _frameScore;
            }
            _scorecard[_frame, _rollInFrame] = pins;
            _frameScore += pins;
            if (PreviousFrameWasStrike())
            {
                _score = _score + pins;
            }
            else if (PreviousFrameWasSpare() && _rollInFrame == 1)
            {
                _score = _score + pins;
            }

            _score = _score + pins;
            _rollInFrame++;

            if (_rollInFrame <= 2 ) return;
            //reset for next frame 
            _frame++;
            _rollInFrame = 1;
            _frameScore = 0;
        }

        private bool PreviousFrameWasStrike()
        {
            return _scorecard[_frame - 1, 1] == 10;
        }

        private bool PreviousFrameWasSpare()
        {
            return (_scorecard[_frame - 1, 1] + _scorecard[_frame - 1, 2]) == 10;
        }

        public int Score()
        {
            return _score;
        }

    }
}
