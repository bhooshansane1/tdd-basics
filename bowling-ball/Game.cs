using System;
using System.Collections.Generic;

namespace BowlingBall
{
    public class Game
    {
        #region Declaration
        readonly GameFrame[] frames = new GameFrame[10];
        const int MAX_FRAMES = 10;
        bool isSpareOrStrike = false;
        int currentFrameNumber = 0;
        int currentRoll = 0;
        #endregion Declaration

        #region Public Methods
        public Game()
        {
            InitializeFrames();
        }
        public bool Roll(int pins)
        {
            try
            {
                if (pins < 0 || pins > 10)
                    return false;
                if(frames[currentFrameNumber].GetRemainingPins() < pins)
                    return false;
                frames[currentFrameNumber].Roll(pins, currentRoll);
                IsStrikeOrSpare();
                StoreRollScore(pins);
                return true;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public int GetScore()
        {
            try
            {
                CalculateScore();
                return frames[currentFrameNumber].GetTotalPoints();
            }
            catch (Exception)
            {

                throw;
            }
        }
        #endregion Interface Methods

        #region Private Methods
        private void CalculateScore()
        {
            for (int i = 0; i <= currentFrameNumber; i++)
            {
                if (!frames[i].IsFrozen())
                {
                    if (frames[i].IsSpare())
                    {
                        SpareClaculation(i);
                    }
                    else if (frames[i].IsStrike())
                    {
                        StrikeCalculation(i);
                    }
                    else
                    {
                        if (i > 0)
                            frames[i].SetTotalPoints(frames[i - 1].GetTotalPoints() + frames[i].GetTotalFramePoints());
                        else
                            frames[i].SetTotalPoints(frames[i].GetTotalFramePoints());
                    }
                }
            }
        }

        /// <summary>
        /// Calculate the score using strike logic
        /// </summary>
        /// <param name="i"></param>
        private void StrikeCalculation(int i)
        {
            if (i + 1 <= currentFrameNumber && frames[i + 1].IsStrike())
            {
                if (i + 2 <= currentFrameNumber)
                {
                    if (frames[i + 2].IsStrike())
                    {
                        if (i > 0)
                            frames[i].SetTotalPoints(frames[i - 1].GetTotalPoints() + frames[i].GetTotalFramePoints() + frames[i + 1].GetPointsFromIndex(0) + frames[i + 2].GetPointsFromIndex(0));
                        else
                            frames[i].SetTotalPoints(frames[i].GetTotalFramePoints() + frames[i + 1].GetTotalFramePoints() + frames[i + 2].GetTotalFramePoints());
                    }
                    else
                    {
                        frames[i].SetTotalPoints(frames[i].GetTotalPoints() + frames[i + 1].GetTotalPoints() + frames[i + 2].GetPointsFromIndex(0));
                    }
                }
                else
                {
                    if (i > 0)
                        frames[i].SetTotalPoints(frames[i - 1].GetTotalPoints() + frames[i].GetTotalFramePoints() + frames[i + 1].GetPointsFromIndex(0) + frames[i + 1].GetPointsFromIndex(1));
                }
            }
            else
            {
                if (i + 1 <= currentFrameNumber)
                {
                    frames[i].SetTotalPoints(frames[i].GetTotalPoints() + frames[i + 1].GetPointsFromIndex(0) + frames[i + 1].GetPointsFromIndex(1));
                    frames[i].FreezeFrame();
                }
                else if (i == currentFrameNumber)
                {
                    isSpareOrStrike = true;
                    frames[i].SetTotalPoints(frames[i - 1].GetTotalPoints() + frames[i].GetTotalFramePoints());
                }
            }
        }

        /// <summary>
        /// Calculates the score using spare logic
        /// </summary>
        /// <param name="i"></param>
        private void SpareClaculation(int i)
        {
            if (i + 1 <= currentFrameNumber && frames[i + 1].GetPointsFromIndex(0) != -1)
            {
                if (i > 0)
                {
                    frames[i].SetTotalPoints(frames[i - 1].GetTotalPoints() + frames[i].GetTotalFramePoints() + frames[i + 1].GetPointsFromIndex(0));
                }
                else
                    frames[i].SetTotalPoints(frames[i].GetTotalFramePoints() + frames[i + 1].GetPointsFromIndex(0));
            }
            else if (i == currentFrameNumber)
            {
                isSpareOrStrike = true;
                frames[i].SetTotalPoints(frames[i - 1].GetTotalPoints() + frames[i].GetTotalFramePoints());
            }
            frames[i].FreezeFrame();
        }

        /// <summary>
        /// Create 10 frames with basic property initialization
        /// </summary>
        private void InitializeFrames()
        {
            for (int i = 0; i < MAX_FRAMES; i++)
            {
                GameFrame game = new GameFrame();
                game.SetFrameNumber(i);
                frames[i] = game;
            }
        }
        /// <summary>
        /// Checkes if any of the frame is strike or spare
        /// </summary>
        /// <returns></returns>
        private bool IsStrikeOrSpare()
        {
            if (frames[frames.Length-1].IsSpare() || frames[frames.Length - 1].IsStrike())
            {
                isSpareOrStrike = true;
                return isSpareOrStrike;
            }
            return false;
        }

        /// <summary>
        /// Store score if roll is not a strike
        /// </summary>
        private void StoreNonStrikeRolls()
        {
            if (currentFrameNumber < 9)
            {
                if (currentRoll == 0)
                {
                    currentRoll++;
                }
                else if (currentRoll == 1)
                {
                    frames[currentFrameNumber].SetIsSpare(frames[currentFrameNumber].GetTotalFramePoints() == 10);
                    currentRoll = 0;
                    currentFrameNumber++;
                }
            }
            else
            {
                if (currentRoll == 0)
                {
                    currentRoll++;
                }
                else if (currentRoll == 1)
                {
                    frames[currentFrameNumber].SetIsSpare(frames[currentFrameNumber].GetTotalFramePoints() == 10);
                    currentRoll++;
                }
            }
        }

        /// <summary>
        /// Store score if roll is a strike
        /// </summary>
        private void StoreStrikeRolls()
        {
            if (currentFrameNumber < 9)
            {
                currentFrameNumber++;
            }
            else
            {
                if (currentRoll == 0)
                {
                    currentRoll++;
                }
                else if (currentRoll == 1 && isSpareOrStrike)
                {
                    currentRoll++;
                }
            }
        }

        /// <summary>
        /// Stores scores per frame
        /// </summary>
        /// <param name="pins"></param>
        private void StoreRollScore(int pins)
        {
            if (pins == 10)
            {
                frames[currentFrameNumber].SetIsStrike(true);
                StoreStrikeRolls();
            }
            else
            {
                StoreNonStrikeRolls();
            }
        }
        #endregion Private Methods
    }
}

