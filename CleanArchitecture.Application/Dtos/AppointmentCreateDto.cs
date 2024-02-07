namespace CleanArchitecture.Application.Dtos
{
    public class AppointmentCreateDto : BaseDto 
    {
        public int? PatientId { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Mobile { get; set; }
        public string? NationalCode { get; set; }

        public int DoctorShiftId { get; set; }
    }
}
