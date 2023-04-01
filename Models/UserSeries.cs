using Movie_Hunter_FinalProject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movie_Hunter_FinalProject.Models
{
    public class UserSeries
    {
        [Key]
        public int id { get; set; }


        public int? Rating { get; set; }

        public bool? AddToFavorite { get; set; } = false; 

        public string? Review { get; set; }


        public bool? Watched { get; set; }

        
        public int SeriesId { get; set; }

        [ForeignKey("SeriesId")]
        public virtual Series? series { get; set; }

        
        public string user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual SystemUser? systemUser { get; set; }
    }
}
