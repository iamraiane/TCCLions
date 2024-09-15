namespace TCCLions.API.Application.Models.ViewModels;

public class MembroDetailsViewModel : MembroViewModel
{
    public string Cpf { get; set; }
    public IEnumerable<string> Permissoes { get; set; }
    public IEnumerable<EnderecoViewModel> Enderecos { get; set; }
}
