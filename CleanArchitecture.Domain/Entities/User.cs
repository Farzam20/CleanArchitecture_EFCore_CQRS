namespace CleanArchitecture.Domain.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public string PasswordHash { get; set; }
        public string FullName { get; set; }
        public Guid SecurityStamp { get; set; }

        public ICollection<UserRole> UserRoles { get; set; }
    }
}
