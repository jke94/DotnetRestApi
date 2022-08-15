namespace DotnetRestApi.WebApi.Configuration
{
    using DotnetRestApi.Abstractions;

    public class TokenParameters : ITokenParameters
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string Id { get; set; }
    }
}
