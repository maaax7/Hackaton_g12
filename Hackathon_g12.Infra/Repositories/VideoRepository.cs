using Hackathon_g12.Domain.Intefaces.Repositories;
using Hackathon_g12.Domain.Models;
using Hackathon_g12.Infra.Context;
using Microsoft.EntityFrameworkCore;

namespace Hackathon_g12.Infra.Repositories
{
    public class VideoRepository : Repository<Video>, IVideoRepository
	{
        public VideoRepository(BdPosfiapContext context) : base(context) { }

		public virtual async Task Adicionar(List<Video> entities)
		{
			DbSet.AddRange(entities);
			await SaveChanges();
		}

		public async Task<List<Video>> ObterPorSituacao(string situacao)
		{
			return await DbSet.Where(p => p.Situacao == situacao).ToListAsync();
		}
    }
}