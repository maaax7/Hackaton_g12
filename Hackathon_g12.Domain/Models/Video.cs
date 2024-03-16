namespace Hackathon_g12.Domain.Models;

public partial class Video : Entity
{
    public string Descricao { get; set; } = null!;

    public string Situacao { get; set; } = null!;

    public DateTime Dtcad { get; set; }

    public DateTime? Dtproc { get; set; }
}
