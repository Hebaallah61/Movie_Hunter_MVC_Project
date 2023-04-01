using Movie_Hunter_FinalProject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movie_Hunter_FinalProject.Models
{
    public class UserEpisodes
    {
        [Key]
        public int id { get; set; }


        public int? Rating { get; set; }

        public bool? AddToFavorite { get; set; } = false; 

        public string? Review { get; set; }


        public bool? Watched { get; set; }

        
        public int EpisodeId { get; set; }

        [ForeignKey("EpisodeId")]
        public virtual Episodes? episodes { get; set; }

        
        public string user_id { get; set; }

        [ForeignKey("user_id")]
        public virtual SystemUser? systemUser { get; set; }
    }
}
