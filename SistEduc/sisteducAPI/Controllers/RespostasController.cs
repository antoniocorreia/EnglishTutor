using AutoMapper;
using sisteducAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace sisteducAPI.Controllers
{
    public class RespostasController : ApiController
    {
        private dbSistemasEducacionaisEntities1 db = new dbSistemasEducacionaisEntities1();

        public IHttpActionResult PostRespostas(AlunoRespostaPerguntaDto model)
        {
            
            AlunoRespostaPergunta entity = new AlunoRespostaPergunta();
            entity.IdAluno = model.IdAluno;
            entity.IdPergunta = model.IdPergunta;
            entity.Acerto = model.Acerto;
            
            entity.DataHora = DateTime.Now;
            db.AlunoRespostaPergunta.Add(entity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, entity);
        }

        public IHttpActionResult GetRespostas(AlunoRespostaPerguntaDto model)
        {
            AlunoRespostaPergunta entity = new AlunoRespostaPergunta();
            entity.IdAluno = model.IdAluno;
            entity.IdPergunta = model.IdPergunta;
            entity.Acerto = model.Acerto;

            entity.DataHora = DateTime.Now;
            db.AlunoRespostaPergunta.Add(entity);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = entity.Id }, entity);
        }

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
    }
}
