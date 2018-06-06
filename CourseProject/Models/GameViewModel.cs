using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace CourseProject.Models
{
    public class GamesViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfRelease { get; set; }
        public Category GameCategory { get; set; }
        public int CategoryID { get; set; }

        public GamesViewModel(Game game)
        {
            ID = game.ID;
            Name = game.Name;
            DateOfRelease = game.DateOfPublishing;
            GameCategory = game.GameCategory;
            CategoryID = game.Category;

        }

    }

    public class GameViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public DateTime DateOfRelease { get; set; }
        public Category GameCategory { get; set; }
        public int CategoryID { get; set; }
        public List<GamesViewModel> gameList;

        public GameViewModel()
        {
            gameList = new List<GamesViewModel>();

        }

        public GameViewModel(Game game)
        {
            ID =game.ID;
            Name = game.Name;
            DateOfRelease = game.DateOfPublishing;
            GameCategory =game.GameCategory;
            CategoryID = game.Category;
        }
        public GameViewModel(List<Game> games)
            :this()
        {
            foreach (Game game in games)
            {

                GamesViewModel gameModel = new GamesViewModel(game);

                gameList.Add(gameModel);
            }
        }

    }
}