namespace VideoNotes.Validation
{
    using System;
    using VideoNotes.Core.Entities;
    using VideoNotes.Validation.Common;

    public sealed class VideoValidator : Validator<Video>
    {
        protected override System.Collections.Generic.IEnumerable<ValidationResult> Validate(Video entity)
        {
            if (entity.Title.Trim().Length == 0)
            {
                yield return new ValidationResult("Title", "Title is required.");
            }

            if (entity.ThumbUrl.Trim().Length == 0)
            {
                yield return new ValidationResult("Thumbnail", "Thumbnail for video is required.");
            }

            if (entity.YtId.Trim().Length == 0)
            {
                yield return new ValidationResult("YoutubeId", "Youtube ID is required.");
            }
        }
    }
}
