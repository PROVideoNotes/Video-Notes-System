namespace VideoNotes.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VideoNotes.Core.Entities;
    using VideoNotes.DataAccess;
    using VideoNotes.Service.Cotracts;
    using VideoNotes.Validation.Common;
    using VideoNotes.Validation.Common.Helpers;

    public class SearchService : ISearchService, IService
    {
        private IRepository<Category> categoryRepository;
        private IRepository<Note> noteRepository;
        private IRepository<Video> videoRepository;

        public SearchService(
            IRepository<Category> categoryRepository,
            IRepository<Note> noteRepository,
            IRepository<Video> videoRepository)
        {
            this.categoryRepository = categoryRepository;
            this.noteRepository = noteRepository;
            this.videoRepository = videoRepository;
        }

        public IEnumerable<Video> SearchByUserVideoTitles(string keywords, string userId)
        {
            if ((!string.IsNullOrEmpty(keywords)) && (!string.IsNullOrEmpty(keywords.Trim())))
            {
                string keywordsToLower = keywords.ToLower();
                IEnumerable<Video> searchResult = this.
                    videoRepository.
                    Table.
                    Where(
                    video => (
                        video.
                        Title.
                        Contains(keywordsToLower)) &&
                        (video.Category.ApplicationUserId == userId)).
                        Take(50).
                        ToList<Video>();
                return searchResult;
            }

            throw new ValidationException(new List<ValidationResult>() 
                {
                    new ValidationResult("search", ValidationExceptionMessages.SearchKeyWordsIncorrect(keywords))
                });
        }

        public IEnumerable<Video> SearchByAllVideoTitles(string keywords)
        {
            if (
                (!string.IsNullOrEmpty(keywords)) &&
                (!string.IsNullOrEmpty(keywords.Trim())))
            {
                string keywordsToLower = keywords.ToLower();
                IEnumerable<Video> searchResult = this.videoRepository.Table.Where(video => video.Title.ToLower().Contains(keywordsToLower)).Take(50).ToList<Video>();
                return searchResult;
            }

            throw new ValidationException(new List<ValidationResult>() 
                {
                    new ValidationResult("search", ValidationExceptionMessages.SearchKeyWordsIncorrect(keywords))
                });
        }

        public IEnumerable<Note> SearchByUserNotes(string keywords, string userId)
        {
            if ((!string.IsNullOrEmpty(keywords)) && (!string.IsNullOrEmpty(keywords.Trim())))
            {
                string keywordsToLower = keywords.ToLower();
                IEnumerable<Note> searchResult = this.noteRepository.Table.Where(note =>
                    (note.Title.ToLower().Contains(keywordsToLower) ||
                    note.Content.ToLower().Contains(keywordsToLower)) &&
                    (note.Video.Category.ApplicationUserId == userId)).Take(50).ToList<Note>();
                return searchResult;
            }

            throw new ValidationException(new List<ValidationResult>() 
                {
                    new ValidationResult("search", ValidationExceptionMessages.SearchKeyWordsIncorrect(keywords))
                });
        }

        public IEnumerable<Note> SearchBySharedNotes(string keywords)
        {
            if ((!string.IsNullOrEmpty(keywords)) && (!string.IsNullOrEmpty(keywords.Trim())))
            {
                string keywordsToLower = keywords.ToLower();
                IEnumerable<Note> searchResult = this.noteRepository.Table.Where(note => note.Share.Equals(true) &&
                    (note.Title.ToLower().Contains(keywordsToLower) ||
                    note.Content.ToLower().Contains(keywordsToLower))).Take(50).ToList<Note>();
                return searchResult;
            }

            throw new ValidationException(new List<ValidationResult>() 
                {
                    new ValidationResult("search", ValidationExceptionMessages.SearchKeyWordsIncorrect(keywords))
                });
        }

        public IEnumerable<Video> SearchByYoutubeId(string id)
        {
            if ((!string.IsNullOrEmpty(id)) && (!string.IsNullOrEmpty(id.Trim())))
            {
                string idToLower = id.ToLower();
                IEnumerable<Video> searchResult = this.videoRepository.Table.Where(video => video.YtId.ToLower().Contains(idToLower)).Take(50).ToList<Video>();
                return searchResult;
            }

            throw new ValidationException(new List<ValidationResult>() 
                {
                    new ValidationResult("search", ValidationExceptionMessages.SearchKeyWordsIncorrect(id))
                });
        }

        
    }
}
