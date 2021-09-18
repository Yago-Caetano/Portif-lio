using Portifolio_backend.DAO;
using Portifolio_backend.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Primitives;


namespace Portifolio_backend.Controllers{

        public class ProjetoController : PadraoController<ProjetoModel>
        {
            public ProjetoController(){DAO = new ProjetoDAO();}


            [HttpPost]
            [Route("Project")]
            public override async Task<IActionResult> Save([FromBody] ProjetoModel model)
            {
                bool imgSucessfulSaved = true;

                var requ = (ObjectResult) await base.Save(model);
                if(requ.StatusCode != 200)
                {
                    return BadRequest("Falha ao cadastrar projeto");
                }



                //insert photos
                foreach(FotoModel f in model.Fotos)
                {
                    f.IdProjeto = (string) model.id;
                    var reqFoto = (ObjectResult) await new FotoController().Save(f);
                    if(reqFoto.StatusCode != 200)
                    {
                        imgSucessfulSaved = false;
                    }
                }
                
                if(!imgSucessfulSaved)
                {
                    return BadRequest("Falha ao cadastrar imagens");
                }

                return Ok("Cadastrado com sucesso");
            }

            [HttpGet]
            [Route("Project")]
            public override async Task<IActionResult> ToRecover(string id = null)
            {
                return base.ToRecover(id).Result;
            }

            [HttpGet]
            [Route("Projects")]
            public async Task<IActionResult> GetAllProjects()
            {
                return Ok();
            }

            [HttpPut]
            [Route("Projects")]
             public override async Task<IActionResult> Edit(string id)
             {
                 return base.Edit(id).Result;
             }


        }


}