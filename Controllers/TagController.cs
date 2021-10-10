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

        public class TagController : PadraoController<TagModel>
        {
            public TagController(){DAO = new TagDAO();}


            [HttpPost]
            [Route("Tag")]
            public override async Task<IActionResult> Save([FromBody] TagModel model,bool checkIdBeforeInsertion = true)
            {
                return base.Save(model,checkIdBeforeInsertion).Result;
            }

            [HttpGet]
            [Route("Tag")]
            public override async Task<IActionResult> ToRecover(string id = null)
            {
                return  base.ToRecover(id).Result;
            }


            [HttpPut]
            [Route("Tag")]
             public override async Task<IActionResult> Edit(string id,TagModel model)
             {
                 if(id!= null)
                    return base.Edit(id,model).Result;
                else
                    return BadRequest("Id inválido");
             }

             [HttpDelete]
             [Route("Tag")]
             public override async Task<IActionResult> Delete(String Id)
             {
                return base.Delete(Id).Result;
             }


        }


}