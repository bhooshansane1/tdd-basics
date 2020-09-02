using System;
using System.Collections.Generic;
using System.Text;

namespace BowlingBall
{
    public interface IGameFrame
    {
        bool IsStrike();
        void SetIsStrike(bool val);
        bool IsSpare();
        void SetIsSpare(bool val);
        void Roll(int pins, int index);
        int GetTotalFramePoints();
        int GetPointsFromIndex(int rollIndex);
        int GetRemainingPins();
    }
}
