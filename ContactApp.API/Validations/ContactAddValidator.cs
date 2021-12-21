﻿using ContactApp.API.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Validations
{
    public class ContactAddValidator : AbstractValidator<ContactAddModel>
    {
        public ContactAddValidator()
        {
            RuleFor(x => x.FirstName).NotNull().WithMessage("First Name field is required!");
            RuleFor(x => x.FirstName).NotEmpty().WithMessage("First Name field is required!");
            RuleFor(x => x.FirstName).MaximumLength(35).WithMessage("First Name field must be less than 35 character!");
            RuleFor(x => x.LastName).NotNull().WithMessage("Last Name field is required!");
            RuleFor(x => x.LastName).NotEmpty().WithMessage("Last Name field is required!");
            RuleFor(x => x.LastName).MaximumLength(35).WithMessage("Last Name field must be less than 35 character!");
            RuleFor(x => x.Firm).NotNull().NotNull().WithMessage("Firm field is required!");
            RuleFor(x => x.Firm).NotEmpty().WithMessage("Firm field is required!");
            RuleFor(x => x.Firm).MaximumLength(150).WithMessage("Firm field must be less than 150 character!");
        }
    }
}
