using FluentValidation;

namespace CleanArchitecture.Application.Dtos.Validators
{
    public class DoctorCreateDtoValidator : AbstractValidator<DoctorCreateDto>
    {
        public DoctorCreateDtoValidator()
        {
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
        }
    }
}