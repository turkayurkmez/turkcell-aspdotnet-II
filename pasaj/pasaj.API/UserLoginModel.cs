using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace pasaj.API
{
    public class UserLoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [HiddenInput]
        public string? ReturnUrl { get; set; }


    }
}
