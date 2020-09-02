using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace BowlingBall
{
    public class GameFrame:IGameFrame
    {
        private const int INIT_VAL = -1;
        readonly int[] rollPoints;
        bool isStrike { get; set; }
        bool isSpare { get; set; }
        [Range(1, 10)]
        int frameNumber { get; set; }
        [Range(0, 300)]
        int points { get; set; }
        [Range(0,10)]
        int pins { get; set; }
        bool isFrozen { get; set; }

        public GameFrame()
        {
            isStrike = false;
            isSpare = false;
            rollPoints = new int[3] { INIT_VAL, INIT_VAL, INIT_VAL };
        }

        public bool IsStrike()
        {
            return isStrike;
        }
        public void SetIsStrike(bool val)
        {
            isStrike = val;
        }
        public bool IsSpare()
        {
            return isSpare;
        }
        public void SetIsSpare(bool val)
        {
            isSpare = val;
        }
        public void Roll(int pins, int index)
        {
                rollPoints[index] = pins;
        }
        public void SetFrameNumber(int frameNo)
        {
            frameNumber = frameNo;
        }
        public int GetTotalPoints()
        {
            return points;
        }
        public int GetTotalFramePoints()
        {
            int tempPoints = 0;
            foreach (int points in rollPoints)
            {
                if (points != INIT_VAL)
                {
                    tempPoints += points;
                }
            }
            return tempPoints;
        }
        public void SetTotalPoints(int number)
        {
            points = number;
        }
        public int GetPointsFromIndex(int rollIndex)
        {
            return rollPoints[rollIndex]!=INIT_VAL? rollPoints[rollIndex]:0;
        }
        public void FreezeFrame()
        {
            isFrozen=true;
        }
        public bool IsFrozen()
        {
            return isFrozen;
        }
        public int GetRemainingPins()
        {
            if (frameNumber != 9)
            {
                if (rollPoints[0] == INIT_VAL)
                    return 10;
                else if (rollPoints[1] == INIT_VAL)
                    return 10 - rollPoints[0];
                return 0;
            }
            else
            {
                if (rollPoints[0] == INIT_VAL)
                    return 10;
                else if (rollPoints[1] == INIT_VAL && rollPoints[0]==10)
                    return 10;
                else if (rollPoints[1] == INIT_VAL && rollPoints[0] != 10)
                    return 10 - rollPoints[0];
                else if (rollPoints[0] == 10 && rollPoints[1] == 10)
                    return 10;
                else if (rollPoints[0] != 10 && rollPoints[1] != 10)
                    return 10;
                return 0;
            }
        }
    }
}
