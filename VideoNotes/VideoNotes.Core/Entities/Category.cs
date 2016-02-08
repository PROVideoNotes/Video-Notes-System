namespace VideoNotes.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Category
    {
        public Category()
        {
            this.Videos = new HashSet<Video>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CategoryId { get; set; }

        [Required, MaxLength(150)]
        public string Name { get; set; }

        [Required, ForeignKey("ApplicationUser")]
        public string ApplicationUserId { get; set; }

        public virtual ICollection<Video> Videos { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
