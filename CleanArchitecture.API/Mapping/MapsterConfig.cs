using CleanArchitecture.Application.Dtos;
using CleanArchitecture.Domain.Entities;
using CleanArchitecture.Domain.Entities.Hospital;
using Mapster;

namespace CleanArchitecture.API.Mapping
{
    public static class MapsterConfig
    {
        public static void RegisterMapsterConfiguration(this IServiceCollection services)
        {
            TypeAdapterConfig<Appointment, AppointmentDisplayDto>
                .NewConfig()
                .Map(destination => destination.PatientFirstName, source => source.Patient.FirstName)
                .Map(destination => destination.PatientLastName, source => source.Patient.LastName)
                .Map(destination => destination.PatientMobile, source => source.Patient.Mobile)
                .Map(destination => destination.PatientNationalCode, source => source.Patient.NationalCode)
                ;
        }
    }
}
