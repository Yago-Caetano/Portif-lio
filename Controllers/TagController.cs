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
            public override async Task<IActionResult> Save([FromBody] TagModel model)
            {
                return base.Save(model).Result;
            }

            [HttpGet]
            [Route("Tag")]
            public override async Task<IActionResult> ToRecover(string id = null)
            {
                return Ok();
            }

            [HttpGet]
            [Route("Tags")]
            public async Task<IActionResult> GetAllProjects()
            {
                return Ok();
            }

            [HttpPut]
            [Route("Tag")]
             public override async Task<IActionResult> Edit(string id)
             {
                 return Ok();
             }


        }


}