namespace CleanArchitecture.Application.Dtos
{
    public class AppointmentDisplayDto : BaseDto 
    {
        public int? PatientId { get; set; }
        public string PatientFirstName { get; set; }
        public string PatientLastName { get; set; }
        public string PatientMobile { get; set; }
        public string PatientNationalCode { get; set; }

        public int DoctorShiftId { get; set; }

        public int VisitNumber { get; set; }
        public string TrackingCode { get; set; }
    }
}
