using Hackathon_g12.Domain.Intefaces.Repositories;
using Hackathon_g12.Domain.Interfaces.Services;
using Hackathon_g12.Domain.Interfaces.Validation;
using Hackathon_g12.Domain.Models;
using Hackathon_g12.Domain.Models.Validations;

namespace Hackathon_g12.Domain.Services
{
    public class VideoService : BaseService, IVideoService
	{
		private readonly IVideoRepository _videoRepository;

		public VideoService(IVideoRepository videoRepository,
							  IValidador notificador) : base(notificador)
		{
			_videoRepository = videoRepository;
		}

		public async Task Adicionar(List<Video> videos)
		{
			if (videos == null || videos.Count == 0)
			{
				InformarCritica("Nenhum video informado para cadastro");
				return;
			}

			bool valid = true;
			foreach (var video in videos)
			{
				if (!Validar(new VideoValidation(), video))
					valid = false;
			}
			if(!valid) return;
			

			await _videoRepository.Adicionar(videos);
		}

		public async Task Atualizar(Video video)
		{
			if (!Validar(new VideoValidation(), video)) return;

			await _videoRepository.Atualizar(video);
		}

		public async Task Remover(long id)
		{
			await _videoRepository.Remover(id);
		}

		public async Task<List<Video>> ObterTodos()
		{
			return await _videoRepository.ObterTodos();
		}

		public void Dispose()
		{
			_videoRepository?.Dispose();
		}
	}
}
