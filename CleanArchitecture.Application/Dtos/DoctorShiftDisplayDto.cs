using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Dtos
{
    public class DoctorShiftDisplayDto : BaseDto
    {
        public int DoctorId { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ShiftStatus Status { get; set; }
        public int Capacity { get; set; }
    }
}
