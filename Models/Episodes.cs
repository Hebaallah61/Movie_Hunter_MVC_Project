using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Hunter_FinalProject.Models
{
    public class Episodes
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter the Episode Path")]
        public string Episode_Path { get; set; }

        [Required(ErrorMessage ="Please enter the duration ")]

        public double duration { get; set; }

        public string Title { get; set; }

        public int season { get; set; }

        
        public int series_id { get; set; }

        [ForeignKey("series_id")]
        public virtual Series? series { get; set; }


        public virtual HashSet<UserEpisodes> userEpisodes { get; set; } = new HashSet<UserEpisodes>();
    }
}
