namespace CleanArchitecture.Application.Dtos
{
    public class UserCreateDto : BaseDto
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
    }
}