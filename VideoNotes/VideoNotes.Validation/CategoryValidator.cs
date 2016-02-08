namespace VideoNotes.Validation
{
    using System.Collections.Generic;
    using VideoNotes.Core.Entities;
    using VideoNotes.Validation.Common;

    public sealed class CategoryValidator : Validator<Category>
    {
        protected override IEnumerable<ValidationResult> Validate(Category entity)
        {
            if (entity.Name.Trim().Length == 0)
            {
                yield return new ValidationResult(
                    "Name",
                    "Category name is required.");
            }

            if (entity.ApplicationUserId.Trim().Length == 0)
            {
                yield return new ValidationResult(
                    "UserId",
                    "User ID is required.");
            }

            if (entity.Name.Trim().Length > 50)
            {
                yield return new ValidationResult(
                    "Name", 
                    "Category name  must contain less than 50 chars!");
            }
        }
    }
}
