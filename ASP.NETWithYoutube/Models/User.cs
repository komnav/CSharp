using System.ComponentModel.DataAnnotations;

namespace ASP.NETWithYoutube.Models;

[Serializable]
public class User
{
    [Required(ErrorMessage = "Enter name")]
    [MinLength(2, ErrorMessage = "Minimum length of name 2")]
    [MaxLength(60, ErrorMessage = "Maximum length of name 20")]
    public required string Name { get; set; }

    public int Age { get; set; }
}