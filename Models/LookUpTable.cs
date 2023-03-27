using System.ComponentModel.DataAnnotations;

namespace Movie_Hunter_FinalProject.Models
{
    public class LookUpTable
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter look up name")]
        [RegularExpression(@"^[A-Za-z]{1,15}$", ErrorMessage = "Look up Name should contain only alphabetical characters with maximum length of 15")]
        public string LookUpName { get; set; }

        public HashSet<LookUpValues> lookUpValues { get; set; } = new HashSet<LookUpValues>();
    }
}
