using FluentValidation;

namespace Sat.Recruitment.ApiAuth
{
    /// <summary>
    /// Use to validate UserRequest class with fluentValidations
    /// </summary>
    public class UserInfoRequestValidate : AbstractValidator<UserInfoRequest>
    {
  
        public UserInfoRequestValidate()
        {

            // Check Password is not null, empty 
            RuleFor(user => user.Password).NotNull().NotEmpty().WithMessage("The Password is required");
            // Check Email is not null, empty and valid format 
            RuleFor(user => user.Email).NotNull().NotEmpty().WithMessage("The Email is required");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Invalid Email format");
        
        
        }

    }
}

