using CleanArchitecture.Application.Services.Interfaces;
using CleanArchitecture.Domain.Entities.Hospital;
using CleanArchitecture.Domain.Enums;
using FluentValidation;

namespace CleanArchitecture.Application.Dtos.Validators
{
    public class DoctorShiftCreateDtoValidator : AbstractValidator<DoctorShiftCreateDto>
    {
        private readonly IBaseService<DoctorShift> _service;

        public DoctorShiftCreateDtoValidator(IBaseService<DoctorShift> service)
        {
            _service = service;

            RuleFor(x => x.DoctorId)
                .NotNull()
                .WithMessage("انتخاب پزشک الزامی است")
                .NotEmpty()
                .WithMessage("انتخاب پزشک الزامی است")
                .Must((obj, doctorId) =>
                {
                    return !(_service.GetAll(x => x.Id != obj.Id && 
                                                  x.DoctorId == doctorId &&
                                                  x.Status != ShiftStatus.Canceled &&
                                                  x.EndTime >= obj.StartTime && 
                                                  x.StartTime <= obj.EndTime).Any());
                })
                .WithMessage("بازه زمانی وارد شده با سایر شیفت های پزشک تداخل دارد")
                ;

            RuleFor(x => x.StartTime)
                .NotNull()
                .WithMessage("وارد کردن ساعت شروع شیفت الزامی است")
                .NotEmpty()
                .WithMessage("وارد کردن ساعت شروع شیفت الزامی است");

            RuleFor(x => x.EndTime)
                .NotNull()
                .WithMessage("وارد کردن ساعت پایان شیفت الزامی است")
                .NotEmpty()
                .WithMessage("وارد کردن ساعت پایان شیفت الزامی است");

            RuleFor(x => x.Capacity)
                .NotNull()
                .WithMessage("وارد کردن ظرفیت ویزیت الزامی است")
                .NotEmpty()
                .WithMessage("وارد کردن ظرفیت ویزیت الزامی است");
        }
    }
}