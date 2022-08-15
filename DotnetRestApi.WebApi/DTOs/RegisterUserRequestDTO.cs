namespace DotnetRestApi.WebApi.DTOs
{
    using System.ComponentModel.DataAnnotations;

    public class RegisterUserRequestDTO
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
    }
}
