using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Hackathon_g12.Application.ViewModels
{
	public class VideoUploadViewModel
	{
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
		public required string Descricao { get; set; }

		[Required(ErrorMessage = "O arquivo de vídeo é obrigatório.")]
		[Display(Name = "Arquivo de Vídeo")]
		public required IFormFile VideoFile { get; set; }
	}
}
