namespace VideoNotes.Web.ViewModels
{
    using System.Collections;
    using System.Collections.Generic;
    using VideoNotes.Web.Infrastructure;
    using System.Web;
    using System.Linq.Expressions;
    using System;
    using System.Drawing;
    using VideoNotes.Core.Entities;
    using System.ComponentModel.DataAnnotations;

    public class VideoViewModel
    {   
        public string Title { get; set; }
        public string ThumbNail { get; set; }
        public int VideoId { get; set; }
        public string YtId { get; set; }
        public int CategoryId { get; set; }
    }

    public class CategoryViewModel
    {  
       public int CategoryId { get; set; }
        [Required]
        [MaxLength(200)]
        [Display(Name="Category name")]
       public string Name { get; set; }
    }
    public class NoteViewModel
    {
        public int NoteId { get; set; }
        public string Color { get; set; }
        [Required, MaxLength(300)]
        public string Content { get; set; }
        [Required]
        public decimal Time { get; set; }
        [Required, MaxLength(100)]
        public string Title { get; set; }
        public bool Share { get; set; }
        [Required]
        public int VideoId { get; set; }
    }
}