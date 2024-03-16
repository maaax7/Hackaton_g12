using Hackathon_g12.Domain.Models;

namespace Hackathon_g12.Application.ViewModels.Converters
{
	public static class VideoUploadConverter
	{
		public static List<Video> ToModel(List<VideoUploadViewModel> videos)
		{
			return videos.Select(v => new Video
			{
				Descricao = v.Descricao,
			}).ToList();
		}
	}
}
