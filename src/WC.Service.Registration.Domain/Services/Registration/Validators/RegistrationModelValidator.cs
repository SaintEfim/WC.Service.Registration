﻿using FluentValidation;
using WC.Library.Domain.Validators;
using WC.Service.Registration.Domain.Models;

namespace WC.Service.Registration.Domain.Services.Registration.Validators;

public class RegistrationModelValidator
    : AbstractValidator<RegistrationModel>,
        IDomainCreateValidator
{
    public RegistrationModelValidator()
    {
        RuleFor(x => x.Name)
            .NotEmpty();

        RuleFor(x => x.Surname)
            .NotEmpty();

        RuleFor(x => x.Email)
            .NotEmpty();

        RuleFor(x => x.Password)
            .NotEmpty();

        RuleFor(x => x.PositionId)
            .NotEmpty();
    }
}
