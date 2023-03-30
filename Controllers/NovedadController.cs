using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using ApiAmbiente1.Context;
using ApiAmbiente1.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;



namespace ApiAmbiente1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NovedadController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        public NovedadController(ApplicationDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        //Get Obtiene la información
        public ActionResult<List<Novedad>> Get()
        {
            var novedades = context.Novedad.Include(x => x.Ambiente).ToList();
            return novedades;
        }

        [HttpGet("{id}", Name = "ObtenerNovedad")]
        public ActionResult<Novedad> Get(int id)
        {
            var novedad = context.Novedad.Include(x => x.Ambiente).FirstOrDefault(x
                => x.Id == id);
            if (novedad == null)
            {
                return NotFound();
            }
            return novedad;
        }
        [HttpPost]
        //El Post crea el registro
        public ActionResult Post([FromBody] Novedad novedad)
        {
            
            context.Novedad.Add(novedad);
            
            context.SaveChanges();
      
            return new CreatedAtRouteResult("ObtenerNovedad", new { id = novedad.Id }, novedad);
        }
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Novedad novedad, int id)
        {
            if (id != novedad.Id)
            {
                return BadRequest();
            }
            context.Entry(novedad).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Novedad> Delete(int id)
        {
            var novedad = context.Novedad.FirstOrDefault(x => x.Id == id);
            if (novedad == null)
            {
                return NotFound();
            }
            
            context.Novedad.Remove(novedad);
            context.SaveChanges();
            return novedad;
        }
    }
}
