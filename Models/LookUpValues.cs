using Movie_Hunter_FinalProject.Areas.Identity.Data;
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

        
        public int lookupId { get; set; }

        [ForeignKey("lookupId")]
        public virtual LookUpTable lookUpTable { get; set; }

        public virtual HashSet<SystemUser> Users { get; set; } = new HashSet<SystemUser>();
    }
}
