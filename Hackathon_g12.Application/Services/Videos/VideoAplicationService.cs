using Hackathon_g12.Application.Infra;
using Hackathon_g12.Application.Services.Imagens;
using Hackathon_g12.Application.Services.Storage;
using Hackathon_g12.Application.Services.Videos;
using Hackathon_g12.Application.ViewModels;
using Hackathon_g12.Application.ViewModels.Converters;
using Hackathon_g12.Domain.Interfaces.Services;
using Hackathon_g12.Domain.Models;
using System.IO;

namespace Hackathon_g12.Application.Services
{
	public class VideoAplicationService : IVideoApplicationService
	{
		private readonly IVideoService _videoService;
		private readonly IImagemService _imageService;
		private readonly IStorageService _storageService;

		public VideoAplicationService(IVideoService videoService, IImagemService imageService, 
			IStorageService storageService)
		{
			_videoService = videoService;
			_imageService = imageService;
			_storageService = storageService;
		}

		public async Task Adicionar(VideoUploadViewModel videoUploadViewModel)
		{
			int segundos = videoUploadViewModel.IntervalSegundos;

			List<Video> videos = new List<Video>();

			foreach (var video in videoUploadViewModel.Videos)
			{
				var retorno = _imageService.ExtrairImagensDeVideo(video.VideoFile, segundos);
				await _storageService.UploadFile(retorno.Item1, retorno.Item3);
				
				var videosModel = VideoUploadConverter.ToModel(video);
				videosModel.Descricao = retorno.Item3;
				
				videos.Add(videosModel);
			}

			await _videoService.Adicionar(videos);
		}

		public async Task<List<VideosViewModel>> ObterTodos()
		{
			var videos = await _videoService.ObterTodos();
			return VideoUploadConverter.ToViewModel(videos);
		}
	}
}
