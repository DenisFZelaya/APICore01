using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APICore01.Controllers
{
    [ApiController]
    [Route("API/[controller]")]
    public class PersonaController : Controller
    {


        public IActionResult Index()
        {
            //Conexion a db
            using (Models.CRUDAPIHDContext db = new Models.CRUDAPIHDContext())
            {
                //Consulta con LINQ
                var lst = (from d in db.Personas
                           select d).ToList();

                return Ok(lst);
            }

        }

        [HttpPost]
        public ActionResult Post([FromBody] Models.Request.PersonaRequest model) {
            //Conexion a db
            using (Models.CRUDAPIHDContext db = new Models.CRUDAPIHDContext())
            {
                Models.Persona oPersona = new Models.Persona();
                oPersona.Nombre = model.Nombre;
                oPersona.Edad = model.Edad;
                db.Personas.Add(oPersona);
                db.SaveChanges();
            }

            return Ok();
        }


        //Modificar un registro
        [HttpPut]
        public ActionResult Post([FromBody] Models.Persona model)
        {
            //Conexion a db
            using (Models.CRUDAPIHDContext db = new Models.CRUDAPIHDContext())
            {
                Models.Persona oPersona = db.Personas.Find(model.Id);
                oPersona.Nombre = model.Nombre;
                oPersona.Edad = model.Edad;
                db.Entry(oPersona).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                db.SaveChanges();
            }

            return Ok();
        }

        //Eliminar un registro
        [HttpDelete]
        public ActionResult Put([FromBody] Models.Persona model) // Indica que el id va en el cuerpo
        {
            //Conexion a db
            using (Models.CRUDAPIHDContext db = new Models.CRUDAPIHDContext())
            {
                Models.Persona oPersona = db.Personas.Find(model.Id);
                db.Personas.Remove(oPersona);
                db.SaveChanges();
            }

            return Ok();
        }
    }
}
