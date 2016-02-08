namespace VideoNotes.Validation.Common
{
    using System.Collections.Generic;

    public interface IValidator
    {
        IEnumerable<ValidationResult> Validate(object entity);
    }
}
