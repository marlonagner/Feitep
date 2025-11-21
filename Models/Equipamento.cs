using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Feitep.Models;

public class Equipamento
{
   [Key]
   [DisplayName("Id")]
    public int Id { get; set; }
    
    [Required(ErrorMessage = "Informe o nome do equipamento")]
    [StringLength(80, ErrorMessage = "O nome deve conter até 80 caracteres")]
    [MinLength(5, ErrorMessage = "O nome deve conter pelo menos 5 caracteres")]
    [DisplayName("Título")]
    public string Titulo { get; set; }
    
    [DataType(DataType.DateTime)]
    [DisplayName("Inicio")]
    public DateTime DataInicial { get; set; }
    
    [DataType(DataType.DateTime)]
    [DisplayName("Término")]
    public DateTime DataFinal { get; set; }
    
    [DisplayName("Professor")]
    [Required(ErrorMessage = "Professor Inválido")]
    public int ProfessorId { get; set; }
    
    public Professor? Professor { get; set; }
}