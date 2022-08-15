namespace DotnetRestApi.WebApi.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class UserLoginRequestDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
