using MVCTodoAppSample.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCTodoAppSample.Controllers
{
    public class HomeController : Controller
    {
        DatabaseContext db = new DatabaseContext();

        public ActionResult List()
        {
            ViewBag.TaskList = db.Tasks.ToList();

            return View();
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Add(string tasktext, DateTime taskdate)
        {
            Task newTask = new Task()
            {
                Id = Guid.NewGuid(),
                Text = tasktext,
                Date = taskdate,
                IsCompleted = false
            };

            db.Tasks.Add(newTask);
            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Edit(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            Task task = db.Tasks.Find(id);

            if (task == null)
                return HttpNotFound();
            //return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            ViewBag.Task = task;

            return View();
        }

        [HttpPost]
        public ActionResult Edit(Guid? id, string tasktext, DateTime taskdate, bool taskiscompleted)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            Task task = db.Tasks.Find(id);

            if (task == null)
                return HttpNotFound();
            //return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            task.Text = tasktext;
            task.Date = taskdate;
            task.IsCompleted = taskiscompleted;

            db.SaveChanges();

            return RedirectToAction("List");
        }

        public ActionResult Delete(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            Task task = db.Tasks.Find(id);

            if (task == null)
                return HttpNotFound();
            //return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            ViewBag.Task = task;

            return View();
        }

        [HttpPost]
        [ActionName("Delete")]
        public ActionResult DeleteAccepted(Guid? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);

            Task task = db.Tasks.Find(id);

            if (task == null)
                return HttpNotFound();
            //return new HttpStatusCodeResult(System.Net.HttpStatusCode.NotFound);

            db.Tasks.Remove(task);
            db.SaveChanges();

            return RedirectToAction("List");
        }
    }
}