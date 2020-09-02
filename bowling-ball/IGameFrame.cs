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
        void SetFrameNumber(int frameNo);
        int GetTotalPoints();
        int GetTotalFramePoints();
        void SetTotalPoints(int number);
        int GetPointsFromIndex(int rollIndex);
        void FreezeFrame();
        bool IsFrozen();
        int GetRemainingPins();

    }
}
