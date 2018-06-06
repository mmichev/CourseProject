using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace CourseProject.Models
{

    public class UsersViewModel
    {
        public int ID { get; set; }
        public string Username { get; set; }

        public UsersViewModel(int ID, string Username)
        {
            this.ID = ID;
            this.Username = Username;
        }
    }

    public class UserViewModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public List<UsersViewModel> userList;

        public UserViewModel()
        {
            userList = new List<UsersViewModel>();
        }

        public UserViewModel(User user)
        {
            ID = user.ID;
            Username = user.Username;
        }

        public UserViewModel(List<User> categories)
            : this()
        {
            foreach (User user in categories)
            {
                userList.Add(new UsersViewModel(user.ID, user.Username));
            }
        }
    }
}