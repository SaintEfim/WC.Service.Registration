﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using WC.Library.Domain.Validators;
using WC.Service.Registration.Domain.Models;
using WC.Service.Registration.Domain.Services.Validators.Model;

namespace WC.Service.Registration.Domain.Services.Validators.Create;

public class EmployeeRegistrationCreateValidator : AbstractValidator<EmployeeRegistrationModel>, IDomainCreateValidator
{
    public EmployeeRegistrationCreateValidator(IServiceProvider provider)
    {
        ClassLevelCascadeMode = CascadeMode.Stop;

        RuleFor(x => x)
            .SetValidator(provider.GetService<EmployeeRegistrationModelValidator>());

        RuleFor(x => x)
            .SetValidator(provider.GetService<EmployeeRegistrationCreateDbValidator>());
    }
}