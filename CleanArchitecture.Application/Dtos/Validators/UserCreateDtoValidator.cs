using FluentValidation;

namespace CleanArchitecture.Application.Dtos.Validators
{
    public class UserCreateDtoValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateDtoValidator()
        {
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("وارد کردن نام کاربری الزامی است")
                .NotNull()
                .WithMessage("وارد کردن نام کاربری الزامی است");

            RuleFor(x => x.FullName)
                .NotEmpty()
                .WithMessage("وارد کردن نام و نام خانوادگی الزامی است")
                .NotNull()
                .WithMessage("وارد کردن نام و نام خانوادگی الزامی است");

        }
    }
}