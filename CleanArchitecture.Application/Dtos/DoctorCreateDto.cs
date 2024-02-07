using CleanArchitecture.Domain.Entities.Hospital;
using CleanArchitecture.Domain.Enums;
using System.ComponentModel.DataAnnotations.Schema;

namespace CleanArchitecture.Application.Dtos
{
    public class DoctorCreateDto : BaseDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public Specialist Specialist { get; set; }
    }
}
