namespace DotnetRestApi.WebApi.DTOs
{
    using System.Collections.Generic;

    public class UserLoginResponseDTO
    {
        public string Token { get; set; }
        public bool Login { get; set; }
        public List<string> Errors { get; set; }
    }
}
