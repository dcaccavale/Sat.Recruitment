using FluentValidation;
using FluentValidation.Results;
using Sat.Recruitment.Model.Entities;
using Sat.Recruitment.Model.Request;
using System;
using System.Text;

namespace Sat.Recruitment.Model.Request.Validations
{
    /// <summary>
    /// Use to validate User class with fluentValidations
    /// </summary>
    public  class UserValidate : AbstractValidator<User>
    {
  
        public UserValidate()
        {
           
            // Check name is not null, empty 
            RuleFor(user => user.Name).NotNull().NotEmpty().WithMessage("The Name is required");
            // Check Phone is not null, empty 
            RuleFor(user => user.Phone).NotNull().NotEmpty().WithMessage("The Phone is required");
            // Check Email is not null, empty and valid format 
            RuleFor(user => user.Email).NotNull().NotEmpty().WithMessage("The Email is required");
            RuleFor(user => user.Email).EmailAddress().WithMessage("Invalid Email format");
            // Check Address is not null, empty 
            RuleFor(user => user.Address).NotNull().NotEmpty().WithMessage("The Address is required");

        }

    }
}

