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

        public class TagsProjectController : PadraoController<TagsProjectModel>
        {
            public TagsProjectController(){DAO = new TagsProjetoDAO();}

            public override async Task<IActionResult> Save([FromBody] TagsProjectModel model,bool checkIdBeforeInsertion = false)
            {
                return base.Save(model,checkIdBeforeInsertion).Result;
            }

            public override async Task<IActionResult> ToRecover(string id = null)
            {
                return  base.ToRecover(id).Result;
            }



             public override async Task<IActionResult> Edit(string id)
             {
                 if(id!= null)
                    return base.Edit(id).Result;
                else
                    return BadRequest("Id inválido");
             }

        public IActionResult GetTagsByProject(string idProject)
        {
            try
            {
                TagsProjetoDAO MDAO = (TagsProjetoDAO)DAO;
                var retList = MDAO.RecuperarTagsPorProjeto(idProject);
                return Ok(retList);
            }
            catch (Exception e)
            {
                return BadRequest();
            }
        }


    }


}