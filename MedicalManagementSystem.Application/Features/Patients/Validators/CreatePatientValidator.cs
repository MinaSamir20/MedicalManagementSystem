using FluentValidation;
using MedicalManagementSystem.Application.Features.Patients.Models;

namespace MedicalManagementSystem.Application.Features.Patients.Validators
{
    public class CreatePatientValidator : AbstractValidator<CreatePatient>
    {
        public CreatePatientValidator()
        {
            ApplyValidationRules();
        }

        public void ApplyValidationRules()
        {
            RuleFor(x => x.Address).NotEmpty()
                .WithMessage("{PropertyName} Must not Be Empty")
                .NotNull().WithMessage("{PropertyValue} Must not Be Null");
        }
        public void ApplyCustomValidationsRules()
        {
            //RuleFor(x => x.Address).MustAsync(async (Key, CancellationToken) => await _repo.Find(a=>a.Address == Key) is not null);
        }
    }
}
