using Hackathon_g12.Application.Services.Videos;
using Hackathon_g12.Application.ViewModels;
using Hackathon_g12.Application.ViewModels.Converters;
using Hackathon_g12.Domain.Interfaces.Services;

namespace Hackathon_g12.Application.Services
{
	public class VideoAplicationService : IVideoApplicationService
	{

		private readonly IVideoService _videoService;

		public VideoAplicationService(IVideoService videoService)
		{
			_videoService = videoService;
		}

		public async Task Adicionar(List<VideoUploadViewModel> videos)
		{
			var videosModel = VideoUploadConverter.ToModel(videos);
			await _videoService.Adicionar(videosModel);
		}
	}
}
