using Facens.Business.Interfaces;
using Facens.Business.Models;
using Facens.Business.Notifications;
using FluentValidation;
using FluentValidation.Results;

namespace Facens.Business.Services
{
    public class ServiceBase
    {
        private readonly INotificator _notificator;

        public ServiceBase(INotificator notificator)
        {
            _notificator = notificator;
        }

        protected void Notificar(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                Notificar(error.ErrorMessage);
            }
        }

        protected void Notificar(string mensagem)
        {
            _notificator.Handle(new Notification(mensagem));
        }

        protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : EntidadeBase
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            Notificar(validator);

            return false;
        }
    }
}
