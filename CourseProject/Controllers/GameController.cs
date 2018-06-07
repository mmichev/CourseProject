using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Repositories;
using CourseProject.Models;
using DataAccess;
using CourseProject.Helpers;

namespace CourseProject.Controllers
{
    public class GameController : Controller
    {
        public ActionResult Edit()
        {

            GameRepository repo = new GameRepository();

            GameViewModel model = new GameViewModel(repo.GetAll());

            return View(model);
        }

        [HttpGet]
        public ActionResult EditGame(int id = 0)
        {

            if (!LoginUserSession.Current.IsAdministrator)
            {
                return RedirectToAction("Edit");
            }

            CategoryRepository catRepo = new CategoryRepository();

            List<Category> categories = catRepo.GetAll();

            ViewBag.Categories = new SelectList(categories, "ID", "Name");

            GameRepository gameRepo = new GameRepository();

            GameViewModel game;

            if (id != 0)
            {
                game = new GameViewModel(gameRepo.GetByID(id));
            }
            else
            {
                game = new GameViewModel(new Game());
            }

            return View(game);

        }

        [HttpPost]
        public ActionResult EditGame(GameViewModel viewModel)
        {
            if (LoginUserSession.Current.IsAuthenticated)
            {
                if (viewModel == null)
                {
                    TempData["Message"] = "No View Model";
                    return RedirectToAction("Edit");
                }

                GameRepository repo = new GameRepository();
                Game game = repo.GetByID(viewModel.ID);

                if (game == null)
                {
                    game = new Game();
                }

                game.Name = viewModel.Name;
                game.DateOfPublishing = viewModel.DateOfRelease;
                game.Category = viewModel.CategoryID;
                game.GameCategory = viewModel.GameCategory;

                repo.Save(game);

                TempData["Mesage"] = "Game was successfully saved!";
                return RedirectToAction("Edit");
            }


            TempData["ErrorMessage"] = "Please log in";
            return RedirectToAction("Login", "Login");

        }

        public ActionResult Delete(int id = 0)
        {

            if (!LoginUserSession.Current.IsAdministrator)
            {
                return Edit();
            }

            GameRepository repo = new GameRepository();
            if (repo.GetByID(id) != null)
            {
                repo.DeleteByID(id);
                TempData["Message"] = "Successfully deleted game!";
            }
            else
            {
                TempData["ErrorMessage"] = "No such game!";
            }
            return RedirectToAction("Edit");
        }


    }
}