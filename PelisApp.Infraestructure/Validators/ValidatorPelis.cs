using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PelisApp.Domain.DTOS.Request;
using FluentValidation;

namespace PelisApp.Infraestructure.Validators
{
    public class ValidatorPelis : AbstractValidator<RequestPelis>
    {
        public ValidatorPelis()
        {
            RuleFor(p => p.Titulo).NotNull().NotEmpty().Length(5,30);
            RuleFor(p => p.Director).NotNull().NotEmpty();
            RuleFor(p => p.Genero).NotNull().NotEmpty().Length(5,20);
            RuleFor(p => p.Puntuacion).NotNull().NotEmpty();
            RuleFor(p => p.Rating).NotNull().NotEmpty();
            RuleFor(p => p.FechaPublicacion).NotNull().NotEmpty();
        }
    }
}