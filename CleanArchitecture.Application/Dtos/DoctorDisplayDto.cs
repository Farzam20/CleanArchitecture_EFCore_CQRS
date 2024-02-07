using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Dtos
{
    public class DoctorDisplayDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Specialist Specialist { get; set; }
    }
}
