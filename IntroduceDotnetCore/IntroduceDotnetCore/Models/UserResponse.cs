using System.ComponentModel.DataAnnotations;

namespace IntroduceDotnetCore.Models
{
    public class UserResponse
    {
        [Required(ErrorMessage = "Lütfen adınızı giriniz :)")]
        public string Name { get; set; }
        [EmailAddress(ErrorMessage = "Eposta formatı yanlış!")]
        public string Email { get; set; }
        public bool? IsComing { get; set; }
        public string? Code { get; set; }
    }
}
