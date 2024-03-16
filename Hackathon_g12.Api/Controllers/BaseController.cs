using Hackathon_g12.Domain.Interfaces.Validation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Net;

namespace Hackathon_g12.Api.Controllers
{
	[ApiController]
	public abstract class BaseController : ControllerBase
	{
		private readonly IValidador _validador;

		protected BaseController(IValidador validador)
		{
			_validador = validador;
		}

		protected bool OperacaoValida()
		{
			return !_validador.ExisteCritica();
		}

		protected ActionResult ApiResponse(HttpStatusCode statusCode = HttpStatusCode.OK, object result = null)
		{
			if (OperacaoValida())
			{

				if (result == null) return NoContent();

				return new ObjectResult(result)
				{
					StatusCode = Convert.ToInt32(statusCode),
				};
			}

			return BadRequest(new
			{
				errors = _validador.ObterMensagens().Select(n => n.Texto)
			});
		}

		protected ActionResult ApiResponse(ModelStateDictionary modelState)
		{
			if (!modelState.IsValid) NotificarErroModelInvalida(modelState);
			return ApiResponse();
		}

		protected void NotificarErroModelInvalida(ModelStateDictionary modelState)
		{
			var erros = modelState.Values.SelectMany(e => e.Errors);
			foreach (var erro in erros)
			{
				var errorMsg = erro.Exception == null ? erro.ErrorMessage : erro.Exception.Message;
				NotificarErro(errorMsg);
			}
		}

		protected void NotificarErro(string mensagem)
		{
			_validador.Handle(new Domain.Services.Notificacoes.Mensagem(mensagem));
		}
	}
}
