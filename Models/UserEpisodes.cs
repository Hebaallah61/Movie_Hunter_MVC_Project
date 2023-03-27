using Movie_Hunter_FinalProject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Movie_Hunter_FinalProject.Models
{
    public class UserEpisodes
    {
        [Key]
        public int id { get; set; }


        public int Rating { get; set; }

        public bool AddToFavorite { get; set; }

        public string Review { get; set; }


        public bool Watched { get; set; }

        [ForeignKey("Episodes")]
        public int EpisodeId { get; set; }

        public virtual Episodes episodes { get; set; }

        [ForeignKey("SystemUser")]
        public string user_id { get; set; }

        public virtual SystemUser systemUser { get; set; }
    }
}
