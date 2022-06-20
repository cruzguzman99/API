using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pizzeria.Adaptors.SQLServerDataAccess.Contexts;
using Pizzeria.Core.Application.UseCases;
using Pizzeria.Core.Infraestructure.Repository.Concrete;
using Pizzeria.Core.Domain.Models;
using Microsoft.AspNetCore.Cors;
using System.IO;


namespace Pizzeria.Ports.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdministradorController : ControllerBase
    {
        public AdministadorUseCase CrearServicio()
        {
            PizzeriaDB db = new PizzeriaDB();
            AdministradorRepository repositorio = new AdministradorRepository(db);

            AdministadorUseCase servicio = new AdministadorUseCase(repositorio);

            return servicio;
        }

        // GET: api/Administrador
        [HttpGet]
        public ActionResult<Administrador> Get()
        {
            AdministadorUseCase servicio = CrearServicio();

            return Ok(servicio.Listar());
        }

        // GET: api/Administrador/5
        [HttpGet("{id}", Name = "Get")]
        public ActionResult<Administrador> Get(Guid id)
        {
            AdministadorUseCase servicio = CrearServicio();

            return Ok(servicio.SeleccionarPorID(id)); ;
        }

        [HttpGet("Seleccionar/{correo}/{contraseña}")]
        public ActionResult<Administrador> GetSelect(string correo, string contraseña)
        {
            try
            {
                PizzeriaDB db = new PizzeriaDB();
                var AdministradorSeleccionado = db.Administrador.Where(c => c.Correo == correo).Where(c => c.Contraseña == contraseña).FirstOrDefault();
                AdministadorUseCase servicio = CrearServicio();

                return Ok(servicio.SeleccionarPorID(AdministradorSeleccionado.AdministradoID));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // POST: api/Administrador
        [HttpPost]
        public ActionResult<Administrador> Post([FromBody] Administrador entidad)
        {
            var base64array = Convert.FromBase64String(entidad.Imagen);
            Guid name = Guid.NewGuid();
            string filePashString = $"Content/img/{name}.png";

            var filePath = Path.Combine($"Content/img/{name}.png");
            System.IO.File.WriteAllBytes(filePath, base64array);

            AdministadorUseCase servicio = CrearServicio();
            entidad.Imagen = filePashString;
            var resultado = servicio.Agregar(entidad);

            return Ok(resultado);
        }

        // PUT: api/Administrador/5
        [HttpPut("{id}")]
        public ActionResult<Administrador> Put(Guid id, [FromBody] Administrador entidad)
        {
            entidad.AdministradoID = id;

            AdministadorUseCase servicio = CrearServicio();

            servicio.Editar(entidad);

            return Ok("Editado Exitosamente");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Administrador> Delete(Guid id)
        {
            AdministadorUseCase servicio = CrearServicio();

            servicio.Eliminar(id);
            return Ok("Eliminado Satisfactoriamente");
        }
    }
}
