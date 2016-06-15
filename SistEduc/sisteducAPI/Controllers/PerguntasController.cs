using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using sisteducAPI.Models;
using AutoMapper;

namespace sisteducAPI.Controllers
{
    public class PerguntasController : ApiController
    {
        private dbSistemasEducacionaisEntities1 db = new dbSistemasEducacionaisEntities1();

        // GET: api/Perguntas
        public List<PerguntaModel> GetPerguntaModels()
        {
            List<Pergunta> perguntas = db.Pergunta.Include(x => x.Alternativa).ToList();

            var configAlt = new MapperConfiguration(cfg => cfg.CreateMap<Alternativa, AlternativaModel>());
            var mapperAlt = configAlt.CreateMapper();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Pergunta, PerguntaModel>().ForMember(dst => dst.Tema, opt => opt.MapFrom(x => x.Tema.Nome)));
            var mapper = config.CreateMapper();

            List<PerguntaModel> perguntasModel = new List<PerguntaModel>();
            foreach (var pergunta in perguntas)
            {
                PerguntaModel dto = mapper.Map<PerguntaModel>(pergunta);
                dto.Alternativas = new List<AlternativaModel>();
                foreach (var alternativa in pergunta.Alternativa)
                {
                    AlternativaModel altModel = new AlternativaModel();
                    altModel = mapperAlt.Map<AlternativaModel>(alternativa);
                    dto.Alternativas.Add(altModel);
                }

                perguntasModel.Add(dto);
            }

            return perguntasModel;
        }

        // GET: api/Perguntas/5
        [ResponseType(typeof(PerguntaModel))]
        public PerguntaModel GetPerguntaModel(int id)
        {
            Pergunta pergunta = db.Pergunta.Include(x => x.Alternativa).Where(x => x.Id == id).FirstOrDefault();

            var configAlt = new MapperConfiguration(cfg => cfg.CreateMap<Alternativa, AlternativaModel>());
            var mapperAlt = configAlt.CreateMapper();

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Pergunta, PerguntaModel>().ForMember(dst => dst.Tema, opt => opt.MapFrom(x => x.Tema.Nome)));
            var mapper = config.CreateMapper();

            PerguntaModel dto = mapper.Map<PerguntaModel>(pergunta);
            dto.Alternativas = new List<AlternativaModel>();
            foreach (var alternativa in pergunta.Alternativa)
            {
                AlternativaModel altModel = new AlternativaModel();
                altModel = mapperAlt.Map<AlternativaModel>(alternativa);
                dto.Alternativas.Add(altModel);

            }

            return dto;
        }

        //// PUT: api/Perguntas/5
        //[ResponseType(typeof(void))]
        //public IHttpActionResult PutPerguntaModel(int id, PerguntaModel perguntaModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    if (id != perguntaModel.Id)
        //    {
        //        return BadRequest();
        //    }

        //    db.Entry(perguntaModel).State = EntityState.Modified;

        //    try
        //    {
        //        db.SaveChanges();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!PerguntaModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return StatusCode(HttpStatusCode.NoContent);
        //}

        //// POST: api/Perguntas
        //[ResponseType(typeof(PerguntaModel))]
        //public IHttpActionResult PostPerguntaModel(PerguntaModel perguntaModel)
        //{
        //    if (!ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    db.PerguntaModels.Add(perguntaModel);
        //    db.SaveChanges();

        //    return CreatedAtRoute("DefaultApi", new { id = perguntaModel.Id }, perguntaModel);
        //}

        //// DELETE: api/Perguntas/5
        //[ResponseType(typeof(PerguntaModel))]
        //public IHttpActionResult DeletePerguntaModel(int id)
        //{
        //    PerguntaModel perguntaModel = db.PerguntaModels.Find(id);
        //    if (perguntaModel == null)
        //    {
        //        return NotFound();
        //    }

        //    db.PerguntaModels.Remove(perguntaModel);
        //    db.SaveChanges();

        //    return Ok(perguntaModel);
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        //private bool PerguntaModelExists(int id)
        //{
        //    return db.PerguntaModels.Count(e => e.Id == id) > 0;
        //}
    }
}