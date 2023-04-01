using Movie_Hunter_FinalProject.Models.CustomAnnotations;
using System.ComponentModel.DataAnnotations;

namespace Movie_Hunter_FinalProject.Models
{
    public class CreateRoleVM
    {
        public string? id { get; set; }
        [Required(ErrorMessage = "Enter Role Name")]
        [Capitalize(ErrorMessage ="First Letter Must be Capital and Rest Should be small (CA)")]
        public string RoleName { get; set; }
    }
}
