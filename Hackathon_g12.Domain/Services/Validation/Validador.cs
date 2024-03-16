using Hackathon_g12.Domain.Interfaces.Validation;

namespace Hackathon_g12.Domain.Services.Notificacoes
{
    public class Validador : IValidador
    {
        private readonly List<Mensagem> _notificacoes;

        public Validador()
        {
            _notificacoes = new List<Mensagem>();
        }

        public void Handle(Mensagem notificacao)
        {
            _notificacoes.Add(notificacao);
        }

        public List<Mensagem> ObterMensagens()
        {
            return _notificacoes;
        }

        public bool ExisteCritica()
        {
            return _notificacoes.Any();
        }
    }
}
