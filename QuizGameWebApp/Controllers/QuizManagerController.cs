using QuizLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuizGameWebApp.Controllers
{
    public class QuizManagerController : Controller
    {
        private static IQuizRepository _quizRepo;

        public QuizManagerController()
        {
            if(_quizRepo == null)
            {
                _quizRepo = new QuizRepositoryEF();
               
            }
        }
        
        // GET: QuizManager
        public ActionResult Index()
        {
            return View(_quizRepo.GetQuestions());
        }

        // GET: QuizManager/Details/5
        public ActionResult Details(int id)
        {
            return View(_quizRepo.GetQuestionById(id));
        }

        // GET: QuizManager/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: QuizManager/Create
        [HttpPost]
        public ActionResult Create(Question newQuestion)
        {
            try
            {
                _quizRepo.AddQuestion(newQuestion);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: QuizManager/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_quizRepo.GetQuestionById(id));
        }

        // POST: QuizManager/Edit/5
        [HttpPost]
        public ActionResult Edit(Question editQuestion, FormCollection formCollection)
        {
            try
            {
                _quizRepo.UpdateQuestion(editQuestion);
                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return View();
            }
        }

        // GET: QuizManager/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_quizRepo.GetQuestionById(id));
        }

        // POST: QuizManager/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                _quizRepo.DeleteQuestion(id);
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
