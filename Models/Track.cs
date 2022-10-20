using BugTrack.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrack.Models
{
    public class Track
    {
        [Key]
        public int TrackId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a category.")]
        public int BugCategoryId { get; set; }
        public BugCategory? Category { get; set; }



        [Column(TypeName = "nvarchar(75)")]
        [StringLength(75,ErrorMessage ="the note must be less than 75 characters")]
        public string? Note { get; set; }

        [Column(TypeName = "nvarchar(MAX)")]
        //[StringLength(7, ErrorMessage = "the note must be less than 75 characters")]
        public string? Description { get; set; }

        public DateTime Date { get; set; } = DateTime.Now;

        [NotMapped]
        public string? CategoryTitleWithIcon
        {
            get
            {
                return Category == null ? "" : Category.Icon + " " + Category.Title;
            }
        }


    }
}
