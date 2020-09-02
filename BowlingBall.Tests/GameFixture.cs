using System;
using Xunit;

namespace BowlingBall.Tests
{
    public class GameFixture
    {
        private Game game;
        private GameFrame gameFrame;

        private void Setup()
        {
            game = new Game();
            gameFrame = new GameFrame();
        }

        [Fact]
        public void GetScore_Return_Zero_Test()
        {
            Setup();
            Assert.Equal(0,game.GetScore());
        }

        [Fact]
        public void All_NoScore_Rolls_Test()
        {
            Setup();
            for (int i = 0; i < 12; i++)
            {
                game.Roll(0);
            }

            Assert.Equal(0, game.GetScore());
        }

        [Fact]
        public void All_Strikes_Rolls_Test()
        {
            Setup();
            for (short i = 0; i < 12; i++)
            {
                game.Roll(10);
            }
            
            Assert.Equal(300,game.GetScore());
        }

        [Fact]
        public void All_Spares_Rolls_Test()
        {
            Setup();
            for (short i = 0; i < 21; i++)
            {
                game.Roll(5);
            }

            Assert.Equal(150, game.GetScore());
        }

        [Fact]
        public void Random_Rolls_Test()
        {
            Setup();
            game.Roll(9);
            game.Roll(1);

            game.Roll(7);
            game.Roll(2);

            game.Roll(4);
            game.Roll(5);

            game.Roll(2);
            game.Roll(2);

            game.Roll(2);
            game.Roll(2);

            game.Roll(2);
            game.Roll(2);

            game.Roll(2);
            game.Roll(2);

            game.Roll(2);
            game.Roll(2);

            game.Roll(2);
            game.Roll(2);

            game.Roll(5);
            game.Roll(5);
            game.Roll(5);


            Assert.Equal(74, game.GetScore());
        }

        [Fact]
        public void Remaining_Pins_Test()
        {
            Setup();
            gameFrame.Roll(9,0);
            Assert.Equal(1, gameFrame.GetRemainingPins());
        }

        [Fact]
        public void IsSpare_Test()
        {
            Setup();
            for (int i = 0; i < 2; i++)
            {
                gameFrame.Roll(5,i);
            }
            gameFrame.SetIsSpare(gameFrame.GetTotalFramePoints() == 10);
            Assert.True(gameFrame.IsSpare());
        }

        [Fact]
        public void IsStrike_Test()
        {
            Setup();
            gameFrame.Roll(10, 0);
            gameFrame.SetIsStrike(gameFrame.GetPointsFromIndex(0) == 10);
            Assert.True(gameFrame.IsStrike());
        }

    }
}
