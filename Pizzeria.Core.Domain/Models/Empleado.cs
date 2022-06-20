﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Pizzeria.Core.Domain.Models
{
    public class Empleado
    {
        public Guid EmpleadoID { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public int telefono { get; set; }
        public string genero { get; set; }
        public string Imagen { get; set; }
        public string Correo { get; set; }
        public int tipo { get; set; }
        public string Contraseña { get; set; }
        public List<Factura> facturasNav { get; set; }
    }
}
