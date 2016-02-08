namespace VideoNotes.Web.Controllers
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using VideoNotes.Service.Cotracts;
    using VideoNotes.Web.ViewModels;
    using VideoNotes.Web.Infrastructure.ActionFilters;
    using System.Threading.Tasks;
    
    public class SearchController : Controller
    {
        private ISearchService searchService;
        private INoteService noteService;
        private IVideoService videoService;

        public SearchController(ISearchService searchService, INoteService noteService,IVideoService videoService)
        {
            this.searchService = searchService;
            this.noteService = noteService;
            this.videoService = videoService;
        }

        // GET: Search
        public ActionResult Home()
        {
            return View();
        }

        [LogExecutionTimeFilter]
        public ActionResult SearchBySharedNotes(string keywords)
        {
            ViewBag.IncludeVideoId = true;

            IEnumerable<NoteViewModel> listNotes = this.searchService.SearchBySharedNotes(keywords).Select(x => new NoteViewModel
            {
                Content = x.Content,
                Color = x.Color,
                Time = x.Time,
                Title = x.Title,
                VideoId = x.VideoId
            });
            return View("_Notes", listNotes);
        }

        public ActionResult SearchByUserNotes(string keywords)
        {
            ViewBag.IncludeVideoId = true;

            IEnumerable<NoteViewModel> listNotes = this.searchService.SearchByUserNotes(keywords, User.Identity.GetUserId()).Select(x => new NoteViewModel
            {
                Content = x.Content,
                Color = x.Color,
                Time = x.Time,
                Title = x.Title,
                VideoId = x.VideoId
            });
            return View("_Notes", listNotes);
        }

        public ActionResult SearchByAllVideoTitles(string keywords)
        {
            IEnumerable<VideoViewModel> listVideos = this.searchService.SearchByAllVideoTitles(keywords).Select(x => new VideoViewModel
            {
                ThumbNail = x.ThumbUrl,
                Title = x.Title,
                VideoId = x.VideoId,
                YtId = x.YtId,
            });
            return View("_Videos", listVideos);
        }

        public ActionResult SearchByUserVideoTitles(string keywords)
        {
            IEnumerable<VideoViewModel> listVideos = this.searchService.SearchByUserVideoTitles(keywords, User.Identity.GetUserId()).Select(x => new VideoViewModel
            {
                ThumbNail = x.ThumbUrl,
                Title = x.Title,
                VideoId = x.VideoId,
                YtId = x.YtId,
            });
            return View("_Videos", listVideos);
        }

        public ActionResult SearchByYoutubeId(string id)
        {
            IEnumerable<VideoViewModel> listVideos = this.searchService.SearchByYoutubeId(id).Select(x => new VideoViewModel
            {
                ThumbNail = x.ThumbUrl,
                Title = x.Title,
                VideoId = x.VideoId,
                YtId = x.YtId,
            });
            return View("_Videos", listVideos);
        }

        public ActionResult GetSharedNotesFor(int videoId)
        {
            IEnumerable<NoteViewModel> listNotes = this.noteService.GetSharedNotesForGivenVideoId(videoId).Select(x => new NoteViewModel
            {
                Content = x.Content,
                Time = x.Time,
                Title = x.Title,
                VideoId = x.VideoId
            });
            return View("_Notes", listNotes);
        }

        public async Task<ActionResult> GetYtIdFor(int videoId)
        {
            string result = this.videoService.GetYtIdFor(videoId);

            return Json(new { Data = result }, JsonRequestBehavior.AllowGet);
        }
    }
}