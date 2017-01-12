namespace Bowling
{
    public class BowlingGame
    {
        const int Firstframe = 1;
        const int Lastframe = 10;
        private int _frame = Firstframe;
        private int _rollInFrame = Firstframe;
        private readonly int[,] _scorecardrolls = new int[Lastframe + 3, 3]; // need to hold up to three strikes for 10th frame
        private readonly int[] _scorecardframe = new int[Lastframe + 3];

        public void Roll(int pins)
        {
            if (TenOnFirstRoll(pins)) // strike
            {
                pins = 10;
                _scorecardrolls[_frame, _rollInFrame] = pins;
                _frame++; // there will be no roll#2, just jump to next frame. 
                return;
            }
            if (TenOnTwoRolls(pins)) // spare
            {
                pins = 10 - _scorecardrolls[_frame, 1];
            }

            _scorecardrolls[_frame, _rollInFrame] = pins;

            _rollInFrame++;
            if (_rollInFrame <= 2) return;
            //reset for next frame 
            _frame++;
            _rollInFrame = 1;
        }

        public int Score()
        {
            int score = 0;

            for (var frame = Firstframe; frame <= Lastframe; frame++)
            {
                _scorecardframe[frame] = _scorecardrolls[frame, 1] + _scorecardrolls[frame, 2];

                if (FrameIsAStrike(frame))
                {
                    _scorecardframe[frame] += _scorecardrolls[frame + 1, 1];
                    if (FrameIsAStrike(frame+1)) // next frame was also a strike
                    { _scorecardframe[frame] += _scorecardrolls[frame + 2, 1]; } // add first ball from 2 frames forward
                    else
                    { _scorecardframe[frame] += _scorecardrolls[frame + 1, 2]; } // add second ball from next frame
                }

                if (FrameIsASpare(frame))
                {
                    _scorecardframe[frame] += _scorecardrolls[frame + 1, 1];
                }

                // accumulate the game score 
                score = score + _scorecardframe[frame];
            }
            return score;
        }

        private bool FrameIsASpare(int f)
        {
            return (_scorecardrolls[f, 1] + _scorecardrolls[f, 2] == 10) && _scorecardrolls[f, 1] != 10;
        }

        private bool FrameIsAStrike(int f)
        {
            return _scorecardrolls[f, 1] == 10;
        }

        private bool TenOnFirstRoll(int pins)
        {
            return _rollInFrame == 1 && pins >= 10;
        }

        private bool TenOnTwoRolls(int pins)
        {
            return _rollInFrame == 2 && (_scorecardrolls[_frame, 1] + pins > 10);
        }

    }
}
