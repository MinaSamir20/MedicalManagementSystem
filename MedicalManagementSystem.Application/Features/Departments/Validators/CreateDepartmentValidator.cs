using FluentValidation;
using MedicalManagementSystem.Application.Features.Departments.Models;
using MedicalManagementSystem.Application.Services.Departments;
using MedicalManagementSystem.Core.SharedResources;
using MedicalManagementSystem.Domain.Entities.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;

namespace MedicalManagementSystem.Application.Features.Departments.Validators
{
    public class CreateDepartmentValidator : AbstractValidator<CreateDepartment>
    {
        private readonly IDepartmentService _department;
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResources> _localizer;
        public CreateDepartmentValidator(IDepartmentService department, IStringLocalizer<SharedResources> localizer, UserManager<User> userManager)
        {
            _department = department;
            _localizer = localizer;
            ApplyValidationsRules();
            ApplyCustomValidationsRules();
            _userManager = userManager;
        }

        public void ApplyValidationsRules()
        {
            RuleFor(x => x.NameEn)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLength]);

            RuleFor(x => x.NameAr)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLength]);

            RuleFor(x => x.UserName)
                .NotEmpty().WithMessage(_localizer[SharedResourcesKeys.NotEmpty])
                .NotNull().WithMessage(_localizer[SharedResourcesKeys.NotNull])
                .MaximumLength(100).WithMessage(_localizer[SharedResourcesKeys.MaxLength]);
        }
        public void ApplyCustomValidationsRules()
        {
            RuleFor(x => x.NameEn)
            .MustAsync(async (Key, CancellationToken) => await _department.IsDepartmentExists(false, Key))
            .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.NameAr)
            .MustAsync(async (Key, CancellationToken) => await _department.IsDepartmentExists(true, Key))
            .WithMessage(_localizer[SharedResourcesKeys.IsExist]);

            RuleFor(x => x.UserName)
            .MustAsync(async (Key, CancellationToken) => await _userManager.FindByNameAsync(Key) != null)
            .WithMessage(_localizer[SharedResourcesKeys.NotFound]);
        }
    }
}
