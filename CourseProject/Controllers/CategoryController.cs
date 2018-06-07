using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CourseProject.Models;
using Repositories;
using DataAccess;
using CourseProject.Helpers;

namespace CourseProject.Controllers
{
    public class CategoryController : Controller
    {
        public ActionResult Edit()
        {
            CategoryRepository repo = new CategoryRepository();

            CategoryViewModel model = new CategoryViewModel(repo.GetAll());
            return View(model);
        }

        [HttpGet]
        public ActionResult EditCategory(int id = 0)
        {
            if (!LoginUserSession.Current.IsAdministrator)
            {
                return RedirectToAction("Edit");
            }

            CategoryRepository repo = new CategoryRepository();

            CategoryViewModel category = new CategoryViewModel();

            Category categoryDb = repo.GetByID(id);

            if (categoryDb != null)
            {
                category = new CategoryViewModel(categoryDb);
            }

            return View(category);

        }

        [HttpPost]
        public ActionResult EditCategory(CategoryViewModel model)
        {

            CategoryRepository repo = new CategoryRepository();
            Category category = repo.GetByID(model.ID);
            if (category == null) category = new Category();
            category.Name = model.Name;
            repo.Save(category);
            return RedirectToAction("Edit");

        }

        public ActionResult Delete(int id = 0)
        {

            if (!LoginUserSession.Current.IsAdministrator)
            {
                return Edit();
            }

            CategoryRepository repo = new CategoryRepository();

            if (repo.GetByID(id) != null)
            {
                Category category = repo.GetByID(id);

                repo.DeleteByID(category.ID);

                TempData["Message"] = "Successfully deleted category!";
            }
            else
            {
                TempData["ErrorMessage"] = "No such category!";
            }
            return RedirectToAction("Edit");
        }


    }
}