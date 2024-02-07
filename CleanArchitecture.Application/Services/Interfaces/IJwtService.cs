using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services.Interfaces
{
    public interface IJwtService
    {
        Task<string> Generate(User user);
    }
}
