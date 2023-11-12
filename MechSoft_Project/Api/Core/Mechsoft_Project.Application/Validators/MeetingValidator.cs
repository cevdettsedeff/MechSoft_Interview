using FluentValidation;
using Mechsoft_Project.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mechsoft_Project.Application.Validators
{
    public class MeetingValidator : AbstractValidator<Meeting>
    {
        public MeetingValidator()
        {
            RuleFor(p => p.Participants).NotEmpty().NotNull().WithMessage("Lütfen katılımcılar alanını doldurunuz!");
            RuleFor(p => p.MeetingDate).NotEmpty().NotNull().WithMessage("Lütfen Tarih alanını doldurunuz!");
        }
    }
}
