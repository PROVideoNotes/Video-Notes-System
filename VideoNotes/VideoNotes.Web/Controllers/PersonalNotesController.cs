namespace VideoNotes.Web.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.Owin;
    using Microsoft.Owin.Security;
    using VideoNotes.Core.Entities;
    using VideoNotes.DataAccess;
    using VideoNotes.Service.Cotracts;
    using VideoNotes.Validation.Common.Helpers;
    using VideoNotes.Web.Infrastructure.ActionFilters;
    using VideoNotes.Web.Infrastructure.ValidationExtensions;
    using VideoNotes.Web.ViewModels;

    public class PersonalNotesController : Controller
    {
        private ICategoryService categoryService;
        private INoteService noteService;
        private IVideoService videoService;

        public PersonalNotesController(
            ICategoryService categoryService,
            INoteService noteService,
            IVideoService videoService)
        {
            this.categoryService = categoryService;
            this.noteService = noteService;
            this.videoService = videoService;
        }

        /// GET: User
        [Authorize]
        [HttpGet]
        public ActionResult Home()
        {
            IEnumerable<CategoryViewModel> listCategories = this.categoryService.GetCategoriesForUser(User.Identity.GetUserId()).Select(x => new CategoryViewModel
            {
                Name = x.Name,
                CategoryId = x.CategoryId
            });
            return View("Home", listCategories);
        }

        [Authorize]
        [HttpGet]
        [AjaxOnly]
        [BindModelStateErrorsInJSON]
        public ActionResult GetVideos(string categoryId)
        {
            int catId = int.Parse(categoryId);
            IEnumerable<VideoViewModel> videos = this.categoryService.GetCategoriesForUser(User.Identity.GetUserId()).Where(x => x.CategoryId == catId).FirstOrDefault().Videos.Select(y => new VideoViewModel
            {
                ThumbNail = y.ThumbUrl,
                Title = y.Title,
                VideoId = y.VideoId,
                YtId = y.YtId,
                CategoryId = y.CategoryId
            });

            return View("_VideosWindow", videos);
        }

        [Authorize]
        [HttpPost]
        [AjaxOnly]
        [BindModelStateErrorsInJSON]
        [ValidateAntiForgeryToken]
        public ActionResult AddVideo([Bind(Exclude = "VideoId")]VideoViewModel video)
        {
            string userId = User.Identity.GetUserId();
            Video videoEntity = new Video { YtId = video.YtId, Title = video.Title, ThumbUrl = video.ThumbNail, CategoryId = video.CategoryId };
            try
            {
                this.videoService.AddVideo(videoEntity, userId);
            }
            catch (ValidationException ex)
            {
                ExceptionBindingInMS.AddModelErrors(this.ModelState, ex);
                return View("_VideosWindow");
            }

            return this.GetVideos(videoEntity.CategoryId.ToString());
        }

        [Authorize]
        [AjaxOnly]
        [BindModelStateErrorsInJSON]
        [HttpDelete]
        public ActionResult DeleteVideo(string videoId)
        {
            Video k = null;
            string userId = User.Identity.GetUserId();
            try
            {
                k = videoService.DeleteVideoById(videoId, userId);
            }
            catch (ValidationException ex)
            {
                ExceptionBindingInMS.AddModelErrors(this.ModelState, ex);
                throw new HttpException(400, "Bad Request");
            }

            return this.GetVideos(k.CategoryId.ToString());
        }

        //  User/AddCategory   POST
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        [AjaxOnly]
        [BindModelStateErrorsInJSON]
        public ActionResult AddCategory([Bind(Exclude = "CategoryId")] CategoryViewModel category)
        {
            string userId = User.Identity.GetUserId();
            Category categoryEntity = new Category { Name = category.Name, ApplicationUserId = userId };
            try
            {
                this.categoryService.AddCategory(categoryEntity);
            }
            catch (ValidationException ex)
            {
                ExceptionBindingInMS.AddModelErrors(this.ModelState, ex);
                return View("_CategoryList");
            }


            category.CategoryId = categoryEntity.CategoryId;


            return PartialView("_Category", category);
        }

        // User/DeleteCategory
        [HttpGet]
        [Authorize]
        [AjaxOnly]
        [BindModelStateErrorsInJSON]
        public ActionResult DeleteCategory(string categoryId)
        {
            string userID = User.Identity.GetUserId();
            try
            {
                this.categoryService.DeleteCategoryById(categoryId, userID);
            }
            catch (ValidationException ex)
            {
                ExceptionBindingInMS.AddModelErrors(this.ModelState, ex);
                return PartialView("_CategoryList");
            }

            return this.GetAllCategories();
        }

        [Authorize]
        [HttpGet]
        [AjaxOnly]
        [BindModelStateErrorsInJSON]
        public ActionResult GetNotes(int videoId)
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<NoteViewModel> notes = this.
                noteService.
                GetNotesFor(videoId, userId).
                Select(y => new NoteViewModel
            {
                NoteId = y.NoteId,
                Color = y.Color,
                Content = y.Content,
                Time = y.Time,
                Title = y.Title,
                VideoId = y.VideoId,
                Share = y.Share
            }).ToList<NoteViewModel>();
            return View("_Notes", notes);
        }

        [HttpPost]
        [Authorize]
        [AjaxOnly]
        [BindModelStateErrorsInJSON]
        [ValidateAntiForgeryToken]
        public ActionResult AddNote(NoteViewModel note)
        {
            int videoId = note.VideoId;
            decimal time = note.Time;
            string userId = User.Identity.GetUserId();
            Note n = new Note
            {
                //Color = note.Color,
                Content = note.Content,
                Share = note.Share,
                Time = time,
                Title = note.Title,
                VideoId = videoId
            };
            try
            {
                this.noteService.AddNote(n, userId);
            }
            catch (ValidationException ex)
            {
                ExceptionBindingInMS.AddModelErrors(this.ModelState, ex);
                return PartialView("_Notes");
            }

            return this.GetNotes(note.VideoId);
        }

        [HttpDelete]
        [Authorize]
        [AjaxOnly]
        [BindModelStateErrorsInJSON]
        public ActionResult DeleteNote(string noteId)
        {
            string userId = User.Identity.GetUserId();
            Note note;
            try
            {
                note = this.noteService.DeleteNoteById(noteId, userId);
            }
            catch (ValidationException ex)
            {
                ExceptionBindingInMS.AddModelErrors(this.ModelState, ex);
                return PartialView("_Notes");
            }

            return this.GetNotes(note.VideoId);
        }

        [NonAction]
        private ActionResult GetAllCategories()
        {
            string userId = User.Identity.GetUserId();
            IEnumerable<CategoryViewModel> listCategories = this.categoryService.GetCategoriesForUser(userId).Select(x => new CategoryViewModel
            {
                Name = x.Name,
                CategoryId = x.CategoryId
            });
            return PartialView("_CategoryList", listCategories);
        }
    }
}