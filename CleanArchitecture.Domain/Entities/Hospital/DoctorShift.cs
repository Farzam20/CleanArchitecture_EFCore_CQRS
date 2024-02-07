using CleanArchitecture.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities.Hospital
{
    public class DoctorShift : BaseEntity
    {
        public int DoctorId { get; set; }
        [ForeignKey(nameof(DoctorId))]
        public Doctor Doctor { get; set; }

        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public ShiftStatus Status { get; set; }
        public int Capacity { get; set; }
    }
}
