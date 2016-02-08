namespace VideoNotes.Service.Cotracts
{
    using System.Collections.Generic;
    using System.Linq;
    using VideoNotes.Core.Entities;

    public interface INoteService
    {
        IQueryable<Note> GetSharedNotesFor(string youTubeVideoId);

        void AddNote(Note note, string userId);

        IQueryable<Note> GetNotesFor(int videoId, string userId);

        IEnumerable<Note> GetSharedNotesForGivenVideoId(int videoId);

        void DeleteNote(Note note);

        void ShareNote(int noteId);

        void UnShareNote(int noteId);

        Note DeleteNoteById(string noteId, string userId);
    }
}
