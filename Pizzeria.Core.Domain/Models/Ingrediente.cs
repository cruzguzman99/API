using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.Domain.Models
{
    public class Ingrediente
    {
        public Guid IngredienteID { get; set; }
        public string Nombre { get; set; }
        public decimal precio { get; set; }
        public decimal Stock { get; set; }
        public string Imagen { get; set; }
        public string unidadMedida { get; set; }
        public List<CrearProducto> crearProductosNav { get; set; }
    }
}
