namespace VideoNotes.Validation.Common
{
    using System.Collections.Generic;
    using System.Linq;
    
    public sealed class DefaultValidator<T> : Validator<T>
    {
        protected override IEnumerable<ValidationResult> Validate(T entity)
        {
           return Enumerable.Empty<ValidationResult>();
        }
    }
}
