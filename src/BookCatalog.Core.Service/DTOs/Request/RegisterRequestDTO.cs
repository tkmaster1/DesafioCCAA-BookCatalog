using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace BookCatalog.Core.Service.DTOs.Request;

public class RegisterRequestDTO
{
    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [Display(Name = "Nome")]
    public string Name { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [Display(Name = "Data de Nascimento")]
    public DateTime BirthDate { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [EmailAddress(ErrorMessage = "E-mail em formato inválido.")]
    [Display(Name = "E-mail")]
    public string Email { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório!")]
    [DataType(DataType.Password)]
    [Display(Name = "Senha")]
    public string PasswordHash { get; set; }

    [JsonIgnore]
    public string ReturnUrl { get; set; }
}