using QuizLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuizGameWebApp.Controllers
{
    public class QuizQuestionController : ApiController
    {
        private static IQuizRepository _quizRepo;
        public QuizQuestionController()
        {
            if (_quizRepo == null)
            {
                _quizRepo = new QuizRepositoryEF();
                // quizRepo.LoadSampleQuestions();
            }
        }

        public QuizQuestionController(IQuizRepository newRepo)
        {
            _quizRepo = newRepo;
        }
        //GET: api/QuizQuestion
        public QuestionViewModel Get()
        {
            return _quizRepo.GetQuestion();
        }

        [Route("api/quizquestion/isanswercorrect")]
        [HttpGet]
        public AnswerResults IsAnswerCorrect(int questionId, int answerId)
        {
            var question = _quizRepo.GetQuestionById(questionId);
            AnswerResults results = new AnswerResults();
            var selectedAnswer = question.Answers.First(a => a.AnswerId == answerId);

            if (selectedAnswer != null)
            {
                results.IsCorrect = selectedAnswer.IsCorrect;
            }

            return results;
        }
        // GET: api/QuizQuestion/5
        public string Get(int id)
        {
            return "value";
        }

        //POST: api/QuizQuestion
        public void Post([FromBody]string value)
        {
        }

        //PUT: api/QuizQuestion/5
        public void Put(int id, [FromBody]string value)
        {
        }
        //DELETE: api/QuizQuestion/5
        public void Delete(int id)
        {
        }
    }
}