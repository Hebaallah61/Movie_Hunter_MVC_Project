using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Movie_Hunter_FinalProject.Models
{
    public class LookUpValues
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage ="Please enter the look up value")]
        public string Value { get; set; }

        [ForeignKey("LookUpTable")]
        public int lookupId { get; set; }

        public virtual LookUpTable lookUpTable { get; set; }
    }
}
