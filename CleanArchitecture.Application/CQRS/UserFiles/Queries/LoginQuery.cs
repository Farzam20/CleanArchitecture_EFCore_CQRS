using MediatR;

namespace CleanArchitecture.Application.CQRS.UserFiles.Queries
{
    public class LoginQuery : IRequest<HandlerResponse<string>>
    {
        public string UserName { get; }
        public string Password { get; }

        public LoginQuery(string userName, string password)
        {
            UserName = userName;
            Password = password;
        }
    }
}
