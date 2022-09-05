using FluentValidation;
using FluentValidation.Results;
using Sat.Recruitment.Model.Request;
using System;
using System.Text;

namespace Sat.Recruitment.Service.Validations
{
    public  class UserRequestValidate : AbstractValidator<UserRequest>
    {
  
        public UserRequestValidate()
        {
           
            // Check name is not null, empty 
            RuleFor(user => user.Name).NotNull().NotEmpty().WithMessage("The Name is required");
            // Check Phone is not null, empty 
            RuleFor(user => user.Phone).NotNull().NotEmpty().WithMessage("The Phone is required");
            // Check Email is not null, empty 
            RuleFor(user => user.Email).NotNull().NotEmpty().WithMessage("The Email is required");
            // Check Address is not null, empty 
            RuleFor(user => user.Address).NotNull().NotEmpty().WithMessage("The Address is required");

        }

    }
}

