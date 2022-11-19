using System.ComponentModel.DataAnnotations;
namespace entitiyframework.Models;

public class Categoria
{
    // [Key]
    public Guid CategoriaId { get;set;}
    // [Required]
    // [MaxLength(50)]
    public string Nombre {get;set;}
    public string Descripcion {get;set;}
    public virtual ICollection<Tarea> Tareas {get;set;}
}