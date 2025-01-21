using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using System.IO;
using System.Collections.Generic;
using CelesteMountain.Models;

namespace CelesteMountain.Controllers
{
    public class QuizController : Controller
    {
        //I'll use json to store the quiz data for this, though we'll probably switch to database later
        private readonly string _quizFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Models/AppData", "quizdata.json");
        [HttpGet]
        public IActionResult Index()
        {
            // Read and deserialize the json file to the list of Questions
            var jsonString = System.IO.File.ReadAllText(_quizFilePath);
            var questionsFromJson = JsonSerializer.Deserialize<List<Question>>(jsonString);

            var viewModel = new QuizModel
            {
                Questions = questionsFromJson ?? new List<Question>()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(QuizModel submittedViewModel)
        {
            // Reload the original questions to ensure we have the correct answers
            var jsonString = System.IO.File.ReadAllText(_quizFilePath);
            var correctQuestions = JsonSerializer.Deserialize<List<Question>>(jsonString);

            // Update the UserAnswerIndex for the original questions with the submitted answers
            for (int i = 0; i < correctQuestions.Count; i++)
            {
                correctQuestions[i].UserAnswerIndex = submittedViewModel.Questions[i].UserAnswerIndex;
            }

            // Create a new ViewModel with the correct questions
            var viewModel = new QuizModel
            {
                Questions = correctQuestions
            };

            int score = viewModel.CalculateScore();
            ViewData["Score"] = score;
            ViewData["Checked"] = true;

            return View(viewModel);
        }
    }
}
