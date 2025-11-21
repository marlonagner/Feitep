using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace Feitep.Models;

public class Professor
{
    [Key]
    [DisplayName("Id")]
    public int Id {get; set; }
    
    
    [Required(ErrorMessage = "Informe o nome")]
    [StringLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
    [MinLengthAttribute(5, ErrorMessage = " O nome deve conter pelo menos 5 caracteres")]
    [DisplayName("Nome Completo")]
    public string name { get; set; }
    
    [Required(ErrorMessage = "Informe o E-mail")]
    [EmailAddress(ErrorMessage = "E-mail inválido")]
    [DisplayName("E-mail")]
    public string Email {get; set;}


    public List<Equipamento> Equipamentos { get; set; } = new();
}