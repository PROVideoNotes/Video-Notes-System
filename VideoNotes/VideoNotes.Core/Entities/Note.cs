namespace VideoNotes.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Note
    {
        public Note()
        {
            this.Share = false;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int NoteId { get; set; }

        [Required, MaxLength(100)]
        public string Title { get; set; }

        [Required, MaxLength(300)]
        public string Content { get; set; }

        [Required]
        public decimal Time { get; set; }

        public string Color { get; set; }

        [ForeignKey("Video"), Required]
        public int VideoId { get; set; }

        public bool Share { get; set; }

        public virtual Video Video { get; set; }
    }
}