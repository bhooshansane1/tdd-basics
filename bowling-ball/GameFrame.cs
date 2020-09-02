using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BowlingBall
{
    public class GameFrame:IGameFrame
    {
        public bool IsStrike()
        {
            throw new NotImplementedException();
        }
        public void SetIsStrike(bool val)
        {
            throw new NotImplementedException();
        }
        public bool IsSpare()
        {
            throw new NotImplementedException();
        }
        public void SetIsSpare(bool val)
        {
            throw new NotImplementedException();
        }
        public void Roll(int pins, int index)
        {
            throw new NotImplementedException();
        }
        public int GetTotalFramePoints()
        {
            throw new NotImplementedException();
        }
        public int GetPointsFromIndex(int rollIndex)
        {
            throw new NotImplementedException();
        }
        public int GetRemainingPins()
        {
            throw new NotImplementedException();
        }
    }
}
