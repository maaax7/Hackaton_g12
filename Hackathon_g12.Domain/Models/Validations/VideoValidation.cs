using FluentValidation;

namespace Hackathon_g12.Domain.Models.Validations
{
	internal class VideoValidation : AbstractValidator<Video>
	{
		public VideoValidation()
		{	RuleFor(c => c.Descricao)
				.NotEmpty().WithMessage("O campo {PropertyName} precisa ser fornecido")
				.Length(2, 1000).WithMessage("O campo {PropertyName} precisa ter entre {MinLength} e {MaxLength} caracteres");
		}
	}
}
