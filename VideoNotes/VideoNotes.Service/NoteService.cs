namespace VideoNotes.Service
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using VideoNotes.Core.Entities;
    using VideoNotes.DataAccess;
    using VideoNotes.DataAccess;
    using VideoNotes.Service.Cotracts;
    using VideoNotes.Validation.Common;
    using VideoNotes.Validation.Common.Helpers;

    public class NoteService : INoteService, IService
    {
        private IRepository<Note> noteRepository;
        private IValidationProvider validationProvider;
        private IRepository<Category> categoryRepository;
        private IRepository<Video> videoRepository;

        public NoteService(IRepository<Note> noteRepository, IRepository<Category> categoryRepository, IRepository<Video> videoRepository, IValidationProvider validationProvider)
        {
            this.noteRepository = noteRepository;
            this.categoryRepository = categoryRepository;
            this.validationProvider = validationProvider;
            this.videoRepository = videoRepository;
        }

        public void AddNote(Note note, string userId)
        {
            this.validationProvider.Validate(note);

            Video video = this.videoRepository.Table.Where(
                x => (x.VideoId == note.VideoId) &&
                    (x.Category.ApplicationUserId == userId)).FirstOrDefault();

            if (video != null)
            {
                this.noteRepository.Insert(note);
                return;
            }

            throw new ValidationException(
                new List<ValidationResult>() 
                {
                    new ValidationResult(
                        "user",
                        ValidationExceptionMessages.UserNotAuthenticated(
                        userId,
                        "add note", 
                        note.VideoId.ToString())) 
                });
        }

        public IQueryable<Note> GetSharedNotesFor(string youTubeVideoId)
        {
            return this.noteRepository.Table.Where(x => x.Share).Where(y => y.Video.YtId == youTubeVideoId);
        }

        public IQueryable<Note> GetNotesFor(int videoId, string userId)
        {
            Video video = this.videoRepository.GetById(videoId);
            if (video != null)
            {
                Category category = this.categoryRepository.GetById(video.CategoryId);

                if (category.ApplicationUserId == userId)
                {
                    return this.noteRepository.Table.Where(x => x.VideoId == videoId);
                }
            }

            throw new ValidationException(new List<ValidationResult>() { new ValidationResult("user", ValidationExceptionMessages.UserNotAuthenticated(userId, "get notes", videoId.ToString())) });
        }

        public IEnumerable<Note> GetSharedNotesForGivenVideoId(int videoId)
        {
            return this.noteRepository.Table.Where(x => (x.VideoId == videoId) && x.Share).ToList();
        }

        public void DeleteNote(Note note)
        {
            this.noteRepository.Delete(note);
        }

        public Note DeleteNoteById(string noteId, string userId)
        {
            int k = int.Parse(noteId);

            Note note = this.noteRepository.GetById(k);
            if (note != null)
            {
                Video video = this.videoRepository.GetById(note.VideoId);
                Category category = this.categoryRepository.GetById(video.CategoryId);
                if (category.ApplicationUserId == userId)
                {
                    this.noteRepository.Delete(note);
                    return note;
                }
            }

            throw new ValidationException(new List<ValidationResult>() { new ValidationResult("user", ValidationExceptionMessages.UserNotAuthenticated(userId, "delete note", noteId)) });
        }

        public void ShareNote(int noteId)
        {
            Note k = this.noteRepository.GetById(noteId);
            k.Share = true;
            this.noteRepository.Update(k);
        }

        public void UnShareNote(int noteId)
        {
            Note k = this.noteRepository.GetById(noteId);
            k.Share = false;
            this.noteRepository.Update(k);
        }
    }
}
