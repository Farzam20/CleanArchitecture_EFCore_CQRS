using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Domain.Entities.Hospital
{
    public class Doctor : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Specialist Specialist { get; set; }
    }
}
