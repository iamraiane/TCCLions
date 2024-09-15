namespace TCCLions.API.Application.Models.ViewModels;

public class MembroAuthViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public IEnumerable<string> Permissoes { get; set; }
}
