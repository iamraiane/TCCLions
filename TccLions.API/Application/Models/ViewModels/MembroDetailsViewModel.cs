namespace TCCLions.API.Application.Models.ViewModels;

public class MembroDetailsViewModel : MembroViewModel
{
    public string Cpf { get; set; }
    public IEnumerable<PermissaoViewModel> Permissoes { get; set; }
}
