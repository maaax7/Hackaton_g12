using FluentValidation;
using FluentValidation.Results;
using Hackathon_g12.Domain.Interfaces.Validation;
using Hackathon_g12.Domain.Models;
using Hackathon_g12.Domain.Services.Notificacoes;

namespace Hackathon_g12.Domain.Services
{
	public abstract class BaseService
	{
		private readonly IValidador _validador;

		protected BaseService(IValidador notificador)
		{
			_validador = notificador;
		}

		protected void InformarCritica(ValidationResult validationResult)
		{
			foreach (var error in validationResult.Errors)
			{
				InformarCritica(error.ErrorMessage);
			}
		}

		protected void InformarCritica(string mensagem)
		{
			_validador.Handle(new Mensagem(mensagem));
		}

		protected bool Validar<TV, TE>(TV validacao, TE entidade)
		   where TV : AbstractValidator<TE>
		   where TE : Entity
		{
			var validator = validacao.Validate(entidade);

			if (validator.IsValid) return true;

			InformarCritica(validator);

			return false;
		}
	}
}
