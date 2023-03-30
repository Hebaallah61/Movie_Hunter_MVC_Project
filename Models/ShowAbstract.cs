using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Hunter_FinalProject.Models
{
    public abstract class ShowAbstract
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage ="Name is required")]
        public string Name { get; set; }

        [Required(ErrorMessage ="Please enter the path of your show Image")]
        public string Thumbnail_Path { get; set; }

        [Range(0,5,ErrorMessage ="Rating should be between 0,5")]
        public int Rating { get; set; }

        [Required(ErrorMessage ="Plesae enter desscription for your show")]
        public string Description { get; set; }

        
        public int Category_Id { get; set; }

        public string Trailer_Path { get; set; }

        [ForeignKey("Category_Id")]
        public virtual LookUpValues? lookUpValues { get; set; }



    }
}
