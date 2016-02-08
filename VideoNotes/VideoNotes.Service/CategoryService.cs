namespace VideoNotes.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VideoNotes.Core.Entities;
    using VideoNotes.DataAccess;
    using VideoNotes.Service.Cotracts;
    using VideoNotes.Validation.Common;
    using VideoNotes.Validation.Common.Helpers;

    public class CategoryService : ICategoryService, IService
    {
        private IValidationProvider validationProvider;
        private IRepository<Category> categoryRepository;

        public CategoryService(
            IRepository<Category> categoryRepository,
            IValidationProvider validationProvider)
        {
            this.categoryRepository = categoryRepository;
            this.validationProvider = validationProvider;
        }

        public ICollection<Category> GetCategoriesForUser(string appUserId)
        {
            return this.categoryRepository.Table.Where(x => x.ApplicationUserId == appUserId).ToList();
        }

        public void AddCategory(Category category)
        {
            this.validationProvider.Validate(category);
            this.categoryRepository.Insert(category);
        }

        public void DeleteCategoryById(string categoryId, string userId)
        {
            int k = int.Parse(categoryId);
            Category category = this.categoryRepository.GetById(k);
            if (category != null && category.ApplicationUserId == userId)
            {
                this.categoryRepository.Delete(category);
                return;
            }
            else
            {
                throw new ValidationException(new List<ValidationResult>() { new ValidationResult("user", ValidationExceptionMessages.UserNotAuthenticated(userId, "delete category", categoryId)) });
            }
        }
    }
}
