using Xunit;
using CelesteMountain.Models.ViewModels;

namespace CelesteMountainTests.Models
{
    public class QuizTest
    {
        [Fact]
        public void WrongAnswersIdentifiedTest()
        {
            // Arrange
            var viewModel = new QuizModel
            {
                Questions = new List<Question>
                {
                    new Question { Text = "What is 2+2?", Options = new List<string> { "3", "4", "5" }, CorrectAnswerIndex = 1, UserAnswerIndex = 0 }
                }
            };

            // Act
            viewModel.CalculateScore();

            // Assert
            Assert.False(viewModel.Questions[0].IsCorrect);
        }

        [Fact]
        public void RightAnswersIdentifiedTest()
        {
            // Arrange
            var viewModel = new QuizModel
            {
                Questions = new List<Question>
                {
                    new Question { Text = "What is 2+2?", Options = new List<string> { "3", "4", "5" }, CorrectAnswerIndex = 1, UserAnswerIndex = 1 }
                }
            };

            // Act
            viewModel.CalculateScore();

            // Assert
            Assert.True(viewModel.Questions[0].IsCorrect);
        }
    }
}