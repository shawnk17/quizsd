using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace QuizLibrary
{
    public class QuizRepositoryEF : IQuizRepository
    {
        private static Random _randy = new Random();
        public void AddQuestion(Question newQuestion)
        {
            using (var db = new QuizModel())
            {
                db.Questions.Add(newQuestion);
                db.SaveChanges();
            }
        }

        public void DeleteQuestion(int id)
        {
            using (var db = new QuizModel())
            {
                var question = db.Questions.Find(id);
                db.Questions.Remove(question);
                db.SaveChanges();
            }
        }

        public QuestionViewModel GetQuestion()
        { 
            using (var db = new QuizModel())
            {
                var qList = db.Questions
                    .Include(j => j.Answers)
                    .ToList();

                return new QuestionViewModel(qList[_randy.Next(0, qList.Count)]);
            }
        }

        public Question GetQuestionById(int id)
        {
            using (var db = new QuizModel())
            {
                var question = db.Questions.Find(id);
                db.Entry(question).Collection(q => q.Answers).Load();
                return question;
            }
        }

        public List<Question> GetQuestions()
        {
            using (var db = new QuizModel())
            {
                var questions = from q in db.Questions
                                orderby q.QuestionId descending
                                select q;

                return questions.ToList();
            }                
        }

        public List<Question> GetQuestions(int maxNumberOfQuestions)
        {
            using (var db = new QuizModel())
            {
                return db.Questions.Take(maxNumberOfQuestions).ToList();
            }
        }

        public void UpdateQuestion(Question updateQuestion)
        {
            using (var db = new QuizModel())
            {
                

                foreach (var answer in updateQuestion.Answers)
                {
                    var answerEntry = db.Entry(answer);
                    if (answer.AnswerId == 0)
                    {
                        answerEntry.State = EntityState.Added;
                    }
                    else
                    {
                        answerEntry.State = System.Data.Entity.EntityState.Modified;
                    }
                }

                db.Questions.Attach(updateQuestion);
                var entry = db.Entry(updateQuestion);
                entry.State = System.Data.Entity.EntityState.Modified;

                db.SaveChanges();
            }
        }
    }
}
