namespace VideoNotes.Service.Cotracts
{
    using System.Collections.Generic;
    using System.Linq;
    using VideoNotes.Core.Entities;
    using VideoNotes.DataAccess;

    public interface IVideoService
    {
        void AddVideo(Video video, string userId);

        Video DeleteVideoById(string videoId, string userId);

        string GetYtIdFor(int videoId);
    }
}
