using System.ComponentModel.DataAnnotations;

namespace Movie_Hunter_FinalProject.Models
{
    public class CreateRoleVM
    {
        public string? id { get; set; }
        [Required(ErrorMessage = "Enter Role Name")]
        public string RoleName { get; set; }
    }
}
