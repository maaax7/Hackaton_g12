using Hackathon_g12.Domain.Models;

namespace Hackathon_g12.Application.ViewModels.Converters
{
	public static class VideoUploadConverter
	{
		public static List<Video> ToModel(List<VideoViewModel> videos)
		{
			return videos.Select(v => new Video
			{
				Descricao = v.Descricao,
				Situacao = "S",
				Dtproc = DateTime.Now,
				Dtcad = DateTime.Now
			}).ToList();
		}

		internal static Video ToModel(VideoViewModel video)
		{
			throw new NotImplementedException();
		}

		internal static List<VideosViewModel> ToViewModel(List<Video> videos)
		{
			return videos.Select(v => new VideosViewModel
			{
				Id = v.Id,
				Descricao = v.Descricao,
				DtCad = v.Dtcad,
				DtProc = v.Dtproc
			}).ToList();
		}
	}
}
