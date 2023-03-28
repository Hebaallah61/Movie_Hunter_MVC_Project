using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Movie_Hunter_FinalProject.Models;

namespace Movie_Hunter_FinalProject.Areas.Identity.Data;

// Add profile data for application users by adding properties to the SystemUser class
public class SystemUser : IdentityUser
{
    [Required(ErrorMessage = "Plesae enter First name")]
    [RegularExpression(@"^[A-Za-z]{1,15}$", ErrorMessage = "First Name should contain only alphabetical characters with maximum length of 15")]
    public string First_Name { get; set; }
    [Required(ErrorMessage = "Plesae enter last name")]
    [RegularExpression(@"^[A-Za-z]{1,15}$", ErrorMessage = "First Name should contain only alphabetical characters with maximum length of 15")]
    public string Last_Name { get; set; }

    [ForeignKey("LookUpValues")]
    public int PaymentMethod_Id { get; set; }

    [ForeignKey("LookUpValues")]
    public int Category_Id { get; set; }

    [ForeignKey("LookUpValues")]
    public int Plan_Id { get; set; }
    [Range(12,80,ErrorMessage ="Age should be between 12-80 years")]
    public int Age { get; set; }
    public virtual LookUpValues? lookUpValues { get; set; }


    public HashSet<UserMovies> userMovies { get; set; } = new HashSet<UserMovies>();
    public HashSet<UserSeries> userSeries { get; set; } = new HashSet<UserSeries>();
    public HashSet<UserEpisodes> userEpisodes  { get; set; } = new HashSet<UserEpisodes>();
}

