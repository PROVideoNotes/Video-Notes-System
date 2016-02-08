namespace VideoNotes.Validation
{
    using System;
    using System.Collections.Generic;
    using VideoNotes.Core.Entities;
    using VideoNotes.Validation.Common;
   
    public sealed class NoteValidator : Validator<Note>
    {
        protected override IEnumerable<ValidationResult> Validate(Note entity)
        {
            if (entity.Content.Trim().Length == 0)
            {
                yield return new ValidationResult("Content", "Content is required.");
            }

            if (entity.Time == 0)
            {
                yield return new ValidationResult("Time", "Time can't be 0 for this note.");
            }

            if (entity.Title.Trim().Length == 0)
            {
                yield return new ValidationResult("Title", "Title is required.");
            }
        }
    }
}
