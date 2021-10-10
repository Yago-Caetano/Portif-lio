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
            public override async Task<IActionResult> Save([FromBody] ProjetoModel model,bool checkIdBeforeInsertion = true)
            {
                bool imgSucessfulSaved = true;
                bool tagSucessfulSaved = true;
                bool vidSucessfulSaved = true;

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
                

                //insert tags
                foreach(TagsProjectModel t in model.Tags)
                {
                    t.idProjeto = (string) model.id;

                    var reqTags= (ObjectResult) await new TagsProjectController().Save(t);
                    if(reqTags.StatusCode != 200)
                    {
                        tagSucessfulSaved = false;
                        break;
                    }
    
                }

                //insert videos
                foreach(VideoModel v in model.Videos)
                {
                    v.IdProjeto = (string) model.id;

                    var reqVideo = (ObjectResult) await new VideoController().Save(v);
                    if(reqVideo.StatusCode != 200)
                    {
                        vidSucessfulSaved = false;
                        break;
                    }
                }


                if(!imgSucessfulSaved)
                {
                    return BadRequest("Falha ao cadastrar imagens");
                }
                else if(!tagSucessfulSaved)
                {
                    return BadRequest("Falha ao cadastrar Tags");
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
                return base.ToRecover(null).Result;
            }

            [HttpPut]
            [Route("Project")]
             public override async Task<IActionResult> Edit(string id,[FromBody] ProjetoModel newModel)
             {
                 return base.Edit(id,newModel).Result;
             }

             [HttpDelete]
             [Route("Project")]
             public override async Task<IActionResult> Delete(string id)
             {
                 return base.Delete(id).Result;
             }


        }


}