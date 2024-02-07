using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities.Hospital;
using CleanArchitecture.Domain.Utilities;
using FluentValidation;
using System.Text.RegularExpressions;

namespace CleanArchitecture.Application.Dtos.Validators
{
    public class AppointmentCreateDtoValidator : AbstractValidator<AppointmentCreateDto>
    {
        private readonly IBaseService<Appointment> _appointmentService;
        private readonly IBaseService<Patient> _patientService;
        private readonly IBaseService<DoctorShift> _doctorShiftService;

        public AppointmentCreateDtoValidator(IBaseService<Patient> patientService, IBaseService<Appointment> appointmentService, IBaseService<DoctorShift> doctorShiftService)
        {
            this._patientService = patientService;
            this._appointmentService = appointmentService;
            this._doctorShiftService = doctorShiftService;

            RuleFor(x => x.DoctorShiftId)
                .NotNull()
                .WithMessage("انتخاب شیفت الزامی است")
                .NotEmpty()
                .WithMessage("انتخاب شیفت الزامی است")
                .Must((obj, doctorShiftId) =>
                {
                    var appointment = _appointmentService.FirstOrDefault(x => x.Patient.NationalCode == obj.NationalCode && x.DoctorShiftId == doctorShiftId && x.Id != obj.Id);
                    return appointment == null;
                })
                .WithMessage("نوبت شما قبلا برای این پزشک ثبت شده است")
                .Must((obj, doctorShiftId) =>
                {
                    var shift = _doctorShiftService.FirstOrDefault(x => x.Id == doctorShiftId);
                    return shift != null;
                })
                .WithMessage("شیفت انتخاب شده معتبر نمی باشد")
                ;

            RuleFor(x => x.FirstName)
                .NotNull()
                .WithMessage("وارد کردن نام الزامی است")
                .NotEmpty()
                .WithMessage("وارد کردن نام الزامی است");

            RuleFor(x => x.LastName)
                .NotNull()
                .WithMessage("وارد کردن نام خانوادگی الزامی است")
                .NotEmpty()
                .WithMessage("وارد کردن نام خانوادگی الزامی است");

            RuleFor(x => x.PatientId)
                .Must((obj, patientId) =>
                {
                    if (!patientId.HasValue)
                        return true;

                    var patient = _patientService.FirstOrDefault(x => x.Id == patientId.Value && x.NationalCode == obj.NationalCode);
                    return patient != null;
                })
                .WithMessage("اطلاعات بیمار صحیح نمی باشد");

            RuleFor(x => x.NationalCode)
                .NotNull()
                .WithMessage("وارد کردن کدملی الزامی است")
                .NotEmpty()
                .WithMessage("وارد کردن کدملی الزامی است")
                .Must((obj, nationalCode) =>
                {
                    return nationalCode.NationalCodeValidator();
                })
                .WithMessage("کدملی وارد شده صحیح نمی باشد")
                ;

            RuleFor(x => x.Mobile)
                .NotNull()
                .WithMessage("وارد کردن موبایل الزامی است")
                .NotEmpty()
                .WithMessage("وارد کردن موبایل الزامی است")
                .Matches(new Regex("^(\\+98|0)?9\\d{9}$"))
                .WithMessage("شماره تماس وارد شده معتبر نمی باشد");
        }
    }
}