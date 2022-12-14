using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursoEntityCore01.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        //[RegularExpression(@"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$", ErrorMessage = "Por favor ingrese un email correcto")]
        [EmailAddress(ErrorMessage = "Por favor ingrese un email correcto")]
        public string Email { get; set; }

        [Display(Name = "Dirección del usuario")]
        public string Direccion { get; set; }

        [NotMapped]
        public int Edad { get; set; }

        [ForeignKey("DetalleUsuario")]
        public int? DetalleUsuario_Id { get; set; }
        public DetalleUsuario DetalleUsuario { get; set; }
    }
}
