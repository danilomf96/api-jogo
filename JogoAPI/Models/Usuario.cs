using System.ComponentModel.DataAnnotations;

namespace JogoAPI.Models;

public class Usuario
{
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required(ErrorMessage = "Este campo é obrigatorio!")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatorio!")]
    [MinLength(4, ErrorMessage = "Este campo tem o tamanho minimo de 4 caracteres.")]
    [MaxLength(12, ErrorMessage = "Este campo tem o tamanho maximo 12 caracteres.")]
    public string? Senha { get; set; }

    [Required(ErrorMessage = "Este campo é obrigatorio!")]
    public string? Email { get; set; }
    public DateTime CriadoEm { get; set; } = DateTime.Now;
}