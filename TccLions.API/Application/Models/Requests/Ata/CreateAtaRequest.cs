namespace TCCLions.API.Application.Models.Requests.Ata;

public class CreateAtaRequest
{
    public string Titulo { get; set; }
    public string Descricao { get; set; }
    public DateTime DataEscrita { get; set; }
}
