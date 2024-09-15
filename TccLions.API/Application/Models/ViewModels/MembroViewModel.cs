namespace TCCLions.API.Application.Models.ViewModels;

public class MembroViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Email { get; set; }
    public string EstadoCivil { get; set; }
    public bool IsActive { get; set; }
}
