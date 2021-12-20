using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactApp.API.Helpers.CustomExtensions
{
    public static class CustomValidatorExtension
    {
        public static IRuleBuilderOptions<T, TProperty> OneOf<T, TProperty>(this IRuleBuilder<T, TProperty> ruleBuilder, params TProperty[] validOptions)
        {
            string formatted;
            if (validOptions == null || validOptions.Length == 0)
            {
                throw new ArgumentException("At least one valid option is expected", nameof(validOptions));
            }
            else if (validOptions.Length == 1)
            {
                formatted = validOptions[0].ToString();
            }
            else
            {
                // format like: option1, option2 or option3
                formatted = $"{string.Join(", ", validOptions.Select(vo => vo.ToString()).ToArray(), 0, validOptions.Length - 1)} or {validOptions.Last()}";
            }

            return ruleBuilder
                .Must(validOptions.Contains)
                .WithMessage($"{{PropertyName}} must be one of these values: '{formatted}'");
        }
    }
}
