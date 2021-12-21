using ContactApp.API.Helpers.CustomExtensions;
using ContactApp.API.Model;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Validations
{
    public class ContactInfoAddValidator : AbstractValidator<ContactInfoAddModel>
    {
        public ContactInfoAddValidator()
        {
            RuleFor(x => x.Key).NotNull().WithMessage("Key field is required!");
            RuleFor(x => x.Key).NotEmpty().WithMessage("Key field is required!");
            RuleFor(x => x.Key).MaximumLength(100).WithMessage("Key field must be less than 100 characters!");
            RuleFor(x => x.Key).OneOf("Telefon Numarası", "E-Mail Adresi", "Konum");
            RuleFor(x => x.Value).NotNull().WithMessage("Value field is required!");
            RuleFor(x => x.Value).NotEmpty().WithMessage("Value field is required!");
            RuleFor(x => x.Value).MaximumLength(200).WithMessage("Value field must be less than 200 characters!");
            RuleFor(x => x.ContactId).NotNull().WithMessage("Contact Id field is required!");
            RuleFor(x => x.ContactId).NotEmpty().WithMessage("Contact Id field is required!");
            RuleFor(x => x.ContactId).Must(x => x.Length == 36).WithMessage("Contact Id field is wrong!");
        }
    }
}
