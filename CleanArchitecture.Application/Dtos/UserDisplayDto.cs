namespace CleanArchitecture.Application.Dtos
{
    public class UserDisplayDto : BaseDto
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
    }
}
