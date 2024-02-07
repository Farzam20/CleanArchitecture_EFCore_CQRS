using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Domain.Entities.Hospital
{
    public class Appointment : BaseEntity
    {
        public int PatientId { get; set; }
        [ForeignKey(nameof(PatientId))]
        public Patient Patient { get; set; }

        public int DoctorShiftId { get; set; }
        [ForeignKey(nameof(DoctorShiftId))]
        public DoctorShift DoctorShift { get; set; }

        public int VisitNumber { get; set; }
        public string TrackingCode { get; set; }
    }
}
