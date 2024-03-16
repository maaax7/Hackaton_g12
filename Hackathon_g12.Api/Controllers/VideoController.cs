using Hackathon_g12.Application.Services.Videos;
using Hackathon_g12.Application.ViewModels;
using Hackathon_g12.Domain.Interfaces.Validation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Hackathon_g12.Api.Controllers
{
	[Route("api/[controller]")]
	public class VideoController : BaseController
	{
		private readonly IVideoApplicationService _videoApplication;

		public VideoController(IVideoApplicationService videoApplication, IValidador validador) : base(validador)
		{
			_videoApplication = videoApplication;
		}

		[HttpPost]
		public async Task<ActionResult<VideoUploadViewModel>> Adicionar(VideoUploadViewModel videosViewModel)
		{
			if (!ModelState.IsValid) return ApiResponse(ModelState);
			await _videoApplication.Adicionar(videosViewModel);
			return ApiResponse(HttpStatusCode.OK, videosViewModel);
		}

		[HttpGet]
		[Route("{id:long}")]
		public async Task<ActionResult<VideoUploadViewModel>> ObterPorId(long id)
		{
			return ApiResponse(HttpStatusCode.OK, new object { });
		}


		[HttpGet]
		[Route("todos")]
		public async Task<ActionResult<List<VideosViewModel>>> ObterTodos()
		{
			var videos = _videoApplication.ObterTodos();
			return ApiResponse(HttpStatusCode.OK, videos);
		}

		[HttpGet]
		[Route("imagens")]
		public async Task<ActionResult<VideoUploadViewModel>> ObterImagens()
		{
			return ApiResponse(HttpStatusCode.OK, new object { });
		}

		[HttpGet]
		[Route("videos")]
		public async Task<ActionResult<VideoUploadViewModel>> ObterVideos()
		{
			return ApiResponse(HttpStatusCode.OK, new object { });
		}
	}
}
