

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Hunter_FinalProject.Models
{
    public class Series:ShowAbstract
    {
        [Required(ErrorMessage ="Please specify how many season does this show have")]
        public int NumberOfSeasons { get; set; }

        public HashSet<UserSeries> userSeries { get; set; } = new HashSet<UserSeries>();
    }
}
