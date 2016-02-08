namespace VideoNotes.Validation.Common.Helpers
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Linq;
    using VideoNotes.Validation.Common;

    public class ValidationException : Exception
    {
        public ValidationException(IEnumerable<ValidationResult> r)
            : base(GetFirstErrorMessage(r))
        {
            this.Errors =
                new ReadOnlyCollection<ValidationResult>(r.ToArray());
        }

        public ReadOnlyCollection<ValidationResult> Errors { get; private set; }

        private static string GetFirstErrorMessage(
            IEnumerable<ValidationResult> errors)
        {
            return errors.First().Message;
        }
    }
}
