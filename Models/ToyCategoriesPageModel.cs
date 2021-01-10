using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Crisan_Adriana_proiect.Data;


namespace Crisan_Adriana_proiect.Models
{
    public class ToyCategoriesPageModel: PageModel
    {
        public List<AssignedCategoryData> AssignedCategoryDataList;
        public void PopulateAssignedCategoryData(Crisan_Adriana_proiectContext context,
 Toy toy)
        {
            var allCategories = context.Category;
            var toyCategories = new HashSet<int>(toy.ToyCategories.Select(c => c.ToyID));
            AssignedCategoryDataList = new List<AssignedCategoryData>();
            foreach (var cat in allCategories)
            {
                AssignedCategoryDataList.Add(new AssignedCategoryData
                {
                    CategoryID = cat.ID,
                    Name = cat.CategoryName,
                    Assigned = toyCategories.Contains(cat.ID)
                });
            }
        }

        public void UpdateToyCategories(Crisan_Adriana_proiectContext context, string[] selectedCategories, Toy toyToUpdate)
        {
            if (selectedCategories == null)
            {
                toyToUpdate.ToyCategories = new List<ToyCategory>();
                return;
            }
            var selectedCategoriesHS = new HashSet<string>(selectedCategories);
            var toyCategories = new HashSet<int>
            (toyToUpdate.ToyCategories.Select(c => c.Category.ID));
            foreach (var cat in context.Category)
            {
                if (selectedCategoriesHS.Contains(cat.ID.ToString()))
                {
                    if (!toyCategories.Contains(cat.ID))
                    {
                        toyToUpdate.ToyCategories.Add(new ToyCategory
                        {
                            ToyID = toyToUpdate.ID,
                            CategoryID = cat.ID
                        });
                    }
                }
                else
                {
                    if (toyCategories.Contains(cat.ID))
                    {
                        ToyCategory courseToRemove= toyToUpdate.ToyCategories.SingleOrDefault(i => i.CategoryID == cat.ID);
                        context.Remove(courseToRemove);
                    }
                }
            }
        }

    }
}
