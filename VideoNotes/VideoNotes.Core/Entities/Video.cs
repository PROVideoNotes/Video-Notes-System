namespace VideoNotes.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Video
    {
        public Video()
        {
            this.Notes = new HashSet<Note>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int VideoId { get; set; }

        [Required]
        public string YtId { get; set; }

        [Url, Required]
        public string ThumbUrl { get; set; }

        [Required, MaxLength(200)]
        public string Title { get; set; }

        [ForeignKey("Category"), Required]
        public int CategoryId { get; set; }

        public virtual ICollection<Note> Notes { get; set; }

        public virtual Category Category { get; set; }
    }
}