namespace CleanArchitecture.Application.Dtos
{
    public class PatientDisplayDto : BaseDto
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Mobile { get; set; }
        public string NationalCode { get; set; }
    }
}
