namespace Hackathon_g12.Domain.Services.Notificacoes
{
    public class Mensagem
    {
        public Mensagem(string texto)
        {
			Texto = texto;
        }

        public string? Texto { get; }
    }
}
