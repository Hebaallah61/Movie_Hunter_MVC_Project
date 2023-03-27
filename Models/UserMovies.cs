using Microsoft.AspNetCore.Mvc.RazorPages.Infrastructure;
using Movie_Hunter_FinalProject.Areas.Identity.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Hunter_FinalProject.Models
{
    public class UserMovies
    {
        [Key]
        public int id { get; set; }

        
        public int Rating { get; set; }

        public bool AddToFavorite { get; set; }

        public string Review { get; set; }


        public bool Watched { get; set; }

        [ForeignKey("Movies")]
        public int MovieId { get; set; }

        public virtual Movies movies { get; set; }

        [ForeignKey("SystemUser")]
        public string user_id { get; set; }

        public virtual SystemUser systemUser { get; set; }
    }
}
