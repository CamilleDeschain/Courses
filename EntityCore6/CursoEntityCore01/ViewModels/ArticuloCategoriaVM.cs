using CursoEntityCore01.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CursoEntityCore01.ViewModels
{
    public class ArticuloCategoriaVM
    {
        public Articulo Articulo { get; set; }
        public IEnumerable<SelectListItem> ListaCategorias { get; set; }
    }
}
