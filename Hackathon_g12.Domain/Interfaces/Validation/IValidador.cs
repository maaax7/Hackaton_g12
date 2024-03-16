
using Hackathon_g12.Domain.Services.Notificacoes;

namespace Hackathon_g12.Domain.Interfaces.Validation
{
    public interface IValidador
    {
        bool ExisteCritica();
        List<Mensagem> ObterMensagens();
        void Handle(Mensagem notificacao);
    }
}
