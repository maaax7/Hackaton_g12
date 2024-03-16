
using Hackathon_g12.Application.ViewModels;

namespace Hackathon_g12.Application.Services.Videos
{
	public interface IVideoApplicationService
	{
		Task Adicionar(VideoUploadViewModel videoUploadViewModel);
		Task<List<VideosViewModel>> ObterTodos();
	}
}
