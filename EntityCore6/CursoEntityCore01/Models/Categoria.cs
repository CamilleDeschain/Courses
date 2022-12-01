using System.ComponentModel.DataAnnotations;

namespace CursoEntityCore01.Models
{
    public class Categoria
    {
        [Key]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public int Categoria_Id { get; set; }
        //[DisplayFormat(ConvertEmptyStringToNull = true, NullDisplayText = "[NULL]")]
        [Required]
        public string Nombre { get; set; }

        [DataType(DataType.Date)]
        public DateTime FechaCreacion { get; set; }

        public bool Activo { get; set; }

        public List<Articulo> Articulo { get; set; }
    }
}
