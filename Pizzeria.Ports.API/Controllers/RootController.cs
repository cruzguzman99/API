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
    public class RootController : ControllerBase
    {
        public RootUseCase CrearServicio()
        {
            PizzeriaDB db = new PizzeriaDB();
            RootRepository repositorio = new RootRepository(db);

            RootUseCase servicio = new RootUseCase(repositorio);

            return servicio;
        }

        // GET: api/Root
        [HttpGet]
        public ActionResult<Root> Get()
        {
            RootUseCase servicio = CrearServicio();

            return Ok(servicio.Listar());
        }

        // GET: api/Root/5
        [HttpGet("{id}", Name = "GetRoot")]
        public ActionResult<Root> Get(Guid id)
        {
            RootUseCase servicio = CrearServicio();

            return Ok(servicio.SeleccionarPorID(id)); ;
        }

        [HttpGet("Seleccionar/{correo}/{contraseña}")]
        public ActionResult<Root> GetSelect(string correo, string contraseña)
        {
            try
            {
                PizzeriaDB db = new PizzeriaDB();
                var RootSeleccionado = db.Root.Where(c => c.Correo == correo).Where(c => c.Contraseña == contraseña).FirstOrDefault();
                RootUseCase servicio = CrearServicio();

                return Ok(servicio.SeleccionarPorID(RootSeleccionado.RootID));
            }
            catch (Exception e)
            {

                return BadRequest(e.Message);
            }

        }

        // POST: api/Root
        [HttpPost]
        public ActionResult<Root> Post([FromBody] Root entidad)
        {
            var base64array = Convert.FromBase64String(entidad.Imagen);
            Guid name = Guid.NewGuid();
            string filePashString = $"Content/img/{name}.png";

            var filePath = Path.Combine($"Content/img/{name}.png");
            System.IO.File.WriteAllBytes(filePath, base64array);

            RootUseCase servicio = CrearServicio();
            entidad.Imagen = filePashString;
            var resultado = servicio.Agregar(entidad);

            return Ok(resultado);
        }

        // PUT: api/Root/5
        [HttpPut("{id}")]
        public ActionResult<Root> Put(Guid id, [FromBody] Root entidad)
        {
            entidad.RootID = id;

            RootUseCase servicio = CrearServicio();

            servicio.Editar(entidad);

            return Ok("Editado Exitosamente");
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public ActionResult<Root> Delete(Guid id)
        {
            RootUseCase servicio = CrearServicio();

            servicio.Eliminar(id);
            return Ok("Eliminado Satisfactoriamente");
        }
    }
}
