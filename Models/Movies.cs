using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Hunter_FinalProject.Models
{
    public class Movies:ShowAbstract
    {
        [Required(ErrorMessage ="Please enter the duration of your Movie")]
        public int Duration { get; set; }

        [Required(ErrorMessage ="Please add your movie phyiscal path")]
        public string  Movie_Path { get; set; }

        public HashSet<UserMovies> userMovies { get; set; } = new HashSet<UserMovies>();
    }
}
