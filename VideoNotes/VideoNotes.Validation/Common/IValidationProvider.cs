namespace VideoNotes.Validation.Common
{
    using System;
    using System.Collections;
    using System.Collections.Generic;

    public interface IValidationProvider
    {
        void Validate(object entity);

        void ValidateAll(IEnumerable entities);
    }
}
