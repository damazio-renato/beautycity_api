using Facens.Business.Models;
using FluentValidation;

namespace Facens.Business.Validations
{
    public class SolicitacaoValidation : AbstractValidator<Solicitacao>
    {
        public SolicitacaoValidation()
        {
            RuleFor(c => c.Latitude)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.Longitude)
                .GreaterThan(0).WithMessage("O campo {PropertyName} precisa ser maior que {ComparisonValue}");

            RuleFor(c => c.Descricao)
                .NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
                .Length(2, 100).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
        }
    }
}
