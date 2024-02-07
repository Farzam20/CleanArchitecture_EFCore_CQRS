using CleanArchitecture.Application.Repositories;
using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities;

namespace CleanArchitecture.Application.Services.Implementations
{
    public class UserService : BaseService<User>, IUserService
    {
        private readonly IBaseRepository<User> _repository;

        public UserService(IBaseRepository<User> repository) : base(repository)
        {
            this._repository = repository;
        }
    }
}
