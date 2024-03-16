using Hackathon_g12.Domain.Models;

namespace Hackathon_g12.Domain.Intefaces.Repositories
{
    public interface IVideoRepository : IRepository<Video>
    {
        Task Adicionar(List<Video> entities);

		Task<List<Video>> ObterPorSituacao(string situacao);
    }
}