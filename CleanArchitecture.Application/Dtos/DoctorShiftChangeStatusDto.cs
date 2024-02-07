using CleanArchitecture.Domain.Enums;

namespace CleanArchitecture.Application.Dtos
{
    public class DoctorShiftChangeStatusDto : BaseDto
    {
        public ShiftStatus Status { get; set; }
    }
}
