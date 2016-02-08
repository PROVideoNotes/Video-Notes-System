namespace VideoNotes.Service.Cotracts
{
    using System.Collections.Generic;
    using System.Linq;
    using VideoNotes.Core.Entities;
    using VideoNotes.DataAccess;

    public interface ICategoryService
    {
        ICollection<Category> GetCategoriesForUser(string appUser);

        void AddCategory(Category category);

        void DeleteCategoryById(string categoryId, string userId);
    }
}
