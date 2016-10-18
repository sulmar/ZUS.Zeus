using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZUS.Zeus.Models.Validators
{
    public class BikeValidator : AbstractValidator<Bike>
    {
        public BikeValidator()
        {
            RuleFor(p => p.Color)
                .NotEmpty();

            RuleFor(p => p.Number)
                .Length(1, 5)
                .WithMessage("Długość pola przekoczona!");


        }
    }
}
