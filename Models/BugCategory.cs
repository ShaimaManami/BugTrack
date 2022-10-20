using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BugTrack.Models
{
    public class BugCategory
    {
        [Key]
        public int BugCategoryId { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage ="Title is required!!")]
        public string Title { get; set; }
        [Column(TypeName = "nvarchar(5)")]
        public string Icon { get; set; } = "";
        [Column(TypeName = "nvarchar(10)")]
        public string Type { get; set; } = "Moderate";
        
        
        [NotMapped]
        public string? TitleWithIcon {
            get
            { 
                return this.Icon + " " + this.Title;
            }
        }

    }
}
