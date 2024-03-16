using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Hackathon_g12.Application.ViewModels
{
	public class VideoUploadViewModel
	{
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[Display(Name = "Intervalo em Segundos para extração das imagens")]
		[Range(1, 60, ErrorMessage = "O campo {0} precisa estar entre {1} e {2}")]
		public int IntervalSegundos { get; set; }

		[Required(ErrorMessage = "A lista de {0} é obrigatória")]
		public required List<VideoViewModel> Videos { get; set; }
	}

	public class VideoViewModel
	{
		[Required(ErrorMessage = "O campo {0} é obrigatório")]
		[StringLength(250, ErrorMessage = "O campo {0} precisa ter entre {2} e {1} caracteres", MinimumLength = 3)]
		[Display(Name = "Descrição do Vídeo")]
		public required string Descricao { get; set; }

		[Required(ErrorMessage = "O arquivo de vídeo é obrigatório.")]
		[Display(Name = "Arquivo de Vídeo")]
		public required byte[] VideoFile { get; set; }
	}

	public class VideosViewModel
	{
		public long Id { get; set; }
		public string Descricao { get; set; }
		public DateTime DtCad { get; set; }
		public DateTime? DtProc { get; set; }
		public string Url { get; set; }
	}
}
