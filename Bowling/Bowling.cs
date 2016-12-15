namespace Bowling
{
    public class BowlingGame
    {
        const int FIRSTFRAME = 1;
        const int LASTFRAME = 10;
        private int _frame = FIRSTFRAME;
        private int _rollInFrame = FIRSTFRAME;
        private readonly int[,] _scorecardrolls = new int[LASTFRAME + 1, 3];
        private readonly int[] _scorecardframe = new int[LASTFRAME + 1];

        public BowlingGame()
        {
            for (var f = FIRSTFRAME; f <= LASTFRAME; f++)
            {
                _scorecardframe[f] = 0;
                for (var r = 1; r == 2; r++)
                    _scorecardrolls[f, r] = 0;
            }
        }

        public void Roll(int pins)
        {
            if (_rollInFrame == 2 && (_scorecardrolls[_frame, 1] + pins > 10))
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

            for (var frame = FIRSTFRAME; frame <= LASTFRAME; frame++)
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
    }
}
