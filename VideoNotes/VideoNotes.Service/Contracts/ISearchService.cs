namespace VideoNotes.Service.Cotracts
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using VideoNotes.Core.Entities;

    public interface ISearchService
    {
        IEnumerable<Video> SearchByUserVideoTitles(string keywords, string userId);

        IEnumerable<Video> SearchByAllVideoTitles(string keywords);

        IEnumerable<Note> SearchByUserNotes(string keywords, string userId);

        IEnumerable<Note> SearchBySharedNotes(string keywords);

        IEnumerable<Video> SearchByYoutubeId(string id);
    }
}
