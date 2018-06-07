using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DataAccess;

namespace CourseProject.Models
{

    public class CategoriesViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public CategoriesViewModel(int ID, string Name)
        {
            this.ID = ID;
            this.Name = Name;
        }
    }
    
    public class CategoryViewModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public List<CategoriesViewModel> categoryList;

        public CategoryViewModel()
        {
            categoryList = new List<CategoriesViewModel>();
        }

        public CategoryViewModel (Category category)
        {
            ID = category.ID;
            Name = category.Name;
        }

        public CategoryViewModel(List<Category> categories)
            :this()
        {
            foreach (Category category in categories)
            {
                categoryList.Add(new CategoriesViewModel(category.ID, category.Name));
            }
        }
    }
}