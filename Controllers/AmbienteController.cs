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
    public class AmbienteController : ControllerBase
    {
        private readonly ApplicationDBContext context;
        public AmbienteController(ApplicationDBContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public ActionResult<IEnumerable<Ambiente>> Get()
        {
            return context.Ambiente.Include(x => x.Novedades).ToList();
        }
        [HttpGet("{id}", Name = "ObtenerAmbiente")]
        public ActionResult<Ambiente> Get(int id)
        {
            var ambiente = context.Ambiente.Include(x => x.Novedades).FirstOrDefault(x
                => x.Id == id);
            if (ambiente == null)
            {
                return NotFound();
            }
            return ambiente;
        }
        [HttpPost]
        //El Post crea el registro
        public ActionResult Post([FromBody] Ambiente ambiente)
        {
            
            context.Ambiente.Add(ambiente);
            
            context.SaveChanges();
            
            return new CreatedAtRouteResult("ObtenerAmbiente", new { id = ambiente.Id }, ambiente);
        }
        [HttpPut("{id}")]
        public ActionResult Put([FromBody] Ambiente ambiente, int id)
        {
            if (id != ambiente.Id)
            {
                return BadRequest();
            }
            context.Entry(ambiente).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }
        [HttpDelete("{id}")]
        public ActionResult<Ambiente> Delete(int id)
        {
            var ambiente = context.Ambiente.FirstOrDefault(x => x.Id ==id);
            if (ambiente == null)
            {
                return NotFound();
            }
            
            context.Entry(ambiente).State= EntityState.Deleted;
            context.SaveChanges();
            return ambiente;
        }

    }
}
