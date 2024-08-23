﻿namespace TCCLions.API.Application.Models.ViewModels;

public class MembroViewModel
{
    public Guid Id { get; set; }
    public string Nome { get; set; }
    public string Endereco { get; set; }
    public string Bairro { get; set; }
    public string Cidade { get; set; }
    public string Cep { get; set; }
    public string Email { get; set; }
    public string EstadoCivil { get; set; }
}