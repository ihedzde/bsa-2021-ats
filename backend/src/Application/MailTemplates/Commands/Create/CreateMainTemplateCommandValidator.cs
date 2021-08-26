﻿using Application.MailTemplates.Dtos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.MailTemplates.Commands.Create
{
    public class CreateMainTemplateCommandValidator : AbstractValidator<CreateMailTemplateCommand>
    {
        public CreateMainTemplateCommandValidator()
        {
            RuleFor(x => x.MailTemplateDto).NotNull().SetValidator(new MailTemplateCreateDtoValidator());
        }
    }
}