using Hackathon_g12.Domain.Models;

namespace Hackathon_g12.Domain.Interfaces.Services
{
	public interface IVideoService : IDisposable
	{
		Task Adicionar(List<Video> video);
		Task Atualizar(Video video);
		Task Remover(long id);
	}
}
