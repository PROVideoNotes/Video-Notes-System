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

    public class VideoService : IVideoService, IService
    {
        private IRepository<Video> videoRepository;
        private IValidationProvider validationProvider;
        private IRepository<Category> categoryRepository;

        public VideoService(IRepository<Video> videoRepository, IRepository<Category> categoryRepository, IValidationProvider validationProvider)
        {
            this.categoryRepository = categoryRepository;
            this.videoRepository = videoRepository;
            this.validationProvider = validationProvider;
        }

        public void AddVideo(Video video, string userId)
        {
            this.validationProvider.Validate(video);
            Category category = this.categoryRepository.GetById(video.CategoryId);
            if (category != null && category.ApplicationUserId == userId)
            {
                this.videoRepository.Insert(video);
                return;
            }
            else
            {
                throw new ValidationException(new List<ValidationResult>() { new ValidationResult("user", ValidationExceptionMessages.UserNotAuthenticated(userId, "add video", "0")) });
            }
        }

        public Video DeleteVideoById(string videoId, string userId)
        {
            int k = int.Parse(videoId);
            Video video = this.videoRepository.GetById(k);
            if (video != null)
            {
                Category category = this.categoryRepository.GetById(video.CategoryId);
                if (category.ApplicationUserId == userId)
                {
                    this.videoRepository.Delete(video);
                    return video;
                }
            }

            throw new ValidationException(new List<ValidationResult>() { new ValidationResult("user", ValidationExceptionMessages.UserNotAuthenticated(userId, "delete video", videoId)) });
        }

        public string GetYtIdFor(int videoId)
        {
            return this.videoRepository.GetById(videoId).YtId;
        }
    }
}
